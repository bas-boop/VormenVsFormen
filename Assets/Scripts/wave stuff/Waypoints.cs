using UnityEngine;
using System.Linq;
using System.Collections.Generic;

public class Waypoints : MonoBehaviour
{
    public static Transform[] points;
    public static List<Transform> waypoints = new List<Transform>();

    void Awake()
    {
        GameObject waypointParent = GameObject.Find("Waypoints");

        for (int i = 0; i < waypointParent.transform.childCount; i++)
        {
            waypoints.Add(waypointParent.transform.GetChild(i));
        }
    }

    public List<Transform> GetWaypoints()
    {
        return waypoints;
    }
}
