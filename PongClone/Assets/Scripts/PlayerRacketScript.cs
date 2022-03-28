using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRacketScript : MonoBehaviour
{
    private void FixedUpdate()
    {
        float v = Input.GetAxisRaw("Vertical");
        GetComponent<Rigidbody2D>().velocity = new Vector2(0f, v) * Constants.RACKET_MOVEMENT_SPEED;
    }
}
