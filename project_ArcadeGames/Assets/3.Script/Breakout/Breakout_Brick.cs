using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakout_Brick : MonoBehaviour
{
    [SerializeField] private Breakout_Ball_move ball;

    private void Start()
    {
        ball = GameObject.FindGameObjectWithTag("ball").GetComponent<Breakout_Ball_move>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ball"))
        {
            ball.Score_up(3);
            Destroy(gameObject);
        }
    }
}
