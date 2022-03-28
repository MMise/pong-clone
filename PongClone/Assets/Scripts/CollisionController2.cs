using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionController2 : MonoBehaviour
{
    public BallScript ballScript;
    public ScoreController scoreController;

    private string lastObjectHit;

    void BounceFromRacket(Collision2D collision)
    {
        Vector2 ballPosition = transform.position;
        Vector2 racketPosition = collision.gameObject.transform.position;

        float racketHeight = collision.collider.bounds.size.y;
        float x;

        if (collision.gameObject.name == "RacketPlayer")
        {
            x = 1f;
        }
        else
        {
            x = -1f;
        }

        float y = (ballPosition.y - racketPosition.y) / racketHeight;
        ballScript.IncrementHit();
        ballScript.MoveBall(new Vector2(x, y));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        string objectName = collision.gameObject.name;

        if (objectName.Equals(lastObjectHit))
        {
            return;
        }

        if(objectName == "RacketPlayer" || objectName == "RacketAI")
        {
            BounceFromRacket(collision);
            lastObjectHit = objectName;
        }
        else if (objectName == "WallLeft")
        {
            scoreController.IncrementAIPoints();
            lastObjectHit = string.Empty;
            StartCoroutine(ballScript.StartBall(true));
        }
        else if (objectName == "WallRight")
        {
            scoreController.IncrementPlayerPoints();
            lastObjectHit = string.Empty;
            StartCoroutine(ballScript.StartBall(false));
        }
    }
}
