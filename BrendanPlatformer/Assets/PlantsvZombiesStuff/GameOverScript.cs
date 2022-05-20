using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScript : MonoBehaviour
{
    public Text display; // the text we display

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        display.text = "You made it to wave " + FindObjectOfType<ZombieSpawner>().wave;
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene("PlantsvZombie");
        
    }
}
