using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnItem : MonoBehaviour
{
    /// <summary>
    /// if reset button is pressed gameobjects will respond
    /// </summary>

    public Transform Destination;
    public GameObject thing;

    public int OneStay2Enter = 1; // 1 = button, 2 = pressure plate

    public AudioSource buttonsound;

    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (OneStay2Enter == 1) //button
                {
                    thing.transform.position = Destination.transform.position;
                    buttonsound.Play();
                }

            }

            //if (OneStay2Enter == 2 && other.gameObject.tag == "ball" && other.gameObject.tag != "Player")
            //{
            //    thing.transform.position = Destination.transform.position;
            //}
            
        }
    }

    //public void OnTriggerEnter(Collider other) // pressure plate
    //{
    //    if (other.gameObject.tag == "Player" || other.gameObject.tag == "ball")
    //    {

    //        if (OneStay2Enter == 2)
    //        {
    //            thing.transform.position = Destination.transform.position;
    //            buttonsound.Play();
    //        }

    //        // Update other objects position and rotation

    //        // thing.transform.rotation = Destination.transform.rotation;
    //    }
    //}
}
