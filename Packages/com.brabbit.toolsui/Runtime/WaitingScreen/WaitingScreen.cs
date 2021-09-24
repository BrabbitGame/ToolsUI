using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

namespace ToolsUI {
    [RequireComponent(typeof(RectTransform))]
    [RequireComponent(typeof(Canvas))]
    [RequireComponent(typeof(CanvasScaler))]
    [RequireComponent(typeof(GraphicRaycaster))]

    public class WaitingScreen : MonoBehaviour {
        [SerializeField] private WaitingScreenLink waitingScreenLink = null;
        [SerializeField] private GameObject panel_Waiting = null;
        [SerializeField] private GameObject panel_Retry = null;
        [SerializeField] private GameObject image_Clessidre = null;
        [SerializeField] private float rotationSpeed = 120;

        [HideInInspector] public UnityAction retryActyon = null;

        private WaitingState state = WaitingState.NotWaiting;

        private void Awake() {
            transform.SetAsLastSibling();
        }

        private void OnEnable() {
            waitingScreenLink.waitingScreenState_Event.AddListener(OnStateChanged);
        }

        private void OnDisable() {
            waitingScreenLink.waitingScreenState_Event.RemoveListener(OnStateChanged); 
        }

        private void OnStateChanged(WaitingState state){
            switch (state)
            {
                case WaitingState.Waiting:
                    Waiting();
                break;
                case WaitingState.NotWaiting:
                    GameObject.Destroy(gameObject);
                break;
                case WaitingState.Retry:
                    Retry();
                break;
                
                default:
                    Debug.LogError($"unexpected switch case: {state}");
                break;
            }

            this.state = state;
        }

        private void Waiting(){
            panel_Waiting.SetActive(true);
            panel_Retry.SetActive(false);
        }

        public void Retry(){
            panel_Waiting.SetActive(false);
            panel_Retry.SetActive(true);   
        }

        private void Update() {
            if (state == WaitingState.Waiting)
                image_Clessidre.transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
        }

        public void OnClick_Retry() {
            OnStateChanged( WaitingState.Waiting );
            retryActyon?.Invoke();
        }
    }
}
