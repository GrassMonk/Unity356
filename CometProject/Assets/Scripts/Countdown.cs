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
        countText = GameObject.Find("CountdownText").GetComponent<TMPro.TextMeshProUGUI>();
        StartCoroutine("Count");
        Time.timeScale = 0.01f;
        GameObject.Find("PauseButton").GetComponent<Button>().enabled = false;
    }

    IEnumerator Count()
    {
        while (countInt > -1)
        {
            yield return new WaitForSeconds(0.01f);
            countText.text = ("" + countInt);
            countInt--;
        }
        Time.timeScale = 1;
        countText.text = "GO!";
        yield return new WaitForSeconds(1);
        GameObject.Find("PauseButton").GetComponent<Button>().enabled = true;
        countText.enabled = false;
    }
}
