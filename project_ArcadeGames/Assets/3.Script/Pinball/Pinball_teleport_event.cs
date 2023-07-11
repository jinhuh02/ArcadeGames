using System.Collections;
using UnityEngine;

public class Pinball_teleport_event : MonoBehaviour
{
    bool start_Event;

    private void Start()
    {
        start_Event = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (start_Event.Equals(false)){
            StartCoroutine(Event_co(collision.gameObject));
        }
    }

    IEnumerator Event_co(GameObject ball)
    {
        Debug.Log("이벤트 실행");
        start_Event = true;
        Rigidbody2D ball_rg = ball.GetComponent<Rigidbody2D>();
        ball_rg.gravityScale = 0;
        ball_rg.velocity = Vector2.zero;

        ball.transform.localScale = new Vector3(0.0601823f, 0.0601823f);
        yield return new WaitForSeconds(0.5f);

        ball.transform.localScale = new Vector3(0f, 0f);
        ball_rg.freezeRotation = true; //회전 중지
        yield return new WaitForSeconds(2);

        ball.transform.position = new Vector2(0.13f, 9.5f);
        ball.transform.localScale = new Vector3(0.1203646f, 0.1203646f);
        ball_rg.gravityScale = 1;
        ball_rg.freezeRotation = false;

        start_Event = false;
        StopCoroutine(Event_co(ball));
        yield break;
    }
}
