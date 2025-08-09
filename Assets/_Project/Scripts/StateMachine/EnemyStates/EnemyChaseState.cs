namespace Platformer
{
    public class EnemyChaseState : EnemyBaseState
    {
        public EnemyChaseState( Enemy me, PlayerController player ) : base( me, player ) { }

        public override void FixedUpdate()
        {
            anim.CrossFade(LocomotionHash, 0.1f);
            agent.SetDestination(player.transform.position);
        }
    }
}
