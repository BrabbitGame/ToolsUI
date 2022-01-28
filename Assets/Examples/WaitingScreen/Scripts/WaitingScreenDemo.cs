using UnityEngine;
using ToolsUI;

// ReSharper disable once CheckNamespace
namespace Sample
{
    public class WaitingScreenDemo : MonoBehaviour
    {
        [SerializeField] private WaitingScreenLink waitingScreenLink;

        public void OnClick_Show()
        {
            waitingScreenLink.Show("TITLE 1", "with abort and retry buttons", OnCall_Abort, OnCall_Retry);
        }
        
        public void OnClick_Show_1()
        {
            waitingScreenLink.Show("TITLE 2", "without abort button", null, OnCall_Retry);
        }
        
        public void OnClick_Show_2()
        {
            waitingScreenLink.Show("TITLE 3", "without retry button", OnCall_Abort);
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
            Debug.Log("OnCall_Abort", this);
        }

        private void OnCall_Retry()
        {
            Debug.Log("OnCall_Retry", this);
        }
    }
}