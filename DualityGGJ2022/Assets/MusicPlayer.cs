using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    [SerializeField] AudioClip musicTrack;
    [SerializeField] float smoothChangeMusic;
    AudioSource source;
    float speedGoal = 1f;

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        ChangeDaWorld.OnWorldSwitch += OnSwitch;
    }

    void Update() {
        source.pitch = Mathf.Lerp( source.pitch, speedGoal, Time.deltaTime * smoothChangeMusic);
    }

    void OnSwitch() {
        speedGoal = ChangeDaWorld.isDarkWorld ? -1f : 1f;
    }
}
