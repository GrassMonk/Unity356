using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrackPosition : MonoBehaviour
{

    private int players, place;
    private float myTotProg;
    public float[] totProg, progress, totDis, crtDis, playerSize;

    // Use this for initialization
    void Start()
    {
        players = PlayerPrefs.GetInt("AiNum");
        totProg = new float[players];
        progress = new float[players];
        totDis = new float[players];
        crtDis = new float[players];
        playerSize = new float[players];
    }

    public void InitiateRacers()
    {
        for (int i = 0; i < players; i++)
        {
            try
            {
                progress[i] = 0;
                playerSize[i] = (GameObject.FindWithTag("racer" + (i)).transform.localScale.y / 2);
                totDis[i] = Vector3.Distance(GameObject.FindWithTag("racer" + (i)).transform.position, GameObject.FindWithTag("Marker" + (i)).transform.position) - (12.5f + playerSize[i]);
            }
            catch (System.NullReferenceException) { }
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Get players progress
        myTotProg = GameObject.Find("Player").GetComponent<TrackProgress>().totProg;
        place = players+1;
        // For Each racer get progress
       //Debug.Log("my Prog: " + myTotProg);  
        for (int i = 0; i < players; i++)
        {
            Debug.Log(i + " Prog: " + totProg[i]);
            StartCoroutine(GetCrtDis(i));
            if (myTotProg > totProg[i])
                place--;
        }
        // Set placeText
        string placeText;
        if (place == 1)
            placeText = "1st";
        else if (place == 2)
            placeText = "2nd";
        else if (place == 3)
            placeText = "3rd";
        else
            placeText = place + "th";
        GameObject.Find("Place").GetComponent<TMPro.TextMeshProUGUI>().text = placeText;
    }

    public void TotalDistance(int racerNum)
    {
        StartCoroutine(GetTotDis(racerNum));
    }

    private IEnumerator GetTotDis(int racerNum)
    {
        progress[racerNum]++;
        yield return new WaitForSeconds(0);
        try
        {
            totDis[racerNum] = Vector3.Distance(GameObject.FindWithTag("racer" + (racerNum)).transform.position, GameObject.FindWithTag("Marker" + (racerNum)).transform.position) - (12.5f + playerSize[racerNum]);
        }
        catch (System.NullReferenceException) { }
    }

    private IEnumerator GetCrtDis(int racerNum)
    {
        yield return new WaitForSeconds(0);
        try
        {
            //Debug.Log(racerNum + ": Prog: " + progress[racerNum] + " Size: " + playerSize[racerNum] + " TotDis: " + totDis[racerNum]);
            crtDis[racerNum] = Vector3.Distance(GameObject.FindWithTag("racer" + (racerNum)).transform.position, GameObject.FindWithTag("Marker" + (racerNum)).transform.position) - (12.5f + playerSize[racerNum]);
            totProg[racerNum] = progress[racerNum] + (1 - (crtDis[racerNum] / totDis[racerNum]));
        }
        catch (System.NullReferenceException) { }
    }
}
