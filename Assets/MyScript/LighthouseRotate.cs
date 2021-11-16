using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LighthouseRotate : MonoBehaviour
{
    [SerializeField]
    GameObject LHObject;
    [SerializeField]
    float RotateSpeed = 0.1f;

    // Update is called once per frame
    void Update()
    {
        LHObject.transform.Rotate(0, RotateSpeed, 0, Space.World);
    }
}
