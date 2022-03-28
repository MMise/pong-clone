using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    private const float EXTRA_SPEED_PER_HIT = 20f;
    private const float MAX_EXTRA_SPEED = 1000f;
    private const float START_SPEED = 400f;

    private float movementSpeed = START_SPEED;
    private int hitCounter = 0;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartBall());
    }

    public IEnumerator StartBall(bool isStartingPlayer1 = true)
    {
        PositionBall(isStartingPlayer1);

        hitCounter = 0;
        yield return new WaitForSeconds(2);
        if (isStartingPlayer1)
        {
            MoveBall(new Vector2(-1f, 0f));
        }
        else
        {
            MoveBall(new Vector2(1f, 0f));
        }
    }

    public void MoveBall(Vector2 direction)
    {
        direction = direction.normalized;

        float speed = movementSpeed + hitCounter * EXTRA_SPEED_PER_HIT;

        Rigidbody2D body = this.gameObject.GetComponent<Rigidbody2D>();
        body.velocity = direction * speed;
    }

    public void IncrementHit()
    {
        if(hitCounter * EXTRA_SPEED_PER_HIT <= MAX_EXTRA_SPEED)
        {
            hitCounter++;
            Debug.Log("Hitcounter :" + hitCounter);
        }
    }

    private void PositionBall(bool isPlayerOneStarting)
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);

        if (isPlayerOneStarting)
        {
            gameObject.transform.localPosition = new Vector2(-100f, 0f);
        }
        else
        {
            gameObject.transform.localPosition = new Vector2(100f, 0f);
        }
    }
}
