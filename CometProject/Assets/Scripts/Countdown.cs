using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour
{

    private TMPro.TextMeshProUGUI countText;
    private int countInt = 3;

    // Use this for initialization
    void Start()
    {
        GameObject.Find("Player").GetComponent<Controller>().enabled = false;
        countText = GameObject.Find("CountdownText").GetComponent<TMPro.TextMeshProUGUI>();
        StartCoroutine("Count");
        Time.timeScale = 1f;
    }

    IEnumerator Count()
    {
        while (countInt > -1)
        {
            yield return new WaitForSeconds(1);
            countText.text = ("" + countInt);
            countInt--;
        }
        GameObject.Find("Player").GetComponent<Controller>().enabled = true;
        countText.text = "GO!";
        yield return new WaitForSeconds(1);
        countText.enabled = false;
    }
}
