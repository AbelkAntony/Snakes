using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public int score;
    [SerializeField] Text scoreText;

    private void Start()
    {
        ResetScore();
    }

    public void ResetScore()
    {
        this.score = 0;
        scoreText.text = score.ToString();
    }

    public void AddScore()
    {
        this.score++;
        scoreText.text = score.ToString();


    }
}
