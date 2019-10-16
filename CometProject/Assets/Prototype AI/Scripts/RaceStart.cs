using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceStart : MonoBehaviour {
    public GameObject StrongAI_prefab;
    public GameObject WeakAI_prefab;
    public GameObject start_prefab;
    public GameObject chkpnt_prefab;

    private GameObject StrongAI;
    private GameObject start;
    private GameObject track;

    private List<Transform> StartPos = new List<Transform>();
    Transform[] StartingPosition;

    //int noOfAI = PlayerPrefs.GetInt("AiNum");
    //int AIDiff = PlayerPrefs.GetInt("AiDiff");
    int players = 1;
    int diff = 0;
    // Use this for initialization
    void Start () {
        track = GameObject.Find("Track");

        //noOfAI = PlayerPrefs.GetInt("AiNum");

        for (int i = 0; i < players; i++)
        {
            start = Instantiate(start_prefab, new Vector3(i * 12f - 265, 2.5f, 6.5f), Quaternion.identity);
            start.transform.SetParent(track.transform);
            start.tag = "Start";
        }

        for (int i = 0; i < players; i++)
        {
            Instantiate(chkpnt_prefab, new Vector3(-195f, 10f, 110f), Quaternion.identity);
            chkpnt_prefab.tag = "Marker" + (i);
        }

        StartCoroutine(DelayedSpawn(0.5f));
    }

    IEnumerator DelayedSpawn(float delay)
    {
        yield return new WaitForSeconds(delay);

        StartingPosition = GetComponentsInChildren<Transform>();
        StartPos = new List<Transform>();

        for (int i = 0; i < StartingPosition.Length; i++)
        {
            if (StartingPosition[i].tag == "Start")
            {
                StartPos.Add(StartingPosition[i]);
            }

        }


        switch (diff)
        {
            case 0:
                if (StartPos.Count % 2 == 0)
                {

                    for (int i = 0; i < (StartPos.Count / 2); i++)
                    {
                        Instantiate(StrongAI_prefab, StartPos[i].position, Quaternion.identity);
                        StrongAI_prefab.tag = "racer" + (i);
                    }

                    for (int i = 0; i < ((StartPos.Count / 2)); i++)
                    {
                        Instantiate(WeakAI_prefab, StartPos[i + (StartPos.Count / 2)].position, Quaternion.identity);
                        WeakAI_prefab.tag = "racer" + (i + (StartPos.Count / 2));
                    }
                }

                else if (StartPos.Count % 2 != 0 && StartPos.Count != 1)
                {

                    for (int i = 0; i < Mathf.Floor((StartPos.Count / 2)); i++)
                    {
                        Instantiate(StrongAI_prefab, StartPos[i].position, Quaternion.identity);
                        StrongAI_prefab.tag = "racer" + (i);
                    }

                    for (int i = 0; i <= Mathf.Ceil((StartPos.Count / 2)); i++)
                    {
                        Instantiate(WeakAI_prefab, StartPos[i + (int)Mathf.Floor((StartPos.Count / 2))].position, Quaternion.identity);
                        WeakAI_prefab.tag = "racer" + (i + (int)Mathf.Ceil((StartPos.Count / 2)));
                    }
                }

                else if (StartPos.Count == 1)
                {
                    for (int i = 0; i < (StartPos.Count); i++)
                    {
                        Instantiate(WeakAI_prefab, StartPos[i].position, Quaternion.identity);
                        WeakAI_prefab.tag = "racer" + (i);
                    }
                }
                break;
        }  
    }

    // Update is called once per frame
    void Update () {
		
	}
}
