using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingTriggerRightEnemy : MonoBehaviour
{
    public bool walkingColliderDetectorRightEnemy = false;

    private void OnTriggerEnter(Collider other)
    {
        walkingColliderDetectorRightEnemy = true;
    }

    void OnTriggerExit(Collider other)
    {
        walkingColliderDetectorRightEnemy = false;
    }
}
