using System;
using UnityEngine;
using UnityEngine.UI;

namespace Sample {

    public class ToElement {
        public string a;
        public string b;
    }

    public class Root : MonoBehaviour {
        [SerializeField] private ContentItem contentItem = null;

        void Start() {
            contentItem.Clear();

            for (int i = 0; i < 5; i++) {
                ToElement toElement = new ToElement() { a = $"a{i}", b = $"b{i}" };
                contentItem.Add( i.ToString(), null, i, $"str{i}", toElement);
            }
        }

        public void OnClick_UpdateItem(){
            Item itemLink = contentItem.Get(0);
            int i = Convert.ToInt32(itemLink.Val);
            i++;
            itemLink.Val = i;

            itemLink.Refresh();
        }

        public void OnClick_OrderByRank(){
            contentItem.Get("0").Index++;
            contentItem.OrderByIndex();
        }

        public void OnClick_AddAndOrder(){
            ToElement toElement = new ToElement() { a = $"a{123}", b = $"b{123}" };
            contentItem.Add( "123", null, 123, $"str{123}", toElement);

            contentItem.GetLast().Index--;
            contentItem.OrderByIndex();
        }
    }
}
