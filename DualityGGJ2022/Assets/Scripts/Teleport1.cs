using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport1 : MonoBehaviour
{
    public Transform Destination;


   

 

    public void OnTriggerEnter(Collider other)
    {

       
        // If the tag of the colliding object is allowed to teleport
        if (other.gameObject.tag == "ball" || other.gameObject.tag == "Player")
        {
           
                other.transform.position = Destination.transform.position;
                other.transform.rotation = Destination.transform.rotation;
            

            // Update other objects position and rotation

        }
    }


    public void OnTriggerStay(Collider other)
    {

        
        // If the tag of the colliding object is allowed to teleport
        if (other.gameObject.tag == "ball" || other.gameObject.tag == "Player")
        {
            
                other.transform.position = Destination.transform.position;
                other.transform.rotation = Destination.transform.rotation;

            
        }
    }
}
