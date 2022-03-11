using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance; // the instance of this manager

    private void Awake() // happens before start
    {
        if(instance != null) // there's already a sound manager in our game
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this; // means this instance is now this gameobject
            DontDestroyOnLoad(gameObject); // dont destroy this gameobject between scenes
        }
    }
    // the sound effects
    public AudioSource hurtSound;
    public AudioSource pickupSound;
    public AudioSource jumpSound;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
