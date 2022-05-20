using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlantsManager : MonoBehaviour
{
    public int suns; // currancy for our game

    public Plant plantToPlace; // this will be the plant we want to place
    public CustomCursor customCursor; // access to the cursor
    public Tile[] tiles; // array of all of our tiles

    public Text sunDisplay; // text to display how much sun we have
    public LayerMask sunlayer;
    public GameObject GameOverCanvas;
    // Start is called before the first frame update
    void Start()
    {
        customCursor.gameObject.SetActive(false); // hide the cursor
        GameOverCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        sunDisplay.text = suns.ToString();
        if(Input.GetMouseButtonDown(0) && plantToPlace != null) // placing the plant, assuming we clicked on one to build
        {
            Tile nearestTile = null; // this tile will be the nearest tile to our left click
            float nearestDistance = float.MaxValue; // this is going to be the neasest distance of that tile

            foreach (Tile tile in tiles) // loop through all of our tiles in our tiles array
            {
                // find our distance between all the tiles and our mouse position
                float distance = Vector2.Distance(tile.transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition));
                if(distance < nearestDistance) // find the closest tile/ the one our mouse is over
                {
                    nearestDistance = distance;
                    nearestTile = tile;
                }
            }
            if(nearestTile.isOccupied == false) // is the tile unoccupied
            {
                Plant newPlant = Instantiate(plantToPlace, nearestTile.transform.position, Quaternion.identity); // spawn the plant
                newPlant.tile = nearestTile; // set the tile we placed plant on, to its tile
                plantToPlace = null; // now that we placed plant, make this null
                nearestTile.isOccupied = true; // filp the tile to be occupied
                Cursor.visible = true; // show cursor
                customCursor.gameObject.SetActive(false); // hide custom cursor
            }
        }

        if(Input.GetMouseButtonDown(0) && plantToPlace == null)
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector3.forward, Mathf.Infinity, sunlayer);
            if (hit.collider == null)
            {
                return; // if we click on nothing, stop doing the rest of the stuff
            }

            if (hit.collider.GetComponent<Sun>())
            {
                suns += hit.collider.GetComponent<Sun>().increaseSunAmount; // increase our suns
                Destroy(hit.collider.gameObject); // destroy the sun
            }
        }
    }

    public void BuyPlant(Plant plant) // how we buy our plants. each button will know what plant they want to build
    {
        if(suns >= plant.cost) // make sure we can afford it
        {
            customCursor.gameObject.SetActive(true); // make cursor visible
            customCursor.GetComponent<SpriteRenderer>().sprite = plant.GetComponent<SpriteRenderer>().sprite; // set the sprite
            Cursor.visible = false; // hide default cursor

            suns -= plant.cost; // paying the cost
            plantToPlace = plant; // making sure the plant we place is the plant from the button
        }
    }
}
