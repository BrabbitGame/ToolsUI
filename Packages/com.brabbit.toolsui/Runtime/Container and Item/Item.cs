namespace UnityEngine.UI {

    [AddComponentMenu("UI/Tools UI/Item", 5)]
    [RequireComponent(typeof(RectTransform))]
    public class Item : MonoBehaviour {

        public object val;
        public object val1;
        public object val2;
        public object val3;
        public object val4;

        public int Index {get; set;} = 0;

        public void Initialize(int index) {
            Index = index;
        }

        public void Initialize<T>(int index, T val) {
            Index = index;
            this.val = val;
        }

        public void Initialize<T, T1>(int index, T val, T1 val1) {
            Index = index;
            this.val = val;
            this.val1 = val1;
        }

        public void Initialize<T, T1, T2>(int index, T val, T1 val1, T2 val2) {
            Index = index;
            this.val = val;
            this.val1 = val1;
            this.val2 = val2;
        }

        public void Initialize<T, T1, T2, T3>(int index, T val, T1 val1, T2 val2, T3 val3) {
            Index = index;
            this.val = val;
            this.val1 = val1;
            this.val2 = val2;
            this.val3 = val3;
        }

        public void Initialize<T, T1, T2, T3, T4>(int index, T val, T1 val1, T2 val2, T3 val3, T4 val4) {
            Index = index;
            this.val = val;
            this.val1 = val1;
            this.val2 = val2;
            this.val3 = val3;
            this.val4 = val4;
        }

        public virtual void Refresh() {}

    } 
}

