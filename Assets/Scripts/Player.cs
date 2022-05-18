using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    public float movementSpeed;
    public ScoreController scoreController;
    
    private void FixedUpdate()
    {
        float v = Input.GetAxisRaw("Horizontal");
        GetComponent<Rigidbody2D>().velocity = new Vector2(v, 0) * movementSpeed;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "Player2")
        {
            scoreController.scorePlayer1 = scoreController.goalToWin;
        }
    }
}
