using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public int score;


    private void Start()
    {
        ResetScore();
    }

    public void ResetScore()
    {
        this.score = 0;
    }

    public void AddScore()
    {
        this.score++;
    }


}
