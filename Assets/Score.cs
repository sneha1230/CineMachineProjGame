using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text scoreText;
    // Start is called before the first frame update
    public int score = 100;
    public void DecrementScore()
    {

        score = score - 5;
        scoreText.text = "Score:" + score;

    }
}
