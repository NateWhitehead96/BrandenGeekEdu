using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlantButton : MonoBehaviour
{
    public Button self; // the button references itself so we can make it interactable or not
    // Start is called before the first frame update
    void Start()
    {
        self = GetComponent<Button>(); // this script will always get the button component
    }

    public void SelectedPlant()
    {
        if(FindObjectOfType<PlantSelector>().plantsChosen.Count < 4) // only the first 4 will be not interactable
            self.interactable = false; // when this button is clicked, it wont be clickable anymore
    }
}
