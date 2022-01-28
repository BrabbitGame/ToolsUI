using UnityEngine;
using UnityEngine.Events;

namespace ToolsUI
{
    public class WaitingScreenState_Event : UnityEvent<WaitingState>
    {
    };

    public class WaitingScreenSetTextTitle_Event : UnityEvent<string>
    {
    };

    public class WaitingScreenSetTextSubTitle_Event : UnityEvent<string>
    {
    };

    [CreateAssetMenu(fileName = "WaitingScreenLink", menuName = "UI/Tools UI/WaitingScreenLink")]
    public class WaitingScreenLink : ScriptableObject
    {
        public WaitingScreenState_Event waitingScreenState_Event = new WaitingScreenState_Event();
        public WaitingScreenSetTextTitle_Event waitingScreenSetTextTitle_Event = new WaitingScreenSetTextTitle_Event();
        public WaitingScreenSetTextSubTitle_Event waitingScreenSetTextSubTitle_Event = new WaitingScreenSetTextSubTitle_Event();

        [SerializeField] private WaitingScreen waitingScreenPrefab;
        private WaitingScreen _waitingScreen;

        public void Show(string title, string subTitle, UnityAction abortAction = null, UnityAction retryAction = null)
        {
            if (_waitingScreen != null) return;

            if (waitingScreenPrefab != null)
            {
                _waitingScreen = Instantiate(waitingScreenPrefab);
                _waitingScreen.abortAction = abortAction;
                _waitingScreen.retryAction = retryAction;

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
            waitingScreenState_Event?.Invoke(state);
        }

        public void SetTitle(string title)
        {
            if (!string.IsNullOrEmpty(title))
                waitingScreenSetTextTitle_Event?.Invoke(title);
        }

        public void SetSubTitle(string subTitle)
        {
            if (!string.IsNullOrEmpty(subTitle))
                waitingScreenSetTextSubTitle_Event?.Invoke(subTitle);
        }
    }

    public enum WaitingState
    {
        Waiting,
        NotWaiting,
        Retry
    }
}