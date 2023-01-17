using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    GameController game;
    public float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        game = FindObjectOfType<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        if((float)game.GetScore() < 10) {
            transform.position = transform.position + Vector3.left * moveSpeed
* Time.deltaTime;
        }
        else
        {
            transform.position = transform.position +
                (1 + (float)game.GetScore() / 100)
                * Vector3.left * moveSpeed
                * Time.deltaTime;
        }
        
        
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("SceneLimit"))
        {
            game.ScoreIncrease();
            Destroy(gameObject);
        }
    }
}
