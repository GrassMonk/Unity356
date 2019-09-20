using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Marker : MonoBehaviour {

    public GameObject marker;
    public GameObject waypoint1, waypoint2, waypoint3, waypoint4, waypoint5, waypoint6, waypoint7, waypoint8, waypoint9, waypoint10, waypoint11, waypoint12, waypoint13;
    public int markerNo;

    // Update is called once per frame
    void Update () {
		if (markerNo == 0)
        {
            marker.transform.position = waypoint1.transform.position;
        }
        if (markerNo == 1)
        {
            marker.transform.position = waypoint2.transform.position;
        }
        if (markerNo == 2)
        {
            marker.transform.position = waypoint3.transform.position;
        }
        if (markerNo == 3)
        {
            marker.transform.position = waypoint4.transform.position;
        }
        if (markerNo == 4)
        {
            marker.transform.position = waypoint5.transform.position;
        }
        if (markerNo == 5)
        {
            marker.transform.position = waypoint6.transform.position;
        }
        if (markerNo == 6)
        {
            marker.transform.position = waypoint7.transform.position;
        }
        if (markerNo == 7)
        {
            marker.transform.position = waypoint8.transform.position;
        }
        if (markerNo == 8)
        {
            marker.transform.position = waypoint9.transform.position;
        }
        if (markerNo == 9)
        {
            marker.transform.position = waypoint10.transform.position;
        }
        if (markerNo == 10)
        {
            marker.transform.position = waypoint11.transform.position;
        }
        if (markerNo == 11)
        {
            marker.transform.position = waypoint12.transform.position;
        }
        if (markerNo == 12)
        {
            marker.transform.position = waypoint13.transform.position;
        }
    }

    IEnumerator OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "racer")
        {
            this.GetComponent<BoxCollider>().enabled = false;
            markerNo += 1;
            if (markerNo == 12)
            {
                markerNo = 0;
            }
            yield return new WaitForSeconds(1);
            this.GetComponent<BoxCollider>().enabled = true;
        }
    }
}
