using UnityEngine;
using UnityEngine.UI;

public class Pinball_player_controller : MonoBehaviour
{
    [SerializeField] Pinball_ball ball;
    [SerializeField] Text score_ui;
    [SerializeField] Text chance_ui;
    [SerializeField] GameObject gameEnd;
    [SerializeField] Text total_score_ui;

    [SerializeField] GameObject stick;
    [SerializeField] GameObject left_bar;
    [SerializeField] Rigidbody2D left_bar_rg;
    [SerializeField] GameObject right_bar;
    [SerializeField] Rigidbody2D right_bar_rg;

    //파워 게이지
    [SerializeField] GameObject[] power_gauge_1 = new GameObject[2];
    [SerializeField] GameObject[] power_gauge_2 = new GameObject[2];
    [SerializeField] GameObject[] power_gauge_3 = new GameObject[2];
    [SerializeField] GameObject[] power_gauge_4 = new GameObject[2];
    [SerializeField] GameObject[] power_gauge_5 = new GameObject[2];

    AudioSource stick_audio;
    AudioSource ball_audio;

    public bool player_Input_L;
    public bool player_Input_R;

    float ball_start_power;
    bool ball_dead;

    int total_score;
    int Life;

    void Start()
    {
        left_bar_rg = left_bar.GetComponent<Rigidbody2D>();
        right_bar_rg = right_bar.GetComponent<Rigidbody2D>();
        stick_audio = stick.GetComponent<AudioSource>();
        ball_audio = ball.GetComponent<AudioSource>();
        gameEnd.SetActive(false);

        for(int i=0; i<2; i++)
        {
            power_gauge_1[i].SetActive(false);
            power_gauge_2[i].SetActive(false);
            power_gauge_3[i].SetActive(false);
            power_gauge_4[i].SetActive(false);
            power_gauge_5[i].SetActive(false);
        }

        total_score = 0;
        Life = 7;
        ball_dead = false;
        player_Input_L = false;
        player_Input_R = false;

        ball_audio.Play();
    }

    void Update()
    {
        //아래를 눌러 파워 게이지 채우기
        if (Input.GetKey(KeyCode.DownArrow)) 
        {
            if (stick.transform.position.y > -4.3)
            {
                stick.transform.position += new Vector3(0, -2f) * Time.deltaTime;
            }
            ball_start_power += 0.2f;

            if(ball_start_power >= 4)
            {
                power_gauge_1[0].SetActive(true);
                power_gauge_1[1].SetActive(true);
            }
            if (ball_start_power >= 8)
            {
                power_gauge_2[0].SetActive(true);
                power_gauge_2[1].SetActive(true);
            }
            if (ball_start_power >= 12)
            {
                power_gauge_3[0].SetActive(true);
                power_gauge_3[1].SetActive(true);
            }
            if (ball_start_power >= 16)
            {
                power_gauge_4[0].SetActive(true);
                power_gauge_4[1].SetActive(true);
            }
            if (ball_start_power >= 20)
            {
                power_gauge_5[0].SetActive(true);
                power_gauge_5[1].SetActive(true);
            }
        }

        //공을 위로 튕기기
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            if (ball_start_power > 20)
            {
                ball_start_power = 20;
            }
            stick.transform.position = new Vector3(3.45f, -3.093f);
            stick_audio.Play();
            ball.Start_pinball(ball_start_power);
            ball_start_power = 0;
            for (int i = 0; i < 2; i++)
            {
                power_gauge_1[i].SetActive(false);
                power_gauge_2[i].SetActive(false);
                power_gauge_3[i].SetActive(false);
                power_gauge_4[i].SetActive(false);
                power_gauge_5[i].SetActive(false);
            }
        }


        if (Input.GetKey(KeyCode.LeftArrow))
        {
            left_bar_rg.AddTorque(40f, ForceMode2D.Impulse);
            player_Input_L = true;
        }
        else
        {
            left_bar_rg.AddTorque(-40f, ForceMode2D.Impulse);
            player_Input_L = false;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            right_bar_rg.AddTorque(-40f, ForceMode2D.Impulse);
            player_Input_R = true;
        }
        else
        {
            right_bar_rg.AddTorque(40f, ForceMode2D.Impulse);
            player_Input_R = false;
        }

        if (ball_dead && Input.anyKey)
        {
            ball_dead = false;
            ball.gameObject.SetActive(true);
            ball_audio.Play();
        }
    }

    //각 오브젝트마다 있는 get_point 스크립트로부터 호출받음
    public void Score_up_pinball(int point)
    {
        total_score += point;
        score_ui.text = "SCORE : " + total_score;
    }

    public void Dead_ball_pinball()
    {
        Life--;
        chance_ui.text = "chance : " + Life;
       
        //가진 기회를 다 사용했다면
        if(Life.Equals(0))
        {
            gameEnd.SetActive(true);
            total_score_ui.text = "your score : " + total_score;
        }
        else
        {
            ball_dead = true;
        }
    }
}
