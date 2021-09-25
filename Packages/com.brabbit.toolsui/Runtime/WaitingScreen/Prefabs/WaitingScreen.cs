using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

namespace ToolsUI {
    [RequireComponent(typeof(RectTransform))]
    [RequireComponent(typeof(Canvas))]
    [RequireComponent(typeof(CanvasScaler))]
    [RequireComponent(typeof(GraphicRaycaster))]

    public class WaitingScreen : MonoBehaviour {
        [SerializeField] private WaitingScreenLink waitingScreenLink = null;
        [Space]
        [SerializeField] private GameObject panel_Waiting = null;
        [SerializeField] private GameObject panel_Retry = null;
        [SerializeField] private Button button_Abort = null;
        [SerializeField] private TextMeshProUGUI text_Title = null;
        [Space]
        [SerializeField] private GameObject image_Clessidre = null;
        [SerializeField] private float rotationSpeed = 120;

        [HideInInspector] public UnityAction abortActyon = null;
        [HideInInspector] public UnityAction retryActyon = null;

        private bool isClessidreTurning = false;

        private void Awake() {
            transform.SetAsLastSibling();
        }

        private void OnEnable() {
            waitingScreenLink.waitingScreenState_Event.AddListener(OnStateChanged);
            waitingScreenLink.waitingScreenSetTextTitle_Event.AddListener(OnSetTextTitle);
        }

        private void OnDisable() {
            waitingScreenLink.waitingScreenState_Event.RemoveListener(OnStateChanged); 
            waitingScreenLink.waitingScreenSetTextTitle_Event.RemoveListener(OnSetTextTitle);
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
        }

        private void OnSetTextTitle( string title ){
            text_Title.text = title;
        }

        private void Waiting(){
            panel_Waiting.SetActive(true);
            button_Abort.gameObject.SetActive(abortActyon == null ? false : true);
            panel_Retry.SetActive(false);

            isClessidreTurning = true;
        }

        public void Retry(){
            if(retryActyon != null){
                panel_Waiting.SetActive(false);
                panel_Retry.SetActive(true); 

                isClessidreTurning = false; 
            } else {
                Debug.LogError("Try to show retry pannel without retry callback button click");
            }
        }

        private void Update() {
            if (isClessidreTurning)
                image_Clessidre.transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
        }

        public void OnClick_Abort() {
            abortActyon?.Invoke();
            OnStateChanged( WaitingState.NotWaiting );
        }

        public void OnClick_Retry() {
            retryActyon?.Invoke();
            OnStateChanged( WaitingState.Waiting );  
        }
    }
}
