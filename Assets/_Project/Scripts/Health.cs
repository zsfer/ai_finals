using KBCore.Refs;
using UnityEngine;

namespace Platformer {
    public class Health : ValidatedMonoBehaviour {
        [SerializeField] int maxHealth = 100;
        [SerializeField] FloatEventChannel healthChannel; // SO
        
        [SerializeField, Child] HealthHUD _hud;

        int currentHealth;
        
        public bool IsInvincible = false;
        public bool IsDead => currentHealth <= 0;
        
        void Awake() {
            currentHealth = maxHealth;
        }

        void Start() {
            PublishHealthPercentage();
        }
        
        public void TakeDamage(int damage) {
            if ( IsInvincible )
                return;
            
            currentHealth -= damage;
            PublishHealthPercentage();
        }

        void PublishHealthPercentage() {
            var normalizedHealth = currentHealth / (float) maxHealth;
            if (healthChannel != null)
                healthChannel.Invoke( normalizedHealth );

            if ( _hud != null )
                _hud.UpdateSlider( normalizedHealth );
        }
    }
}
