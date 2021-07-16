using System;
using UnityEngine;
using UnityEngine.UI;

namespace Sample {
    public class Element : Item {

        [SerializeField] private Text txt = null;

        private void Awake() {
           // not usable, if you want val, va1, .....
        }

        void Start() {
            Refresh();
        }

        public override void Refresh() {
            int i = Convert.ToInt32(val);
            
            //string str = Convert.ToString(val1);
            string str = val1 as string;

            //ToElement toElement = Convert.ChangeType(val2, val2.GetType()) as ToElement;
            ToElement toElement = val2 as ToElement;

            txt.text = $"{i} - {str} - {toElement.a}/{toElement.b}";
        }

    }
}
