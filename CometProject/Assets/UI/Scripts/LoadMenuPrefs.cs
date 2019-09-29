using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadMenuPrefs : MonoBehaviour {

    private float r1, g1, b1, r2, g2, b2, si;
    private int ma, mu, so, gy;
    private Color color;
    private Color specular;
    private GameObject myBall;

    private void Start()
    {
        myBall = GameObject.Find("MenuBall");
    }

    // Update is called once per frame
    void Update ()
    {
        if (PlayerPrefs.HasKey("Color_r"))
        {
            r1 = PlayerPrefs.GetFloat("Color_r");
            g1 = PlayerPrefs.GetFloat("Color_g");
            b1 = PlayerPrefs.GetFloat("Color_b");
            r2 = PlayerPrefs.GetFloat("Spec_r");
            g2 = PlayerPrefs.GetFloat("Spec_g");
            b2 = PlayerPrefs.GetFloat("Spec_b");

            color = new Color(r1, g1, b1, 255.0f);
            specular = new Color(r2, g2, b2, 255.0f);
            myBall.GetComponent<Renderer>().material.SetColor("_Color", color);
            myBall.GetComponent<Renderer>().material.SetColor("_SpecColor", specular);
        }
        if (PlayerPrefs.HasKey("Mass"))
        {
            ma = PlayerPrefs.GetInt("Mass");
            si = PlayerPrefs.GetFloat("Size");

            myBall.GetComponent<Rigidbody>().mass = ma;
            myBall.transform.localScale = new Vector3(si * 100, si * 100, si * 100);
        }

        try
        {
            r1 = GameObject.Find("RSlider1").GetComponent<Slider>().value;
            g1 = GameObject.Find("GSlider1").GetComponent<Slider>().value;
            b1 = GameObject.Find("BSlider1").GetComponent<Slider>().value;
            r2 = GameObject.Find("RSlider2").GetComponent<Slider>().value;
            g2 = GameObject.Find("GSlider2").GetComponent<Slider>().value;
            b2 = GameObject.Find("BSlider2").GetComponent<Slider>().value;

            PlayerPrefs.SetFloat("Color_r", r1);
            PlayerPrefs.SetFloat("Color_g", g1);
            PlayerPrefs.SetFloat("Color_b", b1);
            PlayerPrefs.SetFloat("Spec_r", r2);
            PlayerPrefs.SetFloat("Spec_g", g2);
            PlayerPrefs.SetFloat("Spec_b", b2);
        }
        catch (NullReferenceException e)
        {
            //Debug.Log(e.Message);
        }

        try
        {
            ma = (int)GameObject.Find("mSlider").GetComponent<Slider>().value;
            si = GameObject.Find("sSlider").GetComponent<Slider>().value;

            PlayerPrefs.SetInt("Mass", ma);
            PlayerPrefs.SetFloat("Size", si);
        }
        catch (NullReferenceException e)
        {
           // Debug.Log(e.Message);
        }

        try
        {
            mu = GameObject.Find("ToggleMusic").GetComponent<Toggle>().isOn ? 0 : 1;
            so = GameObject.Find("ToggleSound").GetComponent<Toggle>().isOn ? 0 : 1;
            gy = GameObject.Find("ToggleGyro").GetComponent<Toggle>().isOn ? 0 : 1;

            PlayerPrefs.SetInt("Music", mu);
            PlayerPrefs.SetInt("Sound", so);
            PlayerPrefs.SetInt("Gyro", gy);
        }
        catch (NullReferenceException e)
        {
            // Debug.Log(e.Message);
        }
    }

}
