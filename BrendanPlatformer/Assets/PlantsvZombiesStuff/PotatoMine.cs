using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotatoMine : MonoBehaviour
{
    public Plant self; // this is to know about the tile its occupying

    public LayerMask zombieLayer;
    public float timer;
    // Start is called before the first frame update
    void Start()
    {
        self = GetComponent<Plant>(); 
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime; // count up our timer
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<Zombie>() && timer >= 3)
        {
            Collider2D[] zombiesInRange = Physics2D.OverlapCircleAll(transform.position, 2, zombieLayer);
            for (int i = 0; i < zombiesInRange.Length; i++)
            {
                zombiesInRange[i].gameObject.GetComponent<Zombie>().health -= 3; // deal 3 damage to all zombies in range
            }
            self.tile.isOccupied = false; // to reopen the tile
            Destroy(gameObject); // destroy the mine
        }
    }
}
