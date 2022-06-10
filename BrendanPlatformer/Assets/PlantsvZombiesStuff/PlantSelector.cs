using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlantSelector : MonoBehaviour
{
    public List<Plant> plantsChosen; 
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject); // make sure this comes to the next scene with us
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SelectPlant(Plant plant)
    {
        if(plantsChosen.Count < 4) // if we have less than 4 plants, add this one we clicked to our plants chosen
        {
            plantsChosen.Add(plant);
        }
    }

    public void PlayGame()
    {
        if(plantsChosen.Count == 4)
        {
            SceneManager.LoadScene("PlantsvZombie"); // load the scene
        }
    }
}
