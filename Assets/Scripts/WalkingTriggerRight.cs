using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingTriggerRight : MonoBehaviour
{
    public bool walkingColliderDetectorRight = false;

    private void OnTriggerEnter(Collider other)
    {
        walkingColliderDetectorRight = true;
    }

    void OnTriggerExit(Collider other)
    {
        walkingColliderDetectorRight = false;
    }
}
