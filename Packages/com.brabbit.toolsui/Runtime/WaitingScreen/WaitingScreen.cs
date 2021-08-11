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

        [SerializeField] private GameObject panel_Waiting = null;
        [SerializeField] private GameObject panel_Retry = null;
        [SerializeField] private GameObject image_Clessidre = null;
        [SerializeField] private float rotationSpeed = -90;

        public RetryEvent retry;

        private enum WaitingState {
            Waiting,
            NotWaiting,
            Retry
        }
        private WaitingState actualState = WaitingState.NotWaiting;

        private void Awake() {
            gameObject.SetActive(true);
            CanvasGroup canvasGroup = GetComponent<CanvasGroup>();
            canvasGroup.alpha = 1.0f;
            canvasGroup.interactable = true;
            canvasGroup.blocksRaycasts = true;   
        }


        public void OnWaiting(){
            actualState = WaitingState.Waiting;

            gameObject.SetActive(true);
            panel_Waiting.SetActive(true);
            panel_Retry.SetActive(false);
        }

        public void OnNotWaiting(){
            actualState = WaitingState.NotWaiting;

            gameObject.SetActive(false); 
        }

        public void OnRetry(){
            actualState = WaitingState.Retry;

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
