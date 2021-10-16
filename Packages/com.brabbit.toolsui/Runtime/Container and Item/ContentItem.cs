using System.Collections.Generic;
using System.Linq;

namespace UnityEngine.UI {

    [AddComponentMenu("UI/Tools UI/Content Item", 4)]
    [RequireComponent(typeof(LayoutGroup))]
    [RequireComponent(typeof(RectTransform))]

    public class ContentItem : MonoBehaviour {
        public int Count { get => items.Count; }
        public Dictionary<string, Item> Items { get => items; }

        [SerializeField] private Item itemPrefab = null;

        private RectTransform rectTransform = null;
        private Dictionary<string, Item> items = null;

        private void Awake() {
            rectTransform = GetComponent<RectTransform>();
            items = new Dictionary<string, Item>();
            items.Clear();
        }

        public Item Add(string id) {
            if(!PrefabValidate()) return null;
            Item item = Instantiate(itemPrefab, rectTransform) as Item;
            items.Add(id, item);
            return item;
        }

        public Item Add<T>(string id, T val) {
            if(!PrefabValidate()) return null;
            Item item = Instantiate(itemPrefab, rectTransform) as Item;
            item.Initialize(val);

            items.Add(id, item);
            return item;
        }

        public Item Add<T, T1>(string id, T val, T1 val1) {
            if(!PrefabValidate()) return null;
            Item item = Instantiate(itemPrefab, rectTransform) as Item;
            item.Initialize(val, val1);

            items.Add(id, item);
            return item;
        }

        public Item Add<T, T1, T2>(string id, T val, T1 val1, T2 val2) {
            if(!PrefabValidate()) return null;
            Item item = Instantiate(itemPrefab, rectTransform) as Item;
            item.Initialize(val, val1, val2);

            items.Add(id, item);
            return item;
        }

        public Item Add<T, T1, T2, T3>(string id, T val, T1 val1, T2 val2, T3 val3) {
            if(!PrefabValidate()) return null;
            Item item = Instantiate(itemPrefab, rectTransform) as Item;
            item.Initialize(val, val1, val2, val3);

            items.Add(id, item);
            return item;
        }

        public Item Add<T, T1, T2, T3, T4>(string id, T val, T1 val1, T2 val2, T3 val3, T4 val4) {
            if(!PrefabValidate()) return null;
            Item item = Instantiate(itemPrefab, rectTransform) as Item;
            item.Initialize(val, val1, val2, val3, val4);

            items.Add(id,item);
            return item;
        }

        public void Destroy(int index ) {
            if (index > 0 && index < items.Count) {
                var dictRecord = items.ElementAt(index);
                Destroy(dictRecord.Value.gameObject);
                items.Remove(dictRecord.Key);
            }
        }

        public void Destroy(Item item) {
            if (items.ContainsValue(item)) {
                Destroy(item.gameObject);
                var k = items.Single( x=> x.Value == item).Key;
                items.Remove(k);
            }
        }

        public void Destroy(string id ) {
            if ( !string.IsNullOrEmpty(id) && items.ContainsKey(id) ) {
                Item item = items[id];
                Destroy(item.gameObject);
                items.Remove(id);
            }
        }

        public void Clear() {
            foreach (var dictRecord in items) {
                GameObject.Destroy(dictRecord.Value.gameObject);
            }
            items.Clear();
        }

// todo: usare in awake, ed aggiungere un flag che abilita la funzionalità
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
