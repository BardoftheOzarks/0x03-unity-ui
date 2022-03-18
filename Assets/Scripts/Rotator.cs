using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float SpinSpeed = 45f;
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(SpinSpeed * Time.deltaTime, 0, 0);
    }
}
