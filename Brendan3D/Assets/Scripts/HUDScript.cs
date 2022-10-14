using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDScript : MonoBehaviour
{
    public Text healthText;
    public Text ammoText;
    public Text cashText;
    public Text waveText;

    public PlayerStats player;
    public EnemySpawner spawner;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerStats>();
        
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = "Health: " + player.health; // display health
        ammoText.text = "Ammo: " + player.currentGun.ammo + " / " + player.currentGun.maxAmmo; // display ammo
        cashText.text = "Cash: $" + player.money; // display money
        waveText.text = "Wave: " + spawner.wave; // display wave
    }
}
