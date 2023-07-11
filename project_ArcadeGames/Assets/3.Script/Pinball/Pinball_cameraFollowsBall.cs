using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pinball_cameraFollowsBall : MonoBehaviour
{
    [SerializeField] GameObject ball;

    void Start()
    {
        gameObject.transform.position = new Vector3(0, -1f, -10f);
    }

    private void FixedUpdate()
    {
        
        if (ball.transform.position.y - gameObject.transform.position.y >= 2.2f)
        {
            gameObject.transform.position += new Vector3(0f, 0.2f);
        }
        if (ball.transform.position.y - gameObject.transform.position.y <= -1.2f)
        {
            gameObject.transform.position -= new Vector3(0f, 0.2f);
        }

    }
}
