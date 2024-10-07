using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    [SerializeField] private bool isAI;
    [SerializeField] private GameObject ball; //is used by AI to move in corespondes to the ball

    private Rigidbody2D rb;
    private Vector2 playermove;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isAI)
        {
            AIControl();
        }
        else
        {
            PlayerControl();
        }
    }
    private void PlayerControl()
    {
        playermove = new Vector2(0, Input.GetAxisRaw("Vertical"));
    }

    private void AIControl()
    {
        if(ball.transform.position.y > transform.position.y + 0.5f)
        {
            playermove = new Vector2(0, 1);
        }
        else if(ball.transform.position.y < transform.position.y - 0.5f)
        {
            playermove = new Vector2(0, -1);
        }
        else
        {
            playermove = new Vector2(0, 0);
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = playermove * movementSpeed;
    }
}

