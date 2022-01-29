using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideUnhideButton : MonoBehaviour
{
    /// <summary>
    /// This script is from switch from one version of an object to another
    /// example: item1 = gate up & item2 = gate down
    /// basicly switch states of things
    /// </summary>

    [System.Serializable] public struct ThingToTurnOff {
        [SerializeField] public GameObject gameObject;
        [SerializeField] public bool turnOff;
    }

    [SerializeField] public List<ThingToTurnOff> allThings = new List<ThingToTurnOff>();
    GameObject item1;
    GameObject item2;

    public int OneStay2Enter = 1; //1 = button 2 = pressure plate

    public AudioSource buttonSound;

    public void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "Player" || col.gameObject.tag == "ball")
        {
            if (Input.GetMouseButtonDown(0)) //left click
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
          //  if (OneStay2Enter == 2 && col.gameObject.tag == "ball" && col.gameObject.tag != "Player")
           // {
           //     item1.SetActive(false);
           //     item2.SetActive(true);
         //   }

            // Update other objects position and rotation

            // thing.transform.rotation = Destination.transform.rotation;
        }
    }

    
    public void OnTriggerEnter(Collider other)
    {
        if (OneStay2Enter != 2) return;
        Debug.Log(other);
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "ball")
        {
            buttonSound.Play();
            foreach( ThingToTurnOff t in allThings ) {
                if (t.gameObject != null) {
                    t.gameObject.SetActive(t.turnOff);
                }
            }

        }
    }
    

    public void OnTriggerExit(Collider other)
    {
        if (OneStay2Enter != 2) return;
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "ball" )
        {
            foreach( ThingToTurnOff t in allThings ) {
                if (t.gameObject != null) {
                    t.gameObject.SetActive(!t.turnOff);
                }
            }

        }
    }
}
