using UnityEngine;
using UnityEngine.Events;
using ToolsUI;

namespace Sample {

    // [System.Serializable]
    // public class WaitingEvent : UnityEvent{};
    // [System.Serializable]
    // public class NotWaitingEvent : UnityEvent{};
    // [System.Serializable]
    // public class RetryEvent : UnityEvent{};

    public class WaitingScreenDemo : MonoBehaviour {
        [SerializeField] private WaitingScreen waitingScreenPrefab = null;
        [SerializeField] private WaitingScreenLink waitingScreenLink = null;

        // public WaitingEvent waiting;
        // public NotWaitingEvent notWaiting;
        // public RetryEvent retry;

        // private void Start() {
        //     var waitingScreen = waitingScreenLink.Instantiate(waitingScreenPrefab) as WaitingScreen; 
        // }
        
        public void OnClick_Waiting(){
            waitingScreenLink.Waiting(waitingScreenPrefab);
        }

        public void OnClick_NotWaiting(){
            waitingScreenLink.NotWaiting();
        }

        public void OnClick_Retry(){
            waitingScreenLink.Retry();
        }

    }
}
