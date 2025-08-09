using UnityEngine;
using UnityEngine.Events;

namespace Platformer {
    public abstract class EventListener<T> : MonoBehaviour {
        [SerializeField] EventChannel<T> eventChannel; // 1 (SO)
        [SerializeField] UnityEvent<T> unityEvent;

        protected void Awake() {
            var evt = Instantiate(eventChannel); // instance 2 (SO Inst)
            eventChannel.Register(this);
        }
        
        protected void OnDestroy() {
            eventChannel.Deregister(this);
        }
        
        public void Raise(T value) {
            eventChannel?.Invoke(value);
        }
        
    }
    public class EventListener : EventListener<Empty> { }
}
