using UnityEngine;
using Utilities;

namespace Platformer
{
    public class EnemyAttackState : EnemyBaseState
    {
        CountdownTimer _attackCooldownTimer;

        public EnemyAttackState( 
                Enemy me, 
                PlayerController player
        ) : base( me, player ) {
            _attackCooldownTimer = new CountdownTimer( 1f );
            _attackCooldownTimer.OnTimerStop += () => Attack(); // attack again after cd
        }

        public override void OnEnter()
            => Attack();

        public override void OnExit()
            => _attackCooldownTimer.Stop();

        public override void Update() {
            _attackCooldownTimer.Tick( Time.deltaTime );
        }

        void Attack()
        {
            anim.CrossFade( AttackHash, 0.1f );

            Vector3 attackPos = agent.transform.position + agent.transform.forward;
            Collider[] cols = Physics.OverlapSphere( attackPos, 1 );

            foreach ( var hit in cols ) {
                if ( hit.CompareTag("Player") ) 
                    hit.GetComponent<Health>().TakeDamage( Random.Range( 5, 10 ) );
            }

            _attackCooldownTimer.Start();
        }
    }
}
