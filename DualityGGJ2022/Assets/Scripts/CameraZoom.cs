using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{    
//    public Animator anim;
    public Animation anim1;
    public GameObject playerController;
    // Start is called before the first frame update
    void Start()
    {
//        anim = gameObject.GetComponent<Animator>();
        anim1 = gameObject.GetComponent<Animation>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) //if "E" is pressed
        {
            Debug.Log("animation play");
            anim1.Play("CameraZoomEffect");
//            anim.Play("CameraZoomEffect");
        } 
    }
}
