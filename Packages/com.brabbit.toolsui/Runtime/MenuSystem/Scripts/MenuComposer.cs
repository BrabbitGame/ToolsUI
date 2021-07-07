using UnityEngine;
using System.Collections.Generic;

namespace ToolsUI {
    [AddComponentMenu("UI/Tools UI/Menu Composer")]
    [DisallowMultipleComponent]

    public class MenuComposer : MonoBehaviour {
        [SerializeField] private bool StartFromEvent = false;
        [SerializeField] private int startScreen = 0;
        [SerializeField] private Menu[] menuScreens;
        private bool isMultiCanvas = false;

        public Menu[] MenuScreens {
            get { return menuScreens; }
            set { menuScreens = value; }
        }

        public int StartScreen {
            get { return startScreen; }
            set { startScreen = value; }
        }
         
        private Stack<Menu> menuStack = new Stack<Menu>();
        public static MenuComposer Instance { get; set; }

        private void Awake() {
            if (GetComponent<Canvas>() == null)
                isMultiCanvas = true;
        }

        private void Start() {
            if (StartFromEvent) return; else Startup();
        }
        // used to start the GameObject from Event
        public void OnStartup() {
            if (StartFromEvent) Startup();
        }

        private void Startup() {
            Instance = this;
            if (MenuScreens.Length > 0 + StartScreen) {
                var startMenu = CreateInstance(MenuScreens[StartScreen].name);
                OpenMenu(startMenu.GetMenu());
            } else {
                Debug.LogError("Not enough Menu Screens configured");
            }
        }

        private void OnDestroy() {
            Instance = null;
        }

        public GameObject CreateInstance(string MenuName) {
            var prefab = GetPrefab(MenuName);

            return Instantiate(prefab, transform);
        }

        public void CreateInstance(string MenuName, out GameObject menuInstance) {
            var prefab = GetPrefab(MenuName);

            menuInstance = Instantiate(prefab, transform);
        }

        public void OpenMenu(Menu menuInstance) {
            // De-activate top menu
            if (menuStack.Count > 0) {
                if (menuInstance.DisableMenusUnderneath) {
                    foreach (var menu in menuStack) {
                        menu.gameObject.SetActive(false);

                        if (menu.DisableMenusUnderneath)
                            break;
                    }
                }

                // multiple canvas is moved on top
                if (isMultiCanvas) {
                    var topCanvas = menuInstance.GetComponent<Canvas>();
                    var previousCanvas = menuStack.Peek().GetComponent<Canvas>();
                    topCanvas.sortingOrder = previousCanvas.sortingOrder + 1;
                }
            }

            menuStack.Push(menuInstance);
        }

        private GameObject GetPrefab(string PrefabName) {
            for (int i = 0; i < MenuScreens.Length; i++) {
                if (MenuScreens[i].name == PrefabName) {
                    return MenuScreens[i].gameObject;
                }
            }
            throw new MissingReferenceException("Prefab not found for " + PrefabName);
        }

        public void CloseMenu(Menu menu) {
            if (menuStack.Count == 0) {
                Debug.LogErrorFormat(menu, "{0} cannot be closed because menu stack is empty", menu.GetType());
                return;
            }

            if (menuStack.Peek() != menu) {
                Debug.LogErrorFormat(menu, "{0} cannot be closed because it is not on top of stack", menu.GetType());
                return;
            }

            CloseTopMenu();
        }

        public void CloseTopMenu() {
            var menuInstance = menuStack.Pop();

            if (menuInstance.DestroyWhenClosed)
                Destroy(menuInstance.gameObject);
            else
                menuInstance.gameObject.SetActive(false);

            // Re-activate top menu
            // If a re-activated menu is an overlay we need to activate the menu under it
            foreach (var menu in menuStack) {
                menu.gameObject.SetActive(true);

                if (menu.DisableMenusUnderneath)
                    break;
            }
        }

        //private void Update() {
            // On Android the back button is sent as Esc
            //if (UIExtensionsInputManager.GetKeyDown(KeyCode.Escape) && menuStack.Count > 0)
            //{
            //    menuStack.Peek().OnBackPressed();
            //}
        //}
    }

    public static class MenuExtensions {
        public static Menu GetMenu(this GameObject go) {
            return go.GetComponent<Menu>();
        }
    }

}