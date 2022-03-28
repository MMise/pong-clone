using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ScoreController : MonoBehaviour
{
    private int playerPoints;
    private int aiPoints;

    public GameObject playerScoreText;
    public GameObject aiScoreText;

    private const int POINTS_TO_WIN = 5;

    private void Update()
    {
        if(playerPoints == POINTS_TO_WIN || aiPoints == POINTS_TO_WIN)
        {
            SceneManager.LoadScene("EndScene");
        }
    }

    private void FixedUpdate()
    {
        playerScoreText.GetComponent<TMP_Text>().text = playerPoints.ToString();
        aiScoreText.GetComponent<TMP_Text>().text = aiPoints.ToString();
    }

    public void IncrementPlayerPoints()
    {
        playerPoints++;
    }

    public void IncrementAIPoints()
    {
        aiPoints++;
    }
}
