namespace UnityEngine.UI {

    [AddComponentMenu("UI/Tools UI/Item", 5)]
    [RequireComponent(typeof(RectTransform))]
    public class Item : MonoBehaviour {
        public int Index {get; set;} = 0;
        public object Val  {get; set;} = null;
        public object Val1 {get; set;} = null;
        public object Val2 {get; set;} = null;
        public object Val3 {get; set;} = null;
        public object Val4 {get; set;} = null;

        public void Initialize(int index) {
            Index = index;
        }

        public void Initialize<T>(int index, T val) {
            Index = index;
            Val = val;
        }

        public void Initialize<T, T1>(int index, T val, T1 val1) {
            Index = index;
            Val = val;
            Val1 = val1;
        }

        public void Initialize<T, T1, T2>(int index, T val, T1 val1, T2 val2) {
            Index = index;
            Val = val;
            Val1 = val1;
            Val2 = val2;
        }

        public void Initialize<T, T1, T2, T3>(int index, T val, T1 val1, T2 val2, T3 val3) {
            Index = index;
            Val = val;
            Val1 = val1;
            Val2 = val2;
            Val3 = val3;
        }

        public void Initialize<T, T1, T2, T3, T4>(int index, T val, T1 val1, T2 val2, T3 val3, T4 val4) {
            Index = index;
            Val = val;
            Val1 = val1;
            Val2 = val2;
            Val3 = val3;
            Val4 = val4;
        }

        public virtual void Refresh() {}

    } 
}

