using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // the instace of the manager
    public int[] DoorsUnlocked; // an array of which doors are unlocked
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
        LoadGame(); // everytime we play, load our game
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SaveGame()
    {
        PlayerPrefs.SetInt("Coins", Coins); // save whatever amount of coins we collected
        for (int i = 0; i < DoorsUnlocked.Length; i++)
        {
            PlayerPrefs.SetInt("Door" + i, DoorsUnlocked[i]); // saving each door/portal unlock
        }
    }
    public void LoadGame()
    {
        if (PlayerPrefs.HasKey("Coins")) // check if we have any save data, coins should be in there is we do
        {
            Coins = PlayerPrefs.GetInt("Coins"); // load the coins number to our coin variable
            for (int i = 0; i < DoorsUnlocked.Length; i++)
            {
                DoorsUnlocked[i] = PlayerPrefs.GetInt("Door" + i); // load which doors are open. open will = 1 closed = 0
            }
        }
    }
}
