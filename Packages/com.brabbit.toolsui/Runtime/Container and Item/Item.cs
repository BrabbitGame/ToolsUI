namespace UnityEngine.UI {

    [AddComponentMenu("UI/Tools UI/Item", 5)]
    [RequireComponent(typeof(RectTransform))]
    public class Item : MonoBehaviour {

        public object val;
        public object val1;
        public object val2;
        public object val3;
        public object val4;

// todo: togliere il virtual
        public virtual void Initialize<T>(T val) {
            this.val = val;
        }

        public virtual void Initialize<T, T1>(T val, T1 val1) {
            this.val = val;
            this.val1 = val1;
        }

        public virtual void Initialize<T, T1, T2>(T val, T1 val1, T2 val2) {
            this.val = val;
            this.val1 = val1;
            this.val2 = val2;
        }

        public virtual void Initialize<T, T1, T2, T3>(T val, T1 val1, T2 val2, T3 val3) {
            this.val = val;
            this.val1 = val1;
            this.val2 = val2;
            this.val3 = val3;
        }

        public virtual void Initialize<T, T1, T2, T3, T4>(T val, T1 val1, T2 val2, T3 val3, T4 val4) {
            this.val = val;
            this.val1 = val1;
            this.val2 = val2;
            this.val3 = val3;
            this.val4 = val4;
        }

        public virtual void Refresh() {}


    } 
}

