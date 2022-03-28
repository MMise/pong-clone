using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public AudioSource wallSound;
    public AudioSource racketSound;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        string objectName = collision.gameObject.name;

        if(objectName == "RacketPlayer" || objectName == "RacketAI")
        {
            racketSound.Play();
        }
        else
        {
            wallSound.Play();
        }
    }
}
