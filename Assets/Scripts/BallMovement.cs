using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float movementSpeed;
    public float speedMultiplier;
    public float maxMultiplier;
    public int hitCount = 0;

    void Start()
    {
        StartCoroutine(this.startBall());
    }

    public void MoveBall(Vector2 dir)
    {
        dir = dir.normalized;
        float speed = this.movementSpeed + this.hitCount * speedMultiplier;
        Rigidbody2D rb = this.gameObject.GetComponent<Rigidbody2D>();
        rb.velocity = dir * speed;

    }

    public IEnumerator startBall(bool isStartingPlayer1 = true)
    {
        this.PositionBall(isStartingPlayer1);
        this.hitCount = 0;
        yield return new WaitForSeconds(2); 

        if (isStartingPlayer1)
        {
            this.MoveBall(new Vector2(0, -1));
        }
        // else
        // {
        //     this.MoveBall(new Vector2(0, -1));
        // }
    }

    public void IncreaseHitCount()
    {
        if (this.hitCount * this.speedMultiplier <= this.maxMultiplier)
        {
            this.hitCount++;
        }
    }

    public void PositionBall(bool isStartingPlayer1)
    {
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
        this.gameObject.transform.localPosition = new Vector3(0, 0, 0);
        
        // if (isStartingPlayer1)
        // {
            
        // }
        // else
        // {
        //     this.gameObject.transform.localPosition = new Vector3(100, 0, 0);
        // }
    }

}
