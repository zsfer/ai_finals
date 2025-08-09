using UnityEngine;
using UnityEngine.AI;

namespace Platformer
{
    public abstract class EnemyBaseState : IState
    {
        protected readonly Enemy me;
        protected readonly NavMeshAgent agent;
        protected readonly PlayerController player;
        protected readonly Animator anim;

        protected static readonly int LocomotionHash = Animator.StringToHash("Locomotion");
        protected static readonly int JumpHash = Animator.StringToHash("Jump");
        protected static readonly int DashHash = Animator.StringToHash("Dash");
        protected static readonly int AttackHash = Animator.StringToHash("Attack");

        protected EnemyBaseState( Enemy me, PlayerController player )
        {
            this.me = me;
            this.player = player;

            this.anim = me.GetComponent<Animator>();
            this.agent = me.GetComponent<NavMeshAgent>();
        }

        public virtual void FixedUpdate() { }

        public virtual void OnEnter() { }

        public virtual void OnExit() { }

        public virtual void Update() { }
    }
}
