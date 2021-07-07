using System.Collections.Generic;

namespace UnityEngine.UI {

    [AddComponentMenu("UI/Tools UI/Item", 5)]
    [RequireComponent(typeof(RectTransform))]
    public class Item : MonoBehaviour {

        private Dictionary<string, object> dicVal = new Dictionary<string, object>();

        public virtual void Initialize<T>(T val) {}
        public virtual void Initialize<T, T1>(T val, T1 val1) {}
        public virtual void Initialize<T, T1, T2>(T val, T1 val1, T2 val2) {}
        public virtual void Initialize<T, T1, T2, T3>(T val, T1 val1, T2 val2, T3 val3) {}
        public virtual void Initialize<T, T1, T2, T3, T4>(T val, T1 val1, T2 val2, T3 val3, T4 val4) {}
    } 
}

