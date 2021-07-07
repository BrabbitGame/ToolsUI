using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace ToolsUI {
    [RequireComponent(typeof(ScrollRect))]

    public class AutoSnapScrollBar : MonoBehaviour {
        public bool moveToBottom = true;

        private ScrollRect scroll;
        private int contentSize;
        private bool haveVerticalScrollbar = false;
        private Vector2 bottom = new Vector2(0f, 0f);

        void Awake() {
            scroll = this.GetComponent<ScrollRect>();

            contentSize = scroll.content.transform.childCount;
            haveVerticalScrollbar = scroll.verticalScrollbar != null;
        }

        void OnEnable() {
            scroll.onValueChanged.AddListener(ScrollValueChanged);

            if (haveVerticalScrollbar)
                scroll.verticalScrollbar.onValueChanged.AddListener(VerticalValueChanged);
        }

        void OnDisable() {
            scroll.onValueChanged.RemoveListener(ScrollValueChanged);

            if (haveVerticalScrollbar)
                scroll.verticalScrollbar.onValueChanged.RemoveListener(VerticalValueChanged);
        }


        void ScrollValueChanged(Vector2 value) {
            Canvas.ForceUpdateCanvases();

            if (moveToBottom) {
                scroll.normalizedPosition = bottom;
                StartCoroutine(ForceScrollDown());
            }

            if (scroll.normalizedPosition.y > -0.0001f && scroll.normalizedPosition.y < 0.0001f) {
                moveToBottom = false;
            }

            Canvas.ForceUpdateCanvases();
        }

        void VerticalValueChanged(float value) {
            Canvas.ForceUpdateCanvases();
            int currentSize = scroll.content.transform.childCount;

            if (currentSize != contentSize) {
                // Content Added
                contentSize = scroll.content.transform.childCount;
                Canvas.ForceUpdateCanvases();

                if (moveToBottom) {
                    scroll.normalizedPosition = bottom;
                    StartCoroutine(ForceScrollDown());
                }
            } else {
                if (scroll.normalizedPosition.y > -0.0001f && scroll.normalizedPosition.y < 0.0001f) {
                    moveToBottom = false;
                }
            }

            Canvas.ForceUpdateCanvases();
        }

        IEnumerator ForceScrollDown() {
            yield return new WaitForEndOfFrame();
            Canvas.ForceUpdateCanvases();
            scroll.gameObject.SetActive(true);
            scroll.verticalNormalizedPosition = 0f;

            if (haveVerticalScrollbar)
                scroll.verticalScrollbar.value = 0;

            Canvas.ForceUpdateCanvases();
        }
    }
}