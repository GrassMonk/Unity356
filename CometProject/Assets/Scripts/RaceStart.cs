﻿using System.Collections;
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

    
    private int players, diff; 
    // Use this for initialization
    void Start ()
    {

        players = PlayerPrefs.GetInt("AiNum");
        diff = PlayerPrefs.GetInt("AiDiff");
        track = GameObject.Find("Track");
        
        for (int i = 0; i < players; i++)
        {
            //(i * 12f - 265, 2.5f, 6.5f)
            start = Instantiate(start_prefab, new Vector3((i % 2) * 3, 0.1f, -8f + (i * (20 / players))), Quaternion.identity);
            start.transform.SetParent(track.transform);
            start.tag = "Start";
        }
        
        // Instantiate AI waypoints
        for (int i = 0; i < players; i++)
        {
            chkpnt_prefab.tag = ("Marker" + i);
            Instantiate(chkpnt_prefab, new Vector3(90f, 0, 0), Quaternion.identity);
        }

        StartCoroutine(DelayedSpawn(4));

        chkpnt_prefab.tag = "playerMarker";
        Instantiate(chkpnt_prefab, new Vector3(90f, 0, 0), Quaternion.identity);
    }

    IEnumerator DelayedSpawn(float delay)
    {
        yield return new WaitForSeconds(delay);

        // Get Starting Positions
        StartingPosition = GetComponentsInChildren<Transform>();
        StartPos = new List<Transform>();

        for (int i = 0; i < StartingPosition.Length; i++)
        {
            if (StartingPosition[i].tag == "Start")
            {
                StartPos.Add(StartingPosition[i]);
            }

        }

        // Set Difficulty
        switch (diff)
        {
            case 0: // easy
                for (int i = 0; i < players; i++)
                {
                    WeakAI_prefab.tag = "racer" + i;
                    Instantiate(WeakAI_prefab, StartPos[i].position, Quaternion.identity);
                }
                break;

            case 1: // medium
                if (players % 2 == 0)
                {

                    for (int i = 0; i < players; i++)
                    {
                        if(i % 2 == 0)
                        {
                            StrongAI_prefab.tag = "racer" + i;
                            Instantiate(StrongAI_prefab, StartPos[i].position, Quaternion.identity);
                        }
                        else if (i % 2 != 0)
                        {
                            WeakAI_prefab.tag = "racer" + i;
                            Instantiate(WeakAI_prefab, StartPos[i].position, Quaternion.identity);
                        }
                        
                    }
                }

                if (players % 2 != 0 && players != 1)
                {

                    for (int i = 0; i < players; i++)
                    {
                        if(i % 2 != 0)
                        {
                            StrongAI_prefab.tag = "racer" + i;
                            Instantiate(StrongAI_prefab, StartPos[i].position, Quaternion.identity);
                        }
                        else if (i % 2 == 0)
                        {
                            WeakAI_prefab.tag = "racer" + i;
                            Instantiate(WeakAI_prefab, StartPos[i].position, Quaternion.identity);
                        }
                    }
                }

                if (StartPos.Count == 1)
                {
                    for (int i = 0; i < players; i++)
                    {
                        WeakAI_prefab.tag = "racer" + i;
                        Instantiate(StrongAI_prefab, StartPos[i].position, Quaternion.identity);
                    }
                }
                break;

            case 2: // hard
                for (int i = 0; i < players; i++)
                {
                    StrongAI_prefab.tag = "racer" + i;
                    Instantiate(StrongAI_prefab, StartPos[i].position, Quaternion.identity);
                }
                break;
        }
        GameObject.Find("Player").GetComponent<TrackPosition>().InitiateRacers(); // Instantiate racers in position tracking script
    }
}
