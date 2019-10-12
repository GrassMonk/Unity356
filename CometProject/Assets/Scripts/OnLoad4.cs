using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnLoad4 : MonoBehaviour
{
    private void OnEnable()
    {
        if (PlayerPrefs.HasKey("AiNum"))
        {
            GameObject.Find("AINum").GetComponent<Slider>().value = PlayerPrefs.GetInt("AiNum"); ;
            GameObject.Find("AIDiff").GetComponent<Slider>().value = PlayerPrefs.GetInt("AiDiff");
        }
    }
}
