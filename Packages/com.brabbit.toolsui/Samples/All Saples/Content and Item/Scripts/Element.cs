using System;
using UnityEngine;
using UnityEngine.UI;

namespace Sample {
    public class Element : Item {

        [SerializeField] private Text txt = null;
        private int i;
        private string str;
        private ToElemet toElemet;


        public override void Initialize<T, T1, T2>(T val, T1 val1, T2 val2) {
            //i = val as int;
            i = Convert.ToInt32(val);
            
            //str = Convert.ToString(val1);
            str = val1 as string;

            //toElemet = Convert.ChangeType(val2, val2.GetType()) as ToElemet;
            toElemet = val2 as ToElemet;
        }

        void Start() {
            txt.text = $"{i} - {str} - {toElemet.a}/{toElemet.b}";
        }

    }
}
