using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // access to text mesh pro stuff
using UnityEngine.SceneManagement;

public class FlappybirdUI : MonoBehaviour
{
    public TMP_Text coinsCollected; // text variable
    public FlappybirdPlayer player; // access to coin
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        coinsCollected.text = player.coinsCollected.ToString(); // update the coins
    }

    public void ReplayLevel()
    {
        SceneManager.LoadScene(2);
    }

    public void BackToHub()
    {
        SceneManager.LoadScene(0);
    }
}
