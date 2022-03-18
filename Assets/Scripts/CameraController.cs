using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Reference to player object
    public GameObject player;
    // Position in relation to player
    public Vector3 offset;
    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + offset;
    }
}
