using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    public float movementSpeed;
    public ScoreController scoreController;
    
    private void FixedUpdate()
    {
        float v = Input.GetAxisRaw("Horizontal2");
        GetComponent<Rigidbody2D>().velocity = new Vector2(v, 0) * movementSpeed; 
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "Player1")
        {
            scoreController.scorePlayer1 = scoreController.goalToWin;
        }
    }
}
