using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

namespace ToolsUI
{
    [RequireComponent(typeof(RectTransform))]
    [RequireComponent(typeof(Canvas))]
    [RequireComponent(typeof(CanvasScaler))]
    [RequireComponent(typeof(GraphicRaycaster))]
    public class WaitingScreen : MonoBehaviour
    {
        [SerializeField] private WaitingScreenLink waitingScreenLink;
        [Space] 
        [SerializeField] private GameObject panelWaiting;
        [SerializeField] private GameObject panelRetry;
        [SerializeField] private Button buttonAbort;
        [SerializeField] private TextMeshProUGUI textTitle;
        [SerializeField] private TextMeshProUGUI textSubTitle;
        [Space] 
        [SerializeField] private GameObject imageHourglass;
        [SerializeField] [Range(0, 200)] private float rotationSpeed = 120;

        public UnityAction abortAction = null;
        public UnityAction retryAction = null;

        private bool _isHourglassTurning;

        private void Awake()
        {
            GameObject.DontDestroyOnLoad(gameObject);
            transform.SetAsLastSibling();
        }

        private void OnEnable()
        {
            waitingScreenLink.waitingScreenState_Event.AddListener(OnStateChanged);
            waitingScreenLink.waitingScreenSetTextTitle_Event.AddListener(OnSetTitle);
            waitingScreenLink.waitingScreenSetTextSubTitle_Event.AddListener(OnSetSubTitle);
        }

        private void OnDisable()
        {
            waitingScreenLink.waitingScreenState_Event.RemoveListener(OnStateChanged);
            waitingScreenLink.waitingScreenSetTextTitle_Event.RemoveListener(OnSetTitle);
            waitingScreenLink.waitingScreenSetTextSubTitle_Event.RemoveListener(OnSetSubTitle);
        }

        private void OnStateChanged(WaitingState state)
        {
            switch (state)
            {
                case WaitingState.Waiting:
                    Waiting();
                    break;
                case WaitingState.NotWaiting:
                    Destroy(gameObject);
                    break;
                case WaitingState.Retry:
                    Retry();
                    break;

                default:
                    Debug.LogError($"unexpected switch case: {state}");
                    break;
            }
        }

        private void OnSetTitle(string title)
        {
            textTitle.text = title;
        }

        private void OnSetSubTitle(string subTitle)
        {
            textSubTitle.text = subTitle;
        }

        private void Waiting()
        {
            panelWaiting.SetActive(true);
            buttonAbort.gameObject.SetActive(abortAction != null);
            panelRetry.SetActive(false);

            _isHourglassTurning = true;
        }

        private void Retry()
        {
            if (retryAction != null)
            {
                panelWaiting.SetActive(false);
                panelRetry.SetActive(true);

                _isHourglassTurning = false;
            }
            else
            {
                Debug.LogError("Try to show retry panel without retry callback button click");
            }
        }

        private void Update()
        {
            if (_isHourglassTurning)
                imageHourglass.transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
        }

        public void OnClick_Abort()
        {
            abortAction?.Invoke();
            OnStateChanged(WaitingState.NotWaiting);
        }

        public void OnClick_Retry()
        {
            retryAction?.Invoke();
            OnStateChanged(WaitingState.Waiting);
        }
    }
}