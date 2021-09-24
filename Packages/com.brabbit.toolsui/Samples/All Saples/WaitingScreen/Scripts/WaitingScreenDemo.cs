using UnityEngine;
using ToolsUI;

namespace Sample {

    public class WaitingScreenDemo : MonoBehaviour {
        [SerializeField] private WaitingScreen waitingScreenPrefab = null;
        [SerializeField] private WaitingScreenLink waitingScreenLink = null;

        public void OnClick_Waiting(){
            waitingScreenLink.Waiting(waitingScreenPrefab, OnCall_Retry);
        }

        public void OnClick_NotWaiting(){
            waitingScreenLink.NotWaiting();
        }

        public void OnClick_Retry(){
            waitingScreenLink.Retry();
        }

        private void OnCall_Retry(){
            Debug.Log("OnCall_Retry");
        }
    }
}
