using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    private void Start()
    {
        this.transform.position = gameManager.RandomizePosition();
    }


    private void OnTriggerEnter2D(Collider2D other)
    {

        if(other.tag == "Player")
        {
            this.transform.position = gameManager.RandomizePosition();
        }
    }


}
