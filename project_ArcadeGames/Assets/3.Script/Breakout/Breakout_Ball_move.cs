using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Breakout_Ball_move : MonoBehaviour
{
    [SerializeField] private Rigidbody2D ball_rigidbody;
    [SerializeField] private AudioSource bounce_audio;

    [SerializeField] private Text score_text;
    [SerializeField] private Text ball_chance_text;

    [SerializeField] private GameObject gameWin_ui;
    [SerializeField] private GameObject gameover_ui;

    float speed;

    int ball_chance = 3;
    int Score = 0;
    bool LightSwitch = true; //스코어 깜빡깜빡

    void Start()
    {
        Time.timeScale = 1;

        ball_rigidbody = gameObject.GetComponent<Rigidbody2D>();
        bounce_audio = gameObject.GetComponent<AudioSource>();
        gameWin_ui.SetActive(false);
        gameover_ui.SetActive(false);

        speed = 5f;
        ball_chance = 3;
        Score =0;
        LightSwitch = true;

        ball_rigidbody.velocity = Vector2.down;

        StartCoroutine(Score_Blink_co());

    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //공이 물체에 부딪힐 때마다 공의 이동방향을 정하자

        //Ball이 부딪힌 위치
        Vector2 ball_current_Pos = transform.position;

        //충돌물체의 위치
        Vector2 coll_current_Pos = collision.transform.position;

        //충돌물체의 어디에 부딪혔는가? (볼 위치와 대상 위치의 차이)
        Vector2 coll_pos = ball_current_Pos - coll_current_Pos;
        Debug.Log("부딪힌 방향 : " + coll_pos);


        float direction_x = 0f; //공이 튕길 방향의 x값
        float direction_y = 0f; //공이 튕길 방향의 y값


        if (coll_pos.x > 0) //Ball이 물체의 오른쪽에 있을 경우
        {
            direction_x = 1f; //오른쪽으로 튕김 |<

            //단, 오른쪽->왼쪽으로 공이 부딪힐 때 v
            if (ball_rigidbody.velocity.x < 0) 
            {
                direction_x = -1f; //왼쪽으로 공이 튕겨야 함
            }
        }

        if (coll_pos.x < 0) //Ball이 물체의 왼쪽에 있을 경우
        {
            direction_x = -1f; //왼쪽으로 튕김 >|

            //단, 왼쪽->오른쪽으로 공이 부딪힐 때 v
            if (ball_rigidbody.velocity.x > 0) 
            {
                direction_x = 1f; //오른쪽으로 공이 튕겨야 합
            }
        }

        if (coll_pos.y > 0) //Ball이 물체의 위에 있을 경우
        {
            direction_y = 1f; //위로 튕김 v

            //단, 위->아래로 공이 벽!에 부딪히면 <
            if (collision.gameObject.CompareTag("Wall") && ball_rigidbody.velocity.y < 0)
            {
                direction_y = -1f; //아래로 튕겨야함
            }
        }

        if (coll_pos.y < 0) //Ball이 물체의 아래에 있을 경우 
        {
            direction_y = -1f; //아래로 튕김 ^

            //단, 아래->위로 공이 벽!에 부딪히면 <
            if (collision.gameObject.CompareTag("Wall") && ball_rigidbody.velocity.y > 0)
            {
                direction_y = 1f; //위로 튕겨야 함
            }
        }


        Vector2 move = new Vector2(direction_x, direction_y);
        Debug.Log("공의 이동 방향 : " + move);

        ball_rigidbody.velocity = move * speed;

        if (!collision.gameObject.CompareTag("Player"))
        {
            bounce_audio.Play();
        }
    }

    //Brick_Breakout 스크립트로부터 호출받음
    public void Score_up(int Plus_score)
    {
        Score += Plus_score;
        if(Score / 10 >= 10)
        {
            score_text.text = "" + Score;
        }
        else if(Score / 10 >= 1)
        {
            score_text.text = "0" + Score;
        }
        else if (Score / 10 == 0)
        {
            score_text.text = "00" + Score;
        }

        if (Score >= 264) //88(brick) * 3(score)
        {
            StopCoroutine(nameof(Score_Blink_co));
            score_text.gameObject.SetActive(true);
            gameWin_ui.SetActive(true);
            Time.timeScale = 0;
        }
    }

    IEnumerator Score_Blink_co()
    {
        while (true)
        {
            switch (LightSwitch)
            {
                case true:
                    score_text.gameObject.SetActive(false);
                    LightSwitch = false;
                    yield return new WaitForSeconds(0.5f);
                    break;
                case false:
                    score_text.gameObject.SetActive(true);
                    LightSwitch = true;
                    yield return new WaitForSeconds(0.5f);
                    break;
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        //아래에 있는 Dead 트리거와 만났을 시
        if (collision.gameObject.CompareTag("Dead"))
        {
            ball_chance--;
            ball_chance_text.text = "" + ball_chance;

            if (ball_chance.Equals(0))
            {
                StopCoroutine(nameof(Score_Blink_co));
                score_text.gameObject.SetActive(true);
                gameover_ui.SetActive(true);
                Time.timeScale = 0;
            }

            ball_rigidbody.velocity = Vector2.zero;
            gameObject.transform.position = Vector2.zero;
            ball_rigidbody.velocity = Vector2.down;
        }
        else //파란색 트리거 일 경우
        {
            float direction_x = 0f; //공이 튕길 방향의 x값

            //오른쪽->왼쪽 으로 부딪힐때
            if (ball_rigidbody.velocity.x < 0) 
            {
                direction_x = 1f; //오른쪽으로 튕김
            }

            //왼쪽->오른쪽 으로 부딪힐때
            if (ball_rigidbody.velocity.x > 0)
            {
                direction_x = -1f; //왼쪽으로 튕김
            }


            Vector2 move = new Vector2(direction_x, -1f);

            ball_rigidbody.velocity = move * speed;
        }
    }
}
