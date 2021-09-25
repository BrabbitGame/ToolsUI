using UnityEditor.Build.Reporting;
using UnityEngine;
using UnityEngine.Events;

namespace ToolsUI
{    
    public class WaitingScreenState_Event : UnityEvent<WaitingState>{};
    public class WaitingScreenSetTextTitle_Event : UnityEvent<string>{};
    
    [CreateAssetMenu(fileName = "WaitingScreenLink", menuName = "UI/Tools UI/WaitingScreenLink")]
    public class WaitingScreenLink : ScriptableObject
    {  
        public WaitingScreenState_Event waitingScreenState_Event = new WaitingScreenState_Event();
        public WaitingScreenSetTextTitle_Event waitingScreenSetTextTitle_Event = new WaitingScreenSetTextTitle_Event();
        private WaitingScreen ws = null;

        public void Show(Object prefab, string title, UnityAction abortActyon = null, UnityAction retryActyon = null ){
            if(ws != null) return;

            ws = GameObject.Instantiate(prefab) as WaitingScreen;
            ws.abortActyon = abortActyon;
            ws.retryActyon = retryActyon;

            SetTextTitle(title);
            SetState(WaitingState.Waiting);
        }

        public void SetState( WaitingState state ){
            waitingScreenState_Event?.Invoke(state);
        }   

        public void SetTextTitle( string title ){
            waitingScreenSetTextTitle_Event?.Invoke(title);
        }
    }

    public enum WaitingState {
        Waiting,
        NotWaiting,
        Retry
    }
}