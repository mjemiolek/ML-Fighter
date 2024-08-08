using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingTriggerLeftEnemy : MonoBehaviour
{
    public bool walkingColliderDetectorLeftEnemy = false;

    private void OnTriggerEnter(Collider other)
    {
        walkingColliderDetectorLeftEnemy = true;
    }

    void OnTriggerExit(Collider other)
    {
        walkingColliderDetectorLeftEnemy = false;
    }
}
