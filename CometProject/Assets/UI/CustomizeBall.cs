using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomizeBall : MonoBehaviour {

    private Slider r1, g1, b1, r2, g2, b2, m, s;
    private Color color;
    private Color specular;
    private GameObject myBall;

	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update ()
    {
        try
        {
            r1 = GameObject.Find("RSlider1").GetComponent<Slider>();
            g1 = GameObject.Find("GSlider1").GetComponent<Slider>();
            b1 = GameObject.Find("BSlider1").GetComponent<Slider>();
            r2 = GameObject.Find("RSlider2").GetComponent<Slider>();
            g2 = GameObject.Find("GSlider2").GetComponent<Slider>();
            b2 = GameObject.Find("BSlider2").GetComponent<Slider>();
            myBall = GameObject.Find("My Ball");

            color = new Color(r1.value, g1.value, b1.value, 255.0f);
            specular = new Color(r2.value, g2.value, b2.value, 255.0f);
            myBall.GetComponent<Renderer>().material.SetColor("_Color", color);
            myBall.GetComponent<Renderer>().material.SetColor("_SpecColor", specular);
        }
        catch (NullReferenceException e)
        {
            //Debug.Log(e.Message);
        }
        try
        {
            m = GameObject.Find("mSlider").GetComponent<Slider>();
            s = GameObject.Find("sSlider").GetComponent<Slider>();
            myBall = GameObject.Find("My Ball");

            myBall.GetComponent<Rigidbody>().mass = m.value;
            myBall.transform.localScale = new Vector3(s.value, s.value, s.value) ;
        }
        catch (NullReferenceException e)
        {
            //Debug.Log(e.Message);
        }
    }
}
