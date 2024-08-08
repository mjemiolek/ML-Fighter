using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingTriggerLeft : MonoBehaviour
{
    public bool walkingColliderDetectorLeft = false;

    private void OnTriggerEnter(Collider other)
    {
        walkingColliderDetectorLeft = true;
    }

    void OnTriggerExit(Collider other)
    {
        walkingColliderDetectorLeft = false;
    }
}
