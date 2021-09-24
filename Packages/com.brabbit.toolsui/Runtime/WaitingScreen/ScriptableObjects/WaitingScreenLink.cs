using UnityEngine;
using UnityEngine.Events;

namespace ToolsUI
{    
    public class WaitingScreenState_Event : UnityEvent<WaitingState>{};
    
    [CreateAssetMenu(fileName = "WaitingScreenLink", menuName = "UI/Tools UI/WaitingScreenLink")]
    public class WaitingScreenLink : ScriptableObject
    {  
        public WaitingScreenState_Event waitingScreenState_Event = new WaitingScreenState_Event();
        private WaitingScreen ws = null;

        public void Waiting(Object prefab, UnityAction retryActyon = null ){
            ws = GameObject.Instantiate(prefab) as WaitingScreen;
            ws.retryActyon = retryActyon;

            waitingScreenState_Event?.Invoke(WaitingState.Waiting);
        }

        public void NotWaiting(){
            waitingScreenState_Event?.Invoke(WaitingState.NotWaiting);
        }

        public void Retry(){
            waitingScreenState_Event?.Invoke(WaitingState.Retry);
        }
    }

    public enum WaitingState {
        Waiting,
        NotWaiting,
        Retry
    }
}