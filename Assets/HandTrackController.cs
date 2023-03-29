using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class HandTrackController : MonoBehaviour
{
    public UDPReceive udpReceive;

    public GameObject[] handPoints;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        string data = udpReceive.data;
        //print(data);
        data = data.Remove(0, 1);
        data = data.Remove((data.Length - 1), 1);
        //print(data);
        string[] points = data.Split(',');
        //print(points[0]);


        var point5 = new Vector3(
            float.Parse(points[5 * 3]),
            float.Parse(points[5 * 3 + 1]), 0);

            var point17 = new Vector3(
                float.Parse(points[17 * 3]),
                float.Parse(points[17 * 3 + 1]),
                0);
            
        var depth = Vector2.Distance(point5, point17)/100;
      

        for (int i = 0; i <= 20; i++)
        {
            float x = float.Parse(points[i * 3]) / 100;
            float y = float.Parse(points[i * 3 +1]) / 100;
            float z = float.Parse(points[i * 3+2]) / 100 + depth;
            handPoints[i].transform.localPosition = new Vector3(x, y, z);
        }
        
        Debug.Log(depth);
        
    }
}
    
