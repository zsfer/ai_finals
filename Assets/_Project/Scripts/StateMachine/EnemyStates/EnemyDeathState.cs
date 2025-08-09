using UnityEngine;

namespace Platformer
{
    public class EnemyDeathState : EnemyBaseState
    {
        public EnemyDeathState( Enemy me, PlayerController player ) : base( me, player ) { }

        public override void OnEnter()
        {
            GameObject.Destroy( me.gameObject );
        }
    }
}
