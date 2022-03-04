using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public Text CoinText; // the text for our coin
    public Image HeartOne;
    public Image HeartTwo;
    public Image HeartThree;
    // sprites for our health
    public Sprite FullHeart;
    public Sprite EmptyHeart;

    public Player player; // access to player to know coin amount and health amount
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CoinText.text = player.coins.ToString();

        if(player.health == 3) // at full health
        {
            HeartOne.sprite = FullHeart;
            HeartTwo.sprite = FullHeart;
            HeartThree.sprite = FullHeart;
        }
        if(player.health == 2) // lost 1 health
        {
            HeartOne.sprite = FullHeart;
            HeartTwo.sprite = FullHeart;
            HeartThree.sprite = EmptyHeart;
        }
        if(player.health == 1)
        {
            HeartOne.sprite = FullHeart;
            HeartTwo.sprite = EmptyHeart;
            HeartThree.sprite = EmptyHeart;
        }
        if(player.health == 0) // optional but for playtesting
        {
            // normally we'd die
            HeartOne.sprite = EmptyHeart;
            HeartTwo.sprite = EmptyHeart;
            HeartThree.sprite = EmptyHeart;
        }
    }
}
