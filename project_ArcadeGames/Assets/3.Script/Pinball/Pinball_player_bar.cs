using UnityEngine;

public class Pinball_player_bar : MonoBehaviour
{
    [SerializeField] private Rigidbody2D ball_rg;
    [SerializeField] private Pinball_player_controller player;

    [SerializeField] private bool Left;
    [SerializeField] private float speed;

    AudioSource _audio;

    void Start()
    {
        ball_rg = GameObject.FindGameObjectWithTag("ball").GetComponent<Rigidbody2D>();
        _audio = gameObject.GetComponent<AudioSource>();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("ball")) { return; } //ball이외의 충돌은 무시
        if(Left.Equals(true) && !player.player_Input_L.Equals(true)) { return; } //left바의 경우 왼쪽을 눌러야만 실행됨
        if(Left.Equals(false) && !player.player_Input_R.Equals(true)) { return; } //right바의 경우 오른쪽을 눌러야만 실행됨

        float direction_x = 0f;
        float direction_y = 0f;

        if (ball_rg.velocity.x < 0) //오른쪽->왼쪽으로 공이 부딪힐 때
        {
            direction_x = -0.1f; //왼쪽으로 공이 튕겨야 함 v
        }

        if (ball_rg.velocity.x > 0) //왼쪽->오른쪽으로 공이 부딪힐 때
        {
            direction_x = 0.1f; //오른쪽으로 공이 튕겨야 함 v
        }

        Vector2 ball_current_Pos = collision.transform.position;
        Vector2 coll_current_Pos = transform.position;
        Vector2 coll_pos = ball_current_Pos - coll_current_Pos;

        //공이 아래 있으면
        if (coll_pos.y < 0) 
        {
            direction_y = -0.1f; //아래로 튕김
        }

        //공이 위에 있으면
        if (coll_pos.y > 0)
        {
            direction_y = 1f; //위로 튕김
        }

        Vector2 move = new Vector2(direction_x, direction_y);

        ball_rg.velocity = move * speed;

        _audio.Play();
    }
}