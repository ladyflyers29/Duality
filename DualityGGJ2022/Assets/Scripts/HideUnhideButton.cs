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
    public GameObject item1;
    public GameObject item2;

    public int OneStay2Enter = 1; //1 = button 2 = pressure plate

    public AudioSource buttonSound;

    

    
    public void OnTriggerEnter(Collider other)
    {
        if (OneStay2Enter != 2) return;
        Debug.Log(other);
        if (other.gameObject.tag == "ball")
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
        if (other.gameObject.tag == "ball" )
        {
            foreach( ThingToTurnOff t in allThings ) {
                if (t.gameObject != null) {
                    t.gameObject.SetActive(!t.turnOff);
                }
            }

        }
    }
}
