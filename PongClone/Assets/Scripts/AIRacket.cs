using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIRacket : MonoBehaviour
{
    private void FixedUpdate()
    {
        float v = Input.GetAxisRaw("Vertical2");
        GetComponent<Rigidbody2D>().velocity = new Vector2(0f, v) * Constants.RACKET_MOVEMENT_SPEED;
    }
}
