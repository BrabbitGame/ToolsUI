using UnityEngine;
using UnityEngine.UI;

namespace Sample {

    public class Root : MonoBehaviour {
        [SerializeField] private ContentItem contentItem = null;

        void Start() {
            contentItem.Clear();

            for (int i = 0; i < 5; i++) {
                //contentItem.Add("i", i, "str", $"str {i}");

                ToElemet toElemet = new ToElemet() { a = $"a{i}", b = $"b{i}" };
                contentItem.Add( i, $"str{i}", toElemet);
            }

        }


    }

    public class ToElemet {
        public string a;
        public string b;
    }
}
