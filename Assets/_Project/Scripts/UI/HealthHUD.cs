using UnityEngine;
using UnityEngine.UI;

namespace Platformer {
    public class HealthHUD : MonoBehaviour {
        [SerializeField] Slider _healthSlider;

        public void UpdateSlider( float value ) {
            _healthSlider.value = value;
        }
    }
}
