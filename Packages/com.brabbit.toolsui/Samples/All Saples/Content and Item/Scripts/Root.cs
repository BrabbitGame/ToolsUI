using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Sample {

    public class ToElement {
        public string a;
        public string b;
    }

    public class Root : MonoBehaviour {
        [SerializeField] private ContentItem contentItem = null;

        private Item itemLink;

        void Start() {
            contentItem.Clear();

            for (int i = 0; i < 5; i++) {
                ToElement toElement = new ToElement() { a = $"a{i}", b = $"b{i}" };
                contentItem.Add( i.ToString(), i, $"str{i}", toElement);
            }

            itemLink = contentItem.Items.ElementAt(0).Value;
        }

        public void OnClick_UpdateItem(){
            int i = Convert.ToInt32(itemLink.val);
            i++;
            itemLink.val = i;

            itemLink.Refresh();
        }


    }
}
