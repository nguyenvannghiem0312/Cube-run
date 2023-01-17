using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject obstacle;
    public float SpawnTime;
    float m_spawntime;
    bool m_isGameOver;
    int m_score;
    UI m;
    
    // Start is called before the first frame update
    void Start()
    {
        m_spawntime = 0;
        m = FindObjectOfType<UI>();
       
    }

    // Update is called once per frame
    void Update()
    {
        m_spawntime = m_spawntime - Time.deltaTime;
        if (m_isGameOver)
        {
            m_spawntime = 0;
            m.ShowPanel(true);
            return;
        }
        if(m_spawntime <= 0)
        {
            SpawnObstacle();
            m_spawntime = SpawnTime;
        }
    }
    public void SpawnObstacle()
    {
        float randYpos = Random.Range(-2.1f, 0.05f);
        Vector2 spawnPos = new Vector2(13.54f, randYpos);
        if (obstacle)
        {
            Instantiate(obstacle, spawnPos, Quaternion.identity);
        }
    }
    public void RePlay()
    {
        m_score = 0;
        m_isGameOver = false;
        m.SetScoreText("Score:");
        m.ShowPanel(false);
    }
    public void SetScore(int value)
    {
        m_score = value;
    }
    public int GetScore()
    {
        return m_score;
    }
    public void ScoreIncrease()
    {
        if (m_isGameOver)
        {
            return;
        }
        m_score++;
        m.SetScoreText("Score: " + m_score);
    }
    public bool SetGameOver()
    {
        return m_isGameOver;
    }
    public void GetGameOver(bool State)
    {
        m_isGameOver = State;
    }
}
