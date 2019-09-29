using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnLoad2 : MonoBehaviour
{
    private void OnEnable()
    {
        if (PlayerPrefs.HasKey("Color_r"))
        {
            GameObject.Find("RSlider1").GetComponent<Slider>().value = PlayerPrefs.GetFloat("Color_r");
            GameObject.Find("GSlider1").GetComponent<Slider>().value = PlayerPrefs.GetFloat("Color_g");
            GameObject.Find("BSlider1").GetComponent<Slider>().value = PlayerPrefs.GetFloat("Color_b");
            GameObject.Find("RSlider2").GetComponent<Slider>().value = PlayerPrefs.GetFloat("Spec_r");
            GameObject.Find("GSlider2").GetComponent<Slider>().value = PlayerPrefs.GetFloat("Spec_g");
            GameObject.Find("BSlider2").GetComponent<Slider>().value = PlayerPrefs.GetFloat("Spec_b");
        }
    }
}
