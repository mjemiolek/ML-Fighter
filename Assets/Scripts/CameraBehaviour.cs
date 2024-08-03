using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    public GameObject Cam;
    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Cam.transform.position = new Vector3(Player.transform.position.x+3, Cam.transform.position.y, Cam.transform.position.z);
    }
}
