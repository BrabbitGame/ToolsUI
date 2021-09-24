using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

namespace ToolsUI {
    [RequireComponent(typeof(RectTransform))]
    [RequireComponent(typeof(Canvas))]
    [RequireComponent(typeof(CanvasScaler))]
    [RequireComponent(typeof(GraphicRaycaster))]
    [RequireComponent(typeof(CanvasGroup))]

    [System.Serializable]
    public class RetryEvent : UnityEvent{};

    public class WaitingScreen : MonoBehaviour {
        [SerializeField] private WaitingScreenLink waitingScreenLink = null;

        [SerializeField] private GameObject panel_Waiting = null;
        [SerializeField] private GameObject panel_Retry = null;
        [SerializeField] private GameObject image_Clessidre = null;
        [SerializeField] private float rotationSpeed = -90;

        public RetryEvent retry;


        private WaitingState actualState = WaitingState.NotWaiting;

        private void Awake() {
            gameObject.SetActive(true);
            CanvasGroup canvasGroup = GetComponent<CanvasGroup>();
            canvasGroup.alpha = 1.0f;
            canvasGroup.interactable = true;
            canvasGroup.blocksRaycasts = true;   
        }
        private void OnEnable() {
            waitingScreenLink.waitingScreenState_Event.AddListener(OnCall_StateChanged);
        }

        private void OnDisable() {
            waitingScreenLink.waitingScreenState_Event.RemoveListener(OnCall_StateChanged); 
        }

        private void OnCall_StateChanged(WaitingState waitingState){
            switch (waitingState)
            {
                case WaitingState.Waiting:
                    Waiting();
                break;
                case WaitingState.NotWaiting:
                    NotWaiting();
                break;
                case WaitingState.Retry:
                    Retry();
                break;
                
                default:
                    Debug.LogError($"unexpected switch case: {waitingState}");
                break;
            }

            actualState = waitingState;
        }

        private void Waiting(){
            gameObject.SetActive(true);
            panel_Waiting.SetActive(true);
            panel_Retry.SetActive(false);
        }

        public void NotWaiting(){
            GameObject.Destroy(this);
            // gameObject.SetActive(false); 
        }

        public void Retry(){
            panel_Waiting.SetActive(false);
            panel_Retry.SetActive(true);   
        }

        private void Update() {
            if (actualState == WaitingState.Waiting)
                image_Clessidre.transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
        }

        public void OnClick_Retry() {
            retry?.Invoke();
        }
    }
}
