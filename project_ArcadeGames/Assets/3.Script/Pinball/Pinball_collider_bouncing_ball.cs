using UnityEngine;

public class Pinball_collider_bouncing_ball : MonoBehaviour
{
    [SerializeField] private Rigidbody2D ball_rg;

    [SerializeField] private float speed;

    void Start()
    {
        ball_rg = GameObject.FindGameObjectWithTag("ball").GetComponent<Rigidbody2D>();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (gameObject.CompareTag("Event")){ return; }

        Vector2 ball_current_Pos = collision.transform.position; //Ball의 위치
        Vector2 coll_current_Pos = transform.position; //본인의 위치
        Vector2 coll_pos = ball_current_Pos - coll_current_Pos;

        float direction_x = 0f; //공이 튕길 방향의 x값
        float direction_y = 0f; //공이 튕길 방향의 y값


        if (coll_pos.x > 0) //Ball이 물체의 오른쪽에 있을 경우
        {
            direction_x = 1f; //오른쪽으로 튕김
        }

        if (coll_pos.x < 0) //Ball이 물체의 왼쪽에 있을 경우
        {
            direction_x = -1f; //왼쪽으로 튕김
        }

        if (coll_pos.y > 0) //Ball이 물체의 위에 있을 경우
        {
            direction_y = 1f; //위로 튕김
        }

        if (coll_pos.y < 0) //Ball이 물체의 아래에 있을 경우
        {
            direction_y = -1f; //아래로 튕김
        }


        Vector2 move = new Vector2(direction_x, direction_y);

        ball_rg.velocity = move * speed;
    }
}
