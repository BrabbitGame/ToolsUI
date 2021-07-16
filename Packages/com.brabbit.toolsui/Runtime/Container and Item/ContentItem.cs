using System.Collections.Generic;

namespace UnityEngine.UI {

    [AddComponentMenu("UI/Tools UI/Content Item", 4)]
    [RequireComponent(typeof(LayoutGroup))]
    [RequireComponent(typeof(RectTransform))]

    public class ContentItem : MonoBehaviour {
        public int Count { get => itemList.Count; }
        public List<Item> ContentList { get => itemList; }

        [SerializeField] private Item itemPrefab = null;

        private RectTransform rectTransform = null;
        private List<Item> itemList = null;

        private void Awake() {
            rectTransform = GetComponent<RectTransform>();
            itemList = new List<Item>();
            itemList.Clear();
        }

        public Item Add() {
            if(!PrefabValidate()) return null;
            Item item = Instantiate(itemPrefab, rectTransform) as Item;
            itemList.Add(item);
            return item;
        }

        public Item Add<T>(T val) {
            if(!PrefabValidate()) return null;
            Item item = Instantiate(itemPrefab, rectTransform) as Item;
            item.Initialize(val);

            itemList.Add(item);
            return item;
        }

        public Item Add<T, T1>(T val, T1 val1) {
            if(!PrefabValidate()) return null;
            Item item = Instantiate(itemPrefab, rectTransform) as Item;
            item.Initialize(val, val1);

            itemList.Add(item);
            return item;
        }

        public Item Add<T, T1, T2>(T val, T1 val1, T2 val2) {
            if(!PrefabValidate()) return null;
            Item item = Instantiate(itemPrefab, rectTransform) as Item;
            item.Initialize(val, val1, val2);

            itemList.Add(item);
            return item;
        }

        public Item Add<T, T1, T2, T3>(T val, T1 val1, T2 val2, T3 val3) {
            if(!PrefabValidate()) return null;
            Item item = Instantiate(itemPrefab, rectTransform) as Item;
            item.Initialize(val, val1, val2, val3);

            itemList.Add(item);
            return item;
        }

        public Item Add<T, T1, T2, T3, T4>(T val, T1 val1, T2 val2, T3 val3, T4 val4) {
            if(!PrefabValidate()) return null;
            Item item = Instantiate(itemPrefab, rectTransform) as Item;
            item.Initialize(val, val1, val2, val3, val4);

            itemList.Add(item);
            return item;
        }

// todo: testare, se funziona fare le varianti come Add
        public Item Insert<T, T1, T2>(int index, T val, T1 val1, T2 val2) {
            if(!PrefabValidate()) return null;
            Item item = Instantiate(itemPrefab, rectTransform) as Item;
            item.transform.SetSiblingIndex( index );
            item.Initialize(val, val1, val2);

            itemList.Insert(index, item);
            return item;
        }

        public void Destroy(int index ) {
            if (index > 0 && index < itemList.Count) {
                Item item = itemList[index];
                Destroy(item.gameObject);
                itemList.Remove(item);
            }
        }

        public void Destroy(Item item) {
            if (itemList.Contains(item)) {
                Destroy(item.gameObject);
                itemList.Remove(item);
            }
        }

        public void Clear() {
            foreach (Item item in itemList) {
                Destroy(item.gameObject);
            }
            itemList.Clear();
        }

        public void DestryChildrens() {
            int index = rectTransform.childCount - 1;

            for (int i = index; i >= index; i--) {
                Transform childTransform = rectTransform.GetChild(i);
                Destroy(childTransform.gameObject);
            }
        }

        private bool PrefabValidate(){
            if(itemPrefab == null) {
                Debug.LogError("No Prefab in ContentItem");
                return false;
            }
            return true;
        }

    }
}
