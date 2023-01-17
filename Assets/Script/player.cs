using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    GameController g;
    public float jumpForce;
    Rigidbody2D m_rb;
    bool m_isGround;
    // Start is called before the first frame update
    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
        g = FindObjectOfType<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        bool isJumpKeyPressed = Input.GetKeyDown(KeyCode.Space);
        if (Input.GetKeyDown(KeyCode.Space) && m_isGround)
        {
            m_rb.AddForce(Vector2.up * jumpForce);
            m_isGround = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ground"))
        {
            m_isGround = true;
        }
        else if (col.gameObject.CompareTag("Obstacle"))
        {
            g.GetGameOver(true);
        }
       
    }
   
}
