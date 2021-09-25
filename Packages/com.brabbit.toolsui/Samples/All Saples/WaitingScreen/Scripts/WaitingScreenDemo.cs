using UnityEngine;
using ToolsUI;

namespace Sample {

    public class WaitingScreenDemo : MonoBehaviour {
        [SerializeField] private WaitingScreen waitingScreenPrefab = null;
        [SerializeField] private WaitingScreenLink waitingScreenLink = null;

        public void OnClick_Show(){
            waitingScreenLink.Show(waitingScreenPrefab, "Starting title",  OnCall_Abort, OnCall_Retry);
            // waitingScreenLink.Waiting(waitingScreenPrefab, "Starting title", null, OnCall_Retry); // without abort button
            // waitingScreenLink.Waiting(waitingScreenPrefab, "Starting title", OnCall_Abort); // without retry pannel
        }

        public void OnClick_NotWaiting(){
            waitingScreenLink.SetState(WaitingState.NotWaiting);
        }

        public void OnClick_Retry(){
            waitingScreenLink.SetState(WaitingState.Retry);
        }

        public void OnClick_SetTitle_1(){
            waitingScreenLink.SetTextTitle("title 1");
        }

        public void OnClick_SetTitle_2(){
            waitingScreenLink.SetTextTitle("title 2");
        }

        private void OnCall_Abort(){
            Debug.Log("OnCall_Abort");
        }

        private void OnCall_Retry(){
            Debug.Log("OnCall_Retry");
        }
    }
}
