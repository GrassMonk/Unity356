using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrackProgress : MonoBehaviour {

    public float totProg;
    private float progress;
    private float totDis, crtDis, playerSize;
    private TMPro.TextMeshProUGUI lapText;
    private int lapInt;
    public GameObject FinishMenu;

    // Use this for initialization
    void Start () {
        totProg = 0;
        progress = 0;
        lapInt = 1;
        playerSize = (GameObject.Find("Player").transform.localScale.y / 2) - 0.1f;
        totDis = Vector3.Distance(GameObject.Find("Player").transform.position, GameObject.FindWithTag("playerMarker").transform.position) - (12.5f + playerSize);
        lapText = GameObject.Find("LapCounter").GetComponent<TMPro.TextMeshProUGUI>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        StartCoroutine("GetCrtDis");
    }

    public void IncrementLap()
    {
        lapInt++;
        if (lapInt != 4)
            lapText.text = (lapInt + "/3");
        else
        {
            string place = GameObject.Find("Place").GetComponent<TMPro.TextMeshProUGUI>().text;
            GameObject.Find("In-Game UI").SetActive(false);
            Time.timeScale = 0;
            FinishMenu.SetActive(true);
            GameObject.Find("Place").GetComponent<TMPro.TextMeshProUGUI>().text = (""+place);
        }
    }

    public void TotalDistance()
    {
        StartCoroutine("GetTotDis");
    }

    private IEnumerator GetTotDis()
    {
        progress++;
        yield return new WaitForSeconds(0);
        totDis = Vector3.Distance(GameObject.Find("Player").transform.position, GameObject.FindWithTag("playerMarker").transform.position) - (12.5f + playerSize);
    }

    private IEnumerator GetCrtDis()
    {
        yield return new WaitForSeconds(0);
        crtDis = Vector3.Distance(GameObject.Find("Player").transform.position, GameObject.FindWithTag("playerMarker").transform.position) - (12.5f + playerSize);
        totProg = progress + (1 - (crtDis / totDis));
        GameObject.Find("ProgressBar").GetComponent<Slider>().value = totProg;
    }
}
