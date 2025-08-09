using UnityEngine;
using UnityEngine.AI;
using KBCore.Refs;

namespace Platformer {
    public class Enemy : ValidatedMonoBehaviour {
        [Header("References")]
        [SerializeField, Self] NavMeshAgent _agent;
        [SerializeField, Self] Health _health;
        [SerializeField, Self] PlayerDetector _detector;
        [SerializeField, Self] Animator _anim;
        
        PlayerController _player;

        StateMachine _sm;

        private void Awake() {
            _player = FindFirstObjectByType<PlayerController>();
            
            if ( _player == null ) {
                Debug.LogError( "No player in the current scene!" );
                return;
            }
            
            SetupStateMachine();
        }

        void SetupStateMachine() {
            _sm = new StateMachine();

            var chase = new EnemyChaseState( this, _player );
            var attack = new EnemyAttackState( this, _player );
            var death = new EnemyDeathState( this, _player );

            At( chase, attack, new FuncPredicate( () => _detector.CanAttackPlayer() ) );
            At( attack, chase, new FuncPredicate( () => !_detector.CanAttackPlayer() ) );
            Any( death, new FuncPredicate( () => _health.IsDead ) );

            // enemy always chases player immediately
            _sm.SetState( chase );
        }

        private void FixedUpdate() {
            _sm.FixedUpdate();
        }

        private void Update() {
            _sm.Update();
            
            _anim.SetFloat( "Speed", _agent.velocity.normalized.magnitude );
        }
        
        void At(IState from, IState to, IPredicate condition) => _sm.AddTransition(from, to, condition);
        void Any(IState to, IPredicate condition) => _sm.AddAnyTransition(to, condition);
    }
}
