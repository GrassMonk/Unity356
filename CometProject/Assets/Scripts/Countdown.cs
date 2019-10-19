using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour
{

    private TMPro.TextMeshProUGUI countText;
    private int countInt = 3;
    public GameObject PauseMenu;
    private AudioSource horn;

    // Use this for initialization
    void Start()
    {
        horn = GameObject.Find("HornSound").GetComponent<AudioSource>();
        GameObject.Find("Player").GetComponent<Controller>().enabled = false;
        countText = GameObject.Find("CountdownText").GetComponent<TMPro.TextMeshProUGUI>();
        StartCoroutine("Count");
        Time.timeScale = 1f;
    }

    IEnumerator Count()
    {
        PauseMenu.SetActive(true);
        PauseMenu.SetActive(false);
        while (countInt > -1)
        {
            yield return new WaitForSeconds(1);
            countText.text = ("" + countInt);
            countInt--;
            horn.Play();
        }
        GameObject.Find("Player").GetComponent<Controller>().enabled = true;
        countText.text = "GO!";
        horn.pitch = 2;
        horn.Play();
        yield return new WaitForSeconds(1);
        countText.enabled = false;
    }
}
