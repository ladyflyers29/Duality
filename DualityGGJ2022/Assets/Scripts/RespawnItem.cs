using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnItem : MonoBehaviour
{
    public Transform Destination;
    public GameObject thing;

    public int OneStay2Enter = 1;

    public AudioSource buttonsound;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "ball")
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (OneStay2Enter == 1)
                {
                    thing.transform.position = Destination.transform.position;
                    buttonsound.Play();
                }

              

            }

            if (OneStay2Enter == 2 && other.gameObject.tag == "ball" && other.gameObject.tag != "Player")
            {
                thing.transform.position = Destination.transform.position;
            }
            
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "ball")
        {

            if (OneStay2Enter == 2)
            {
                thing.transform.position = Destination.transform.position;
                buttonsound.Play();
            }

            // Update other objects position and rotation

            // thing.transform.rotation = Destination.transform.rotation;
        }
    }
}
