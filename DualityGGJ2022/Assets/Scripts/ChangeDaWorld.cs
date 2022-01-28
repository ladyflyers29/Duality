using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeDaWorld : MonoBehaviour
{
    public GameObject bright;
    public GameObject dark;

    public GameObject brightcamera;
    public GameObject darkcamera;

    public AudioSource brightMusic;
    public AudioSource darkMusic;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (bright.activeSelf == true)
            {
                bright.SetActive(false);
                dark.SetActive(true);
                brightcamera.SetActive(false);
                darkcamera.SetActive(true);
                brightMusic.Play();
                darkMusic.Pause();
            }

            else if (bright.activeSelf == false)
            {
                bright.SetActive(true);
                dark.SetActive(false);
                brightcamera.SetActive(true);
                darkcamera.SetActive(false);
                brightMusic.Pause();
                darkMusic.Play();
            }
        }
    }
}
