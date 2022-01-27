using UnityEngine;
using ToolsUI;

namespace Sample
{
    public class WaitingScreenDemo : MonoBehaviour
    {
        [SerializeField] private WaitingScreen waitingScreenPrefab;
        [SerializeField] private WaitingScreenLink waitingScreenLink;

        public void OnClick_Show()
        {
            waitingScreenLink.Show(waitingScreenPrefab, "TEST TITLE", "test sub title", OnCall_Abort, OnCall_Retry);
            // waitingScreenLink.Waiting(waitingScreenPrefab, "TEST TITLE", "test sub title", null, OnCall_Retry); // without abort button
            // waitingScreenLink.Waiting(waitingScreenPrefab, "TEST TITLE", "test sub title", OnCall_Abort); // without retry panel
        }

        public void OnClick_NotWaiting()
        {
            waitingScreenLink.SetState(WaitingState.NotWaiting);
        }

        public void OnClick_Retry()
        {
            waitingScreenLink.SetState(WaitingState.Retry);
        }

        public void OnClick_SetTitle_1()
        {
            waitingScreenLink.SetTitle("title 1");
        }

        public void OnClick_SetTitle_2()
        {
            waitingScreenLink.SetTitle("title 2");
        }

        public void OnClick_SetSubTitle()
        {
            waitingScreenLink.SetSubTitle("sub title 1");
        }

        private void OnCall_Abort()
        {
            Debug.Log("OnCall_Abort");
        }

        private void OnCall_Retry()
        {
            Debug.Log("OnCall_Retry");
        }
    }
}