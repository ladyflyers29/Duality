using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeDaWorld : MonoBehaviour
{
    public GameObject brightWorld; //parent object that holds bright world objects
    public GameObject darkWorld; //parent object that hold dark world objects

    public GameObject brightcamera;
    public GameObject darkcamera;

    public AudioSource brightMusic;
    public AudioSource darkMusic;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) //if "E" is pressed
        {
            if (brightWorld.activeSelf == true) //switching from bright world to dark world
            {
                brightWorld.SetActive(false);
                darkWorld.SetActive(true);
                brightcamera.SetActive(false);
                darkcamera.SetActive(true);
                brightMusic.Play();
                darkMusic.Pause();
            }

            else if (brightWorld.activeSelf == false) //switching from dark world to bright world
            {
                brightWorld.SetActive(true);
                darkWorld.SetActive(false);
                brightcamera.SetActive(true);
                darkcamera.SetActive(false);
                brightMusic.Pause();
                darkMusic.Play();
            }
        }
    }
}
