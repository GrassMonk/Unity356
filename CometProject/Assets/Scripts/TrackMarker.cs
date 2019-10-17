using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackMarker : MonoBehaviour {

    public GameObject marker;
    private int markerNo = 0, waypointNum;
    private List<Transform> waypoints = new List<Transform>();
    Transform[] trackWaypoints;

    private int players;

    void Start()
    {
        waypointNum = 7;
        players = PlayerPrefs.GetInt("AiNum");
        GameObject track = GameObject.Find("Track");
        trackWaypoints = track.GetComponentsInChildren<Transform>();
        waypoints = new List<Transform>();
        for (int i = 0; i <= waypointNum; i++) {
            if (trackWaypoints[i] != transform && trackWaypoints[i].tag == "waypoint")
            {
                waypoints.Add(trackWaypoints[i]);
            }
        }
        marker.transform.position = waypoints[markerNo].transform.position;
    }

    // Update is called once per frame
    void Update ()
    {
        marker.transform.position = waypoints[markerNo].transform.position;
    }

    void OnTriggerEnter(Collider collision)
    {
        for (int i = 0; i < players; i++)
        {
            if (collision.gameObject.tag == ("racer" + i) && this.gameObject.tag == ("Marker" + i))
            {
                this.GetComponent<Collider>().enabled = false;
                markerNo += 1;
                if (markerNo >= waypointNum)
                {
                    markerNo = 0;
                }
                this.GetComponent<Collider>().enabled = true;
                GameObject.Find("Player").GetComponent<TrackPosition>().TotalDistance(i);
            }
        }

        if (collision.gameObject.tag == "Player" && this.gameObject.tag == "playerMarker")
        {
            this.GetComponent<Collider>().enabled = false;
            markerNo += 1;
            if (markerNo >= waypointNum)
            {
                GameObject.Find("Player").GetComponent<TrackProgress>().IncrementLap();
                markerNo = 0;
            }
            this.GetComponent<Collider>().enabled = true;
            GameObject.Find("Player").GetComponent<TrackProgress>().TotalDistance();
        }
    }
}
