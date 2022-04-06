using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Transform player;
    public Text scoreText;


    void Update()
    {
        int newScore = Mathf.FloorToInt(player.position.y * 7);
        if(newScore > int.Parse(scoreText.text))   
            scoreText.text = newScore.ToString();
    }
}
