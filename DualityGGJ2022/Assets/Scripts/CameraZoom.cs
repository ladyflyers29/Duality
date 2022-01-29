using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{    
    Animation anim1;

    void Start()
    {
        anim1 = gameObject.GetComponent<Animation>();
        ChangeDaWorld.OnWorldSwitch += PlayAnim;
    }

    void PlayAnim()
    {
        anim1.Stop();
        anim1.Play("CameraZoomEffect");
    }
}
