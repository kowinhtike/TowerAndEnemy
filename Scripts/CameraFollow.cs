using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public Vector3 vector;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        vector = player.position;
        transform.position = new Vector3(vector.x + 3, vector.y + 8, vector.z - 13);
    }
}
