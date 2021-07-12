using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Sample
{

    public class TogglesGroupRoot : MonoBehaviour
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

        public void OnToggleGroup_TogglesIsOn(List<TogglePlus> togglesPlus)
        {
            image_1.gameObject.SetActive(togglesPlus[(int)ToggleId.Image_1]);
            image_2.gameObject.SetActive(togglesPlus[(int)ToggleId.Image_2]);
            image_3.gameObject.SetActive(togglesPlus[(int)ToggleId.Image_3]);

            Debug.Log($"{togglesPlus[(int)ToggleId.Image_1].gameObject.name} is {togglesPlus[(int)ToggleId.Image_1].isOn}");
            Debug.Log($"{togglesPlus[(int)ToggleId.Image_2].gameObject.name} is {togglesPlus[(int)ToggleId.Image_2].isOn}");
            Debug.Log($"{togglesPlus[(int)ToggleId.Image_3].gameObject.name} is {togglesPlus[(int)ToggleId.Image_3].isOn}");
        }

    }
}
