using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public bool isPlayer1Goal;

    public AudioSource scoreSound;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            scoreSound.Play();
            if (isPlayer1Goal)
            {
                GameObject.Find("GameManager").GetComponent<GameManager>().Player2Scored();
            } else
            {
                GameObject.Find("GameManager").GetComponent<GameManager>().Player1Scored();
            }
        }
    }
}
