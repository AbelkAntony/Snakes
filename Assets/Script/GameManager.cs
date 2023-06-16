using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{



    public int score;
    [SerializeField] Text scoreText;
    [SerializeField] BoxCollider2D gridArea;


    private Vector3 randomPosition;
    private void Start()
    {
        ResetScore();
    }

    public void ResetScore()
    {
        this.score = 0;
        scoreText.text = score.ToString();
    }

    public void AddScore(bool scoreKillIsActive)
    {
        if(scoreKillIsActive)
        {
            if(score<2)
                this.score = score - 2;
        }
        else
            this.score++;


        scoreText.text = score.ToString();


    }


    public Vector3 RandomizePosition()
    {
        Bounds bounds = this.gridArea.bounds;

        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);

        randomPosition = new Vector3(Mathf.Round(x), Mathf.Round(y), 0.0f);
        return randomPosition;
    }

    public int GetScore()
    {
        return score;
    }
    public void SetScore(int _score)
    {
        this.score = _score;
    }
}
