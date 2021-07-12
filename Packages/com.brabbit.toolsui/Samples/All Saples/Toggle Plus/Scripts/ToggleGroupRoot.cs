using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Sample
{

    public class ToggleGroupRoot : MonoBehaviour
    {
        [SerializeField] private Image image_1 = null;
        [SerializeField] private Image image_2 = null;
        [SerializeField] private Image image_3 = null;

        enum ToggleId
        {
            Image_1 = 0,
            Image_2 = 1,
            Image_3 = 2
        }

        public void OnToggleGroup_ToggleIsOn(TogglePlus toggle)
        {

            switch ((ToggleId)toggle.Id)
            {
                case ToggleId.Image_1:
                    image_1.gameObject.SetActive(true);
                    image_2.gameObject.SetActive(false);
                    image_3.gameObject.SetActive(false);
                    Debug.Log($"{image_1.gameObject.name} is On");
                    break;
                case ToggleId.Image_2:
                    image_1.gameObject.SetActive(false);
                    image_2.gameObject.SetActive(true);
                    image_3.gameObject.SetActive(false);
                    Debug.Log($"{image_2.gameObject.name} is On");
                    break;
                case ToggleId.Image_3:
                    image_1.gameObject.SetActive(false);
                    image_2.gameObject.SetActive(false);
                    image_3.gameObject.SetActive(true);
                    Debug.Log($"{image_3.gameObject.name} is On");
                    break;
                default:
                    Debug.Log("toggle.Id not managed");
                    break;
            }

        }

    }
}
