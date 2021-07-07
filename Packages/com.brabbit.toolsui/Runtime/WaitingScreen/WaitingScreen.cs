namespace UnityEngine.UI {
    [RequireComponent(typeof(RectTransform))]
    [RequireComponent(typeof(Canvas))]
    [RequireComponent(typeof(CanvasScaler))]
    [RequireComponent(typeof(GraphicRaycaster))]
    [RequireComponent(typeof(CanvasGroup))]

    public class WaitingScreen : MonoBehaviour {

        [SerializeField] private GameObject panel_Waiting = null;
        [SerializeField] private GameObject panel_Retry = null;
        [SerializeField] private GameObject image_Clessidre = null;
        [SerializeField] private float rotationSpeed = -90;

        private State state = State.NotWaiting;

        public enum State {
            Waiting,
            NotWaiting,
            Retry
        }

        private void Awake() {
            gameObject.SetActive(false);

            CanvasGroup canvasGroup = GetComponent<CanvasGroup>();
            canvasGroup.alpha = 1.0f;
            canvasGroup.interactable = true;
            canvasGroup.blocksRaycasts = true;
        }

        public void OnChangeState(State state) {
            switch (state) {
                case State.Waiting:
                    Waiting();
                    break;
                case State.NotWaiting:
                    NotWaiting();
                    break;
                case State.Retry:
                    Retry();
                    break;
                default:
                    break;
            }
        }

        private void Update() {
            if (state == State.Waiting)
                image_Clessidre.transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
        }

        private void Waiting() {
            state = State.Waiting;
            gameObject.SetActive(true);
            panel_Waiting.SetActive(true);
            panel_Retry.SetActive(false);
        }

        private void NotWaiting() {
            state = State.NotWaiting;
            gameObject.SetActive(false);
        }

        private void Retry() {
            state = State.Retry;
            panel_Waiting.SetActive(false);
            panel_Retry.SetActive(true);
        }

        public void OnClick_Retry() {
            panel_Waiting.SetActive(true);
            panel_Retry.SetActive(false);
        }
    }
}
