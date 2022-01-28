using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideUnhideButton : MonoBehaviour
{
    public GameObject item1;
    public GameObject item2;

    public int OneStay2Enter = 1;

    public AudioSource buttonSound;


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
                    if (item1.activeSelf == true)
                    {
                        item1.SetActive(false);
                        item2.SetActive(true);
                        buttonSound.Play();
                    }

                    else if (item1.activeSelf == false)
                    {
                        item1.SetActive(true);
                        item2.SetActive(false);
                        buttonSound.Play();
                    }

                }

                

            }
            if (OneStay2Enter == 2 && other.gameObject.tag == "ball" && other.gameObject.tag != "Player")
            {
                item1.SetActive(false);
                item2.SetActive(true);
            }

            // Update other objects position and rotation

            // thing.transform.rotation = Destination.transform.rotation;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "ball")
        {
            if (OneStay2Enter == 2)
            {
                if (item1.activeSelf == true)
                {
                    item1.SetActive(false);
                    item2.SetActive(true);
                    buttonSound.Play();
                }
            }

        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "ball" )
        {
            if (OneStay2Enter == 2)
            {
                if (item1.activeSelf == false)
                {
                    item1.SetActive(true);
                    item2.SetActive(false);
                }
            }
            

        }
    }
}
