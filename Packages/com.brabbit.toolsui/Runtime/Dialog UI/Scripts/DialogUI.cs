using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace ToolsUI {
    public enum DialogType {
        NoButton,
        OneButto_Positive,
        OneButto_Negative,
        TwoButtons
    }

    public enum PaletteColor {
        Black,
        Purple,
        Magenta,
        Blue,
        Green,
        Yellow,
        Orange,
        Red
    }

    public class Dialog {
        public bool isAutoDestriy = true;
        public DialogType dialogType = DialogType.OneButto_Positive;
        public string Title = "Title";
        public string Message = "Message goes here.";
        public string PositiveButtonText = "Positive";
        public string NegativeButtonText = "Negative";
        public float FadeInDuration = .3f;
        public PaletteColor positive_ButtonColor = PaletteColor.Black;
        public PaletteColor negative_ButtonColor = PaletteColor.Black;
        public UnityAction<bool, bool> OnCloseDialog = null;
    }

    public class DialogUI : MonoBehaviour {
        [SerializeField] GameObject canvas;

        [SerializeField] Text titleUIText;
        [SerializeField] Text messageUIText;

        [SerializeField] Button positiveButton;
        [SerializeField] Button negativeButton;

        [Space(10f)]
        [SerializeField] Color[] paletteColors;

        Image positive_ButtonImage;
        Text positive_ButtonText;

        Image negative_ButtonImage;
        Text negative_ButtonText;

        CanvasGroup canvasGroup;

        Queue<Dialog> dialogsQueue = new Queue<Dialog>();
        Dialog dialog = new Dialog();
        Dialog tempDialog;

        private bool isActive = false;
  
        //Singleton pattern
        public static DialogUI Instance;

        void Awake() {
            Instance = this;

            positive_ButtonImage = positiveButton.GetComponent<Image>();
            positive_ButtonText = positiveButton.GetComponentInChildren<Text>();
           
            negative_ButtonImage = negativeButton.GetComponent<Image>();
            negative_ButtonText = negativeButton.GetComponentInChildren<Text>();

            canvasGroup = canvas.GetComponent<CanvasGroup>();

            SetDialogType(dialog.dialogType);

            positiveButton.onClick.RemoveAllListeners();
            positiveButton.onClick.AddListener( () => Hide(true,false));
            negativeButton.onClick.RemoveAllListeners();
            negativeButton.onClick.AddListener(() => Hide(false, true));
        }

        public DialogUI IsAutoDestroy(bool destroyWhenClose) {
            dialog.isAutoDestriy = destroyWhenClose;
            return Instance;
        }

        public DialogUI SetDialogType(DialogType type) {

            switch (type) {
                case DialogType.NoButton:
                    positiveButton.gameObject.SetActive(false);
                    negativeButton.gameObject.SetActive(false);
                    break;
                case DialogType.OneButto_Positive:
                    positiveButton.gameObject.SetActive(true);
                    negativeButton.gameObject.SetActive(false);
                    break;
                case DialogType.OneButto_Negative:
                    positiveButton.gameObject.SetActive(false);
                    negativeButton.gameObject.SetActive(true);
                    break;
                case DialogType.TwoButtons:
                    positiveButton.gameObject.SetActive(true);
                    negativeButton.gameObject.SetActive(true);
                    break;
            }

            dialog.dialogType = type;
            return Instance;
        }

        public DialogUI SetTitle(string title) {
            dialog.Title = title;
            return Instance;
        }

        public DialogUI SetMessage(string message) {
            dialog.Message = message;
            return Instance;
        }

        public DialogUI SetButtonText( string positive_text = "", string negative_text = "") {
            if (!string.IsNullOrEmpty(positive_text))
                dialog.PositiveButtonText = positive_text;

            if (!string.IsNullOrEmpty(negative_text))
                dialog.NegativeButtonText = negative_text;

            return Instance;
        }

        public DialogUI SetButtonColor(PaletteColor? positive_color = null, PaletteColor? negative_color = null) {
            if (positive_color.HasValue)
                dialog.positive_ButtonColor = (PaletteColor)positive_color;

            if (negative_color.HasValue)
                dialog.negative_ButtonColor = (PaletteColor)negative_color;

            return Instance;
        }

        public DialogUI SetFadeInDuration(float duration) {
            dialog.FadeInDuration = duration;
            return Instance;
        }

        public DialogUI OnClose(UnityAction<bool,bool> action = null) {
            dialog.OnCloseDialog = action;
            return Instance;
        }

//-------------------------------------
        public void Show() {
            dialogsQueue.Enqueue(dialog);
            //Reset Dialog
            dialog = new Dialog();

            if (!isActive)
                ShowNextDialog();
        }

        void ShowNextDialog() {
            tempDialog = dialogsQueue.Dequeue();

            titleUIText.text = tempDialog.Title;
            messageUIText.text = tempDialog.Message;

            positive_ButtonText.text = tempDialog.PositiveButtonText.ToUpper();
            positive_ButtonImage.color = paletteColors[(int)tempDialog.positive_ButtonColor];

            negative_ButtonText.text = tempDialog.NegativeButtonText.ToUpper();
            negative_ButtonImage.color = paletteColors[(int)tempDialog.negative_ButtonColor];

            canvas.SetActive(true);
            isActive = true;
            StartCoroutine(FadeIn(tempDialog.FadeInDuration));
        }

        // Hide dialog
        public void Hide(bool positive, bool negative) {
            canvas.SetActive(false);
            isActive = false;

            tempDialog.OnCloseDialog?.Invoke(positive, negative);

            StopAllCoroutines();

            if (dialogsQueue.Count != 0)
                ShowNextDialog();

            if(tempDialog.isAutoDestriy) {
                Destroy(this.gameObject);
            }
        }

        // Animation
        IEnumerator FadeIn(float duration) {
            float startTime = Time.time;
            float alpha = 0f;

            while (alpha < 1f) {
                alpha = Mathf.Lerp(0f, 1f, (Time.time - startTime) / duration);
                canvasGroup.alpha = alpha;

                yield return null;
            }
        }
    }

}