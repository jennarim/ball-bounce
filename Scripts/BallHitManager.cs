using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallHitManager : MonoBehaviour
{
    public AudioSource source;
    public AudioClip sound;

    public void OnMouseDown()
    {
        GameObject.Find("GameManager").GetComponent<GameManager>().ScoreUp();
        Destroy(gameObject);
        source.PlayOneShot(sound);
    }
}
