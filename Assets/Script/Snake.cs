using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    private Vector2 _direction = Vector2.right;

    private List<Transform> _segments;

    private float activeTime = 5f;

    private bool passThrough = false;

    private bool scoreKillIsActive = false;

    [SerializeField] GameManager gameManager;
    [SerializeField] Transform segmantPrefab;
    [SerializeField] OrbController orb;
    private void Start()
    {
        Time.timeScale = 1f ;
        _segments = new List<Transform>();
        _segments.Add(this.transform);
    }

    private void Update()
    {

        if((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))&& _direction != Vector2.down)
        {
            _direction = Vector2.up;
        }
        else if((Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) && _direction != Vector2.up)
        {
            _direction = Vector2.down;
        }
        else if ((Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))&& _direction != Vector2.left)
        {
            _direction = Vector2.right;
        }
        else if ((Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) && _direction != Vector2.right)
        {
            _direction = Vector2.left;
        }
        if(Time.time > activeTime)
        {
            ResetOrb();
        }
    }

    private void FixedUpdate()
    {
            
            for (int i = _segments.Count - 1; i > 0; i--)
            {
                _segments[i].position = _segments[i - 1].position;
            }

            this.transform.position = new Vector3(Mathf.Round(this.transform.position.x) + _direction.x, Mathf.Round(this.transform.position.y) + _direction.y, 0.0f);

     
    }

    private void Grow()
    {
        Transform segment =  Instantiate(this.segmantPrefab);
        segment.position = _segments[_segments.Count - 1].position;

        _segments.Add(segment);
    }

    private void ResetState()
    {
        for (int i=1; i< _segments.Count; i++)
        {
            Destroy(_segments[i].gameObject);
        }

        _segments.Clear();
        _segments.Add(this.transform);

        this.transform.position = Vector3.zero;
        this.gameManager.ResetScore();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Food")
        {
            Grow();
            gameManager.AddScore(scoreKillIsActive);
        }
        else if(other.tag == "Player")
        {
            if (passThrough) { }
            else 
                ResetState();
        }
        else if(other.name == "Speed Orb")
        {
            Time.timeScale = 2f;
            activeTime = Time.time + 5f;
            orb.OrbStatus(1,false);
        }
        else if(other.name == "Pass Through Orb")
        {
            activeTime = Time.time + 5f;
            passThrough = true;
            orb.OrbStatus(2, false);
        }
        else if(other.name == "Score Kill Orb")
        {
            activeTime = Time.time + 5f;
            scoreKillIsActive = true;
            orb.OrbStatus(3, false);
        }
    }
    void ResetOrb()
    {
        scoreKillIsActive = false;
        passThrough = false;
        Time.timeScale = 1f;
    }
}
