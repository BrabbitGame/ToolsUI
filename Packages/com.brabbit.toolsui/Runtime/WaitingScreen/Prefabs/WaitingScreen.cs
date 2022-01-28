using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

// ReSharper disable once CheckNamespace
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

        public Action AbortAction = null;
        public Action RetryAction = null;

        private bool _isHourglassTurning;

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
            transform.SetAsLastSibling();
        }

        private void OnEnable()
        {
            waitingScreenLink.WaitingScreenStateChangedAction += OnStateChanged;
            waitingScreenLink.WaitingScreenSetTitleAction += OnSetTitle;
            waitingScreenLink.WaitingScreenSetSubTitleAction += OnSetSubTitle;
        }

        private void OnDisable()
        {
            waitingScreenLink.WaitingScreenStateChangedAction -= OnStateChanged;
            waitingScreenLink.WaitingScreenSetTitleAction -= OnSetTitle;
            waitingScreenLink.WaitingScreenSetSubTitleAction -= OnSetSubTitle;
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
                    Debug.LogError($"unexpected switch case: {state}", this);
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
            buttonAbort.gameObject.SetActive(AbortAction != null);
            panelRetry.SetActive(false);

            _isHourglassTurning = true;
        }

        private void Retry()
        {
            if (RetryAction != null)
            {
                panelWaiting.SetActive(false);
                panelRetry.SetActive(true);

                _isHourglassTurning = false;
            }
            else
            {
                Debug.LogWarning("Try to show retry panel without retry callback button click", this);
            }
        }

        private void Update()
        {
            if (_isHourglassTurning)
                imageHourglass.transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
        }

        public void OnClick_Abort()
        {
            AbortAction?.Invoke();
            OnStateChanged(WaitingState.NotWaiting);
        }

        public void OnClick_Retry()
        {
            RetryAction?.Invoke();
            OnStateChanged(WaitingState.Waiting);
        }
    }
}