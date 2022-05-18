using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreController : MonoBehaviour
{
    public int scorePlayer1 = 0;
    // private int scorePlayer2 = 0;

    public GameObject scoreTextPlayer1;
    // public GameObject scoreTextPlayer2;

    private BallMovement ballMovement;

    public int goalToWin;

    void Update()
    {
        if (this.scorePlayer1 >= this.goalToWin)
        {
            Debug.Log("Game Won!");
            StartCoroutine(EndGame());
        }

    }

    private void FixedUpdate()
    {
        TextMeshProUGUI uiScorePlayer1 = this.scoreTextPlayer1.GetComponent<TextMeshProUGUI>();
        uiScorePlayer1.text = this.scorePlayer1.ToString();

    }

    public void GoalPlayer1()
    {
        this.scorePlayer1 = this.scorePlayer1 + 20;
    }

    public IEnumerator EndGame()
    {
        yield return new WaitForSeconds(1);
        // ballMovement.PositionBall(true);
        SceneManager.LoadScene("GameOver");
        
    }

}
