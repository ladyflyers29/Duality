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

    public GameObject brightWorld; //parent object that holds bright world objects
    public GameObject darkWorld; //parent object that hold dark world objects

    public Animator anim;
    public GameObject playerController;

   // public GameObject brightcamera;
   // public GameObject darkcamera;

    public AudioSource brightMusic;
    public AudioSource darkMusic;
    GameObject[] lightWorldOnly = new GameObject[0];
    GameObject[] darkWorldOnly = new GameObject[0];

    void Awake() {
        lightWorldOnly = GameObject.FindGameObjectsWithTag(LIGHTWORLDONLY);
        darkWorldOnly = GameObject.FindGameObjectsWithTag(DARKWORLDONLY);
        
        if (daWorld != null) throw new System.Exception("More than one "+nameof(ChangeDaWorld)+" OH NOES");
        daWorld = this;
        ChangeDaWorld.OnWorldSwitch += DoWhenWorldSwitches; // this adds a listener to the world switch event
        DoWhenWorldSwitches(); // run this right away to hide darkworld tagged stuff
        anim = playerController.GetComponent<Animator>();
    }

    // Turn off all gameobjects with 'LightWorldOnly' tag if 'isDarkWorld' is set to true, and vice-versa
    void DoWhenWorldSwitches() {
        foreach( GameObject g in lightWorldOnly ) {
            g?.SetActive(!isDarkWorld);
        }
        foreach( GameObject g in darkWorldOnly ) {
            g?.SetActive(isDarkWorld);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) //if "E" is pressed
        {
            anim.Play("Camera Zoom Effect");
            isDarkWorld = !isDarkWorld;
            ChangeDaWorld.OnWorldSwitch.Invoke(); // this calls the world switch event

            if (brightWorld == null || darkWorld == null) return; // early-exit here if there is no bright or dark world
            if (brightWorld.activeSelf == true) //switching from bright world to dark world
            {
                brightWorld?.SetActive(false);
                darkWorld?.SetActive(true);
               // brightcamera?.SetActive(false);
                //darkcamera?.SetActive(true);
                brightMusic?.Play();
                darkMusic?.Pause();
            }

            else if (brightWorld.activeSelf == false) //switching from dark world to bright world
            {
                brightWorld?.SetActive(true);
                darkWorld?.SetActive(false);
              //  brightcamera?.SetActive(true);
               // darkcamera?.SetActive(false);
                brightMusic?.Pause();
                darkMusic?.Play();
            }
        }
    }
}
