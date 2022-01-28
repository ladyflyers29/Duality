using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveback : MonoBehaviour
{
    public static int movespeed = 1;
    public Vector3 userDirection = Vector3.right;

    public void Update()
    {
        transform.Translate(userDirection * movespeed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "blockTag")
        {
            if (movespeed == 1)
            {
                movespeed = -1;
            }

            else if (movespeed == -1)
            {
                movespeed = 1;
            }
            //set velocity 0
            //adjust the object position (the object may overlap with the block)
        }
    }
}
