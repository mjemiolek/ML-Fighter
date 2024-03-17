using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerBehaviour : MonoBehaviour
{
    public GameObject Player;
    public float speed;
    public bool punchArea;

    // Start is called before the first frame update
    void Start()
    {
        punchArea = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.A))
        {
            Player.transform.Translate(-speed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            Player.transform.Translate(speed * Time.deltaTime, 0, 0);
        }
    }


    void OnTriggerEnter(Collider other)
    {
        punchArea = true;
    }

    void OnTriggerExit(Collider other)
    {
        punchArea = false;
    }


}
