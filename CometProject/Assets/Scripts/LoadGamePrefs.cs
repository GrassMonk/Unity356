using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadGamePrefs : MonoBehaviour {

    private float r1, g1, b1, r2, g2, b2, si;
    private int ma, mu, so, gy;
    private Color color;
    private Color specular;
    public GameObject myBall;

    private void Start()
    {
        r1 = PlayerPrefs.GetFloat("Color_r");
        g1 = PlayerPrefs.GetFloat("Color_g");
        b1 = PlayerPrefs.GetFloat("Color_b");
        r2 = PlayerPrefs.GetFloat("Spec_r");
        g2 = PlayerPrefs.GetFloat("Spec_g");
        b2 = PlayerPrefs.GetFloat("Spec_b");
        ma = PlayerPrefs.GetInt("Mass");
        si = PlayerPrefs.GetFloat("Size");

        color = new Color(r1, g1, b1, 255.0f);
        specular = new Color(r2, g2, b2, 255.0f);
        myBall.GetComponent<Renderer>().material.SetColor("_Color", color);
        myBall.GetComponent<Renderer>().material.SetColor("_SpecColor", specular);
        myBall.GetComponent<Rigidbody>().mass = ma;
        myBall.transform.localScale = new Vector3(si, si, si);
        if (ma == 1)
            myBall.GetComponent<Controller>().acceleration = 7.5f;
        else if (ma == 2)
            myBall.GetComponent<Controller>().acceleration = 15f;
        else
            myBall.GetComponent<Controller>().acceleration = 22.5f;
    }

    private void Update()
    {
        try
        {
            mu = GameObject.Find("ToggleMusic").GetComponent<Toggle>().isOn ? 0 : 1;
            so = GameObject.Find("ToggleSound").GetComponent<Toggle>().isOn ? 0 : 1;
            gy = GameObject.Find("ToggleGyro").GetComponent<Toggle>().isOn ? 0 : 1;

            PlayerPrefs.SetInt("Music", mu);
            PlayerPrefs.SetInt("Sound", so);
            PlayerPrefs.SetInt("Gyro", gy);
            
            bool gyro = PlayerPrefs.GetInt("Gyro") != 0;
            if (gyro)
                GameObject.Find("MobileJoystick").GetComponent<Image>().enabled = false;
            else
                GameObject.Find("MobileJoystick").GetComponent<Image>().enabled = true;
        }
        catch (NullReferenceException e)
        {
            // Debug.Log(e.Message);
        }
    }
}
