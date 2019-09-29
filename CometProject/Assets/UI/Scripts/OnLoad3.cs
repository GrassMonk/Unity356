using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnLoad3 : MonoBehaviour
{
    private void OnEnable()
    {
        if (PlayerPrefs.HasKey("Music"))
        {
            if (PlayerPrefs.GetInt("Music") == 0)
                GameObject.Find("ToggleMusic").GetComponent<Toggle>().isOn = true;
            else
                GameObject.Find("ToggleMusic").GetComponent<Toggle>().isOn = false;
            if (PlayerPrefs.GetInt("Sound") == 0)
                GameObject.Find("ToggleSound").GetComponent<Toggle>().isOn = true;
            else
                GameObject.Find("ToggleSound").GetComponent<Toggle>().isOn = false;
            if (PlayerPrefs.GetInt("Gyro") == 0)
                GameObject.Find("ToggleGyro").GetComponent<Toggle>().isOn = true;
            else
                GameObject.Find("ToggleGyro").GetComponent<Toggle>().isOn = false;
        }
    }
}
