using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackMarker : MonoBehaviour {

    public GameObject marker;
    private int markerNo = 1;
    private List<Transform> waypoints = new List<Transform>();
    Transform[] trackWaypoints;

    void Start()
    {
        GameObject track = GameObject.Find("Track");
        trackWaypoints = track.GetComponentsInChildren<Transform>();
        waypoints = new List<Transform>();
        for (int i = 0; i < trackWaypoints.Length; i++) {
            if (trackWaypoints[i] != transform);
            waypoints.Add(trackWaypoints[i]);
        }
        marker.transform.position = waypoints[markerNo].transform.position;
    }

    // Update is called once per frame
    void Update () {

        marker.transform.position = waypoints[markerNo].transform.position;
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "racer1" && this.gameObject.tag == "Marker")
        {
            this.GetComponent<Collider>().enabled = false;
            markerNo += 1;
            if (markerNo == trackWaypoints.Length)
            {
                markerNo = 1;
            }
            this.GetComponent<Collider>().enabled = true;
        }

        else if (collision.gameObject.tag == "racer2" && this.gameObject.tag == "Marker1")
        {
            this.GetComponent<Collider>().enabled = false;
            markerNo += 1;
            if (markerNo == trackWaypoints.Length)
            {
                markerNo = 1;
            }
            this.GetComponent<Collider>().enabled = true;
        }

        else if (collision.gameObject.tag == "racer3" && this.gameObject.tag == "Marker2")
        {
            this.GetComponent<Collider>().enabled = false;
            markerNo += 1;
            if (markerNo == trackWaypoints.Length)
            {
                markerNo = 1;
            }
            this.GetComponent<Collider>().enabled = true;
        }

        else if (collision.gameObject.tag == "racer4" && this.gameObject.tag == "Marker3")
        {
            this.GetComponent<Collider>().enabled = false;
            markerNo += 1;
            if (markerNo == trackWaypoints.Length)
            {
                markerNo = 1;
            }
            this.GetComponent<Collider>().enabled = true;
        }
    }
}
