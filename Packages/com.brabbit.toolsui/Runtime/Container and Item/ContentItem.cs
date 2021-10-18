using System.Collections.Generic;
using System.Linq;

namespace UnityEngine.UI {

    [AddComponentMenu("UI/Tools UI/Content Item", 4)]
    [RequireComponent(typeof(LayoutGroup))]
    [RequireComponent(typeof(RectTransform))]

    public class ContentItem : MonoBehaviour {
        public int Count { get => items.Count; }
        public Dictionary<string, Item> Items { get => items; }

        [SerializeField] private bool destryChildrensOnAwake = true;
        [SerializeField] private Item itemPrefab = null;

        private RectTransform rectTransform = null;
        private Dictionary<string, Item> items = null;

        private void Awake() {
            rectTransform = GetComponent<RectTransform>();
            items = new Dictionary<string, Item>();

            if(destryChildrensOnAwake)
                DestryChildrens();
        }

        public Item Add(string id, int? index) {
            if( !PrefabValidate() || items.ContainsKey(id) ) return null;

            Item item = Instantiate(itemPrefab, rectTransform) as Item;
            item.Initialize(ConvertNullableInt(index));
            items.Add(id, item);
            return item;
        }

        public Item Add<T>(string id, int? index, T val) {
            if( !PrefabValidate() || items.ContainsKey(id) ) return null;

            Item item = Instantiate(itemPrefab, rectTransform) as Item;
            item.Initialize(ConvertNullableInt(index), val);
            items.Add(id, item);
            return item;
        }

        public Item Add<T, T1>(string id, int? index, T val, T1 val1) {
            if( !PrefabValidate() || items.ContainsKey(id) ) return null;

            Item item = Instantiate(itemPrefab, rectTransform) as Item;
            item.Initialize(ConvertNullableInt(index), val, val1);
            items.Add(id, item);
            return item;
        }

        public Item Add<T, T1, T2>(string id, int? index, T val, T1 val1, T2 val2) {
            if( !PrefabValidate() || items.ContainsKey(id) ) return null;

            Item item = Instantiate(itemPrefab, rectTransform) as Item;
            item.Initialize(ConvertNullableInt(index), val, val1, val2);
            items.Add(id, item);
            return item;
        }

        public Item Add<T, T1, T2, T3>(string id, int? index, T val, T1 val1, T2 val2, T3 val3) {
            if( !PrefabValidate() || items.ContainsKey(id) ) return null;

            Item item = Instantiate(itemPrefab, rectTransform) as Item;
            item.Initialize(ConvertNullableInt(index), val, val1, val2, val3);
            items.Add(id, item);
            return item;
        }

        public Item Add<T, T1, T2, T3, T4>(string id, int? index, T val, T1 val1, T2 val2, T3 val3, T4 val4) {
            if( !PrefabValidate() || items.ContainsKey(id) ) return null;

            Item item = Instantiate(itemPrefab, rectTransform) as Item;
            item.Initialize(ConvertNullableInt(index), val, val1, val2, val3, val4);
            items.Add(id,item);
            return item;
        }

        private int ConvertNullableInt( int? index ){
            if(index == null) 
                return items.Count;
            else
                return index.Value;
        }

        public Item Get( string id ){
            return items.SingleOrDefault( x=> x.Key == id ).Value;
        }

        public Item Get( int index ){
            return items.ElementAtOrDefault( index ).Value;
        }

        public Item GetLast(){
            return items.ElementAtOrDefault( items.Count-1 ).Value;
        }

        public void OrderByIndex(){
            items = items.OrderBy( r=> r.Value.Index ).ToDictionary( x=> x.Key, y=> y.Value );

            for (int i = 0; i < items.Count; i++)
            {
                items.ElementAt(i).Value.transform.SetSiblingIndex(i);
            }
        }

        public void Destroy(int index ) {
            var dictRecord = items.ElementAtOrDefault(index);

            if( !string.IsNullOrEmpty(dictRecord.Key) || dictRecord.Value != null ){
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

        private void DestryChildrens() {
            int deletable = rectTransform.childCount;
            if(deletable <= 0) return;

            for (int i = deletable; i > 0; i--) {
                Transform childTransform = rectTransform.GetChild(i-1);
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
