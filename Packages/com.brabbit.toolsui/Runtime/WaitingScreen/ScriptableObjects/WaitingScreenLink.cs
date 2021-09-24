using UnityEngine;
using UnityEngine.Events;

namespace ToolsUI
{
    [CreateAssetMenu(fileName = "WaitingScreenLink", menuName = "UI/Tools UI/WaitingScreenLink")]

    // [System.Serializable]
    

    public class WaitingScreenLink : ScriptableObject
    {  
        public class WaitingScreenState_Event : UnityEvent<WaitingState>{}
        public WaitingScreenState_Event waitingScreenState_Event;

        private void Awake() {
            waitingScreenState_Event = new WaitingScreenState_Event();
        }

        // private void Start() {
            
        // }

        // public new Object Instantiate( Object prefab ){
        //     // GameObject go = GameObject.Instantiate(prefab) as GameObject;
        //     // var go = GameObject.Instantiate(prefab);
        //     var go = GameObject.Instantiate(prefab) as WaitingScreen;
        //     return go;
        // }

        public void Waiting(Object prefab){
            if(waitingScreenState_Event == null)
                waitingScreenState_Event = new WaitingScreenState_Event();

            GameObject.Instantiate(prefab);
            waitingScreenState_Event?.Invoke(WaitingState.Waiting);
        }

        public void NotWaiting(){
            if(waitingScreenState_Event == null)
                waitingScreenState_Event = new WaitingScreenState_Event();

            waitingScreenState_Event?.Invoke(WaitingState.NotWaiting);
        }

        public void Retry(){
            if(waitingScreenState_Event == null)
                waitingScreenState_Event = new WaitingScreenState_Event();
                
            waitingScreenState_Event?.Invoke(WaitingState.Retry);
        }
    }

    public enum WaitingState {
        Waiting,
        NotWaiting,
        Retry
    }
}