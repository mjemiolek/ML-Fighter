using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyBehaviour : MonoBehaviour
{
    public animationStateController animatorscript;
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
        //if(Input.GetKey(KeyCode.RightArrow))
        //{
        //    if (animatorscript.animator.GetCurrentAnimatorStateInfo(0).IsName("cios") || animatorscript.animator.GetCurrentAnimatorStateInfo(0).IsName("blok"))
        //    {
        //        //allowed on action
        //    } 
        //    else
        //    {
        //        //not allowed on action
        //        Player.transform.Translate(-speed * Time.deltaTime, 0, 0);
        //    }
        //}

        //if (Input.GetKey(KeyCode.LeftArrow))
        //{
        //    if (animatorscript.animator.GetCurrentAnimatorStateInfo(0).IsName("cios") || animatorscript.animator.GetCurrentAnimatorStateInfo(0).IsName("blok"))
        //    {
        //        //allowed on action
        //    }
        //    else
        //    {
        //        //not allowed on action
        //        Player.transform.Translate(speed * Time.deltaTime, 0, 0);
        //    }
        //}
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