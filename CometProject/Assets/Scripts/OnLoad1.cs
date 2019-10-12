using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnLoad1 : MonoBehaviour
{
    private void OnEnable()
    {
        if (PlayerPrefs.HasKey("Mass"))
        {
            GameObject.Find("mSlider").GetComponent<Slider>().value = PlayerPrefs.GetInt("Mass"); ;
            GameObject.Find("sSlider").GetComponent<Slider>().value = PlayerPrefs.GetFloat("Size");
        }
    }
}
