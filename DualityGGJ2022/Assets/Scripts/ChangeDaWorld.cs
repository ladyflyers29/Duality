using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeDaWorld : MonoBehaviour
{
    const string LIGHTWORLDONLY = "LightWorldOnly";
    const string DARKWORLDONLY = "DarkWorldOnly";
    public static ChangeDaWorld daWorld { get; private set; } // Global DaWorld access, from any script
    public static bool isDarkWorld { get; private set; }
    public static event Action OnWorldSwitch; // Global thingy that other scripts can listen for

    Transform[] allObjects;

    void Awake() {
        allObjects = GameObject.FindObjectsOfType<Transform>(true);
        
        if (daWorld != null) throw new System.Exception("More than one "+nameof(ChangeDaWorld)+" OH NOES");
        daWorld = this;
        ChangeDaWorld.OnWorldSwitch += DoWhenWorldSwitches; // this adds a listener to the world switch event
        OnWorldSwitch.Invoke();
    }

    // Turn off all gameobjects with 'LightWorldOnly' tag if 'isDarkWorld' is set to true, and vice-versa
    void DoWhenWorldSwitches() {
        if (isDarkWorld) {
            foreach( Transform g in allObjects ) {
                if (g == null) continue;
                if (g.gameObject.tag == LIGHTWORLDONLY) g.gameObject.SetActive(false);
                if (g.gameObject.tag == DARKWORLDONLY) g.gameObject.SetActive(true);
            }
        }
        else {
            foreach( Transform g in allObjects ) {
                if (g == null) continue;
                if (g.gameObject.tag == LIGHTWORLDONLY) g.gameObject.SetActive(true);
                if (g.gameObject.tag == DARKWORLDONLY) g.gameObject.SetActive(false);
            }
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) //if "E" is pressed
        {
            isDarkWorld = !isDarkWorld;
            ChangeDaWorld.OnWorldSwitch.Invoke(); // this calls the world switch event
        }
    }
}
