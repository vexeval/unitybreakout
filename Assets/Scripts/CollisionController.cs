using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionController : MonoBehaviour
{
    public BallMovement ballMovement;
    public ScoreController scoreController;
    
    void BounceFromRacket(Collision2D c)
    {
        Vector3 ballPosition = this.transform.position;
        Vector3 playerPosition = c.gameObject.transform.position;

        float playerHeight = c.collider.bounds.size.x;
        float x = (ballPosition.x = playerPosition.x) / playerHeight;
        float y;
        if (c.gameObject.name == "Player")
        {
            y = 1;
        }
        else if (c.gameObject.name == "Block")
        {
            Destroy(c.gameObject);
            y = -1;
        }
        else
        {
            y = -1;
        }

        

        this.ballMovement.IncreaseHitCount();
        this.ballMovement.MoveBall(new Vector2(x, y));

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            this.BounceFromRacket(collision);
        }
        else if (collision.gameObject.name == "Block")
        {
            Debug.Log("Player Got a Point!");
            this.BounceFromRacket(collision);
            scoreController.GoalPlayer1();

            // this.scoreController.GoalPlayer2();
            // StartCoroutine(this.ballMovement.startBall(true));
        }
        else if (collision.gameObject.name == "WallBottom")
        {
            Debug.Log("Ball hit floor!");
            // this.scoreController.GoalPlayer2();
            StartCoroutine(this.ballMovement.startBall(true));
        }

    }
}
