using System;
using UnityEngine;

// ReSharper disable once CheckNamespace
namespace ToolsUI
{
    [CreateAssetMenu(fileName = "WaitingScreenLink", menuName = "UI/Tools UI/WaitingScreenLink")]
    public class WaitingScreenLink : ScriptableObject
    {
        public Action<WaitingState> WaitingScreenStateChangedAction;
        public Action<string> WaitingScreenSetTitleAction;
        public Action<string> WaitingScreenSetSubTitleAction;

        [SerializeField] private WaitingScreen waitingScreenPrefab;
        private WaitingScreen _waitingScreen;

        public void Show(string title, string subTitle, Action abortAction = null, Action retryAction = null)
        {
            if (_waitingScreen != null) return;

            if (waitingScreenPrefab != null)
            {
                _waitingScreen = Instantiate(waitingScreenPrefab);
                _waitingScreen.AbortAction = abortAction;
                _waitingScreen.RetryAction = retryAction;

                SetTitle(title);
                SetSubTitle(subTitle);
                SetState(WaitingState.Waiting);
            }
            else
            {
                Debug.LogError($"waitingScreenPrefab not present", this);
            }
        }

        public void SetState(WaitingState state)
        {
            WaitingScreenStateChangedAction?.Invoke(state);
        }

        public void SetTitle(string title)
        {
            if (!string.IsNullOrEmpty(title))
                WaitingScreenSetTitleAction?.Invoke(title);
        }

        public void SetSubTitle(string subTitle)
        {
            if (!string.IsNullOrEmpty(subTitle))
                WaitingScreenSetSubTitleAction?.Invoke(subTitle);
        }
    }

    public enum WaitingState
    {
        Waiting,
        NotWaiting,
        Retry
    }
}