using UnityEngine;
using UnityEngine.Events;
using ToolsUI;

namespace Sample {

    [System.Serializable]
    public class WaitingEvent : UnityEvent{};
    [System.Serializable]
    public class NotWaitingEvent : UnityEvent{};
    [System.Serializable]
    public class RetryEvent : UnityEvent{};


    public class WaitingScreenDemo : MonoBehaviour {

        public WaitingEvent waiting;
        public NotWaitingEvent notWaiting;
        public RetryEvent retry;
        
        public void OnClick_Waiting(){
            waiting?.Invoke();
        }

        public void OnClick_NotWaiting(){
            notWaiting?.Invoke();
        }

        public void OnClick_Retry(){
            retry?.Invoke();
        }

    }
}
