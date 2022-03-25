using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // the instace of the manager
    public int LevelsBeaten; // keep track of what levels the player has beaten
    public int Coins; // keep track of our coins
    private void Awake()
    {
        if(instance != null) // if there's already a game manager
        {
            Destroy(gameObject); // destroy this one
        }
        else // else make this game manager go with us to every scene
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
