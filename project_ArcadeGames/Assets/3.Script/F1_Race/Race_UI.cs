using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Race_UI : MonoBehaviour
{
    [SerializeField] private Race_Game_End gameEnding;
    [SerializeField] private Color RaceUIcolor;

    [SerializeField] private Image[] Gauge = new Image[16];
    [SerializeField] private Text Time_Limit;
    [SerializeField] private Text Score_number;
    [SerializeField] private Text speed_text;

    public float currentLimit;
    public float score_Total;
    private float update_rate = 5;
    private bool Gear_switch;
    private float timer;
    public bool ending = false;

    void Start()
    {
        update_rate = 5;
        currentLimit = 43;
        score_Total = 0;
        RaceUIcolor.r = 0f;
        RaceUIcolor.g = 0.4156863f;
        RaceUIcolor.b = 0.1176471f;
        RaceUIcolor.a = 1f;
        Gear_switch = false;
        ending = false;
        Gauge[14].color = RaceUIcolor;
    }

    void Update()
    {
        //스타트 카운트다운 기다리기
        if (update_rate > 0)
        {
            update_rate -= Time.deltaTime;
            return;
        }

        //1초마다 Time_Limit 줄어듬
        if (ending.Equals(false))
        {
            currentLimit -= Time.deltaTime;
            Time_Limit.text = "" + (int)currentLimit;
        }
        
        //게임오버
        if (currentLimit < 0)
        {
            currentLimit = 0;
            Gameover();
        }

    }

    void Gameover()
    {
        gameEnding.GameEnd_Race(false);
    }

    //1바퀴 완주 후, 타임리밋 리셋
    public void Set_currentLimit()
    {
        currentLimit = 43;
    }

    //스코어
    public void Score_up(float input_score)
    {
        score_Total += input_score;
        timer += Time.deltaTime;
        if(timer > 0.7)
        {
            timer = 0;
            Score_number.text = "" + (int)score_Total;
        }
    }

    //속도계
    public void Speedometer(int speed_Gauge)
    {
        if (speed_Gauge > 10) { Gauge[0].color = RaceUIcolor; } else if (speed_Gauge < 10) { Gauge[0].color = Color.white; }
        if (speed_Gauge > 20) { Gauge[1].color = RaceUIcolor; } else if (speed_Gauge < 20) { Gauge[1].color = Color.white; }
        if (speed_Gauge > 30) { Gauge[2].color = RaceUIcolor; } else if (speed_Gauge < 30) { Gauge[2].color = Color.white; }
        if (speed_Gauge > 40) { Gauge[3].color = RaceUIcolor; } else if (speed_Gauge < 40) { Gauge[3].color = Color.white; }
        if (speed_Gauge > 50) { Gauge[4].color = RaceUIcolor; } else if (speed_Gauge < 50) { Gauge[4].color = Color.white; }
        if (speed_Gauge > 60) { Gauge[5].color = RaceUIcolor; } else if (speed_Gauge < 60) { Gauge[5].color = Color.white; }
        if (speed_Gauge > 80) { Gauge[6].color = RaceUIcolor; } else if (speed_Gauge < 80) { Gauge[6].color = Color.white; }
        if (speed_Gauge > 90) { Gauge[7].color = RaceUIcolor; } else if (speed_Gauge < 90) { Gauge[7].color = Color.white; }
        if (speed_Gauge > 100) { Gauge[8].color = RaceUIcolor; } else if (speed_Gauge < 100) { Gauge[8].color = Color.white; }
        if (speed_Gauge > 200) { Gauge[9].color = RaceUIcolor; } else if (speed_Gauge < 110) { Gauge[9].color = Color.white; }
        if (speed_Gauge > 300) { Gauge[10].color = RaceUIcolor; } else if (speed_Gauge < 200) { Gauge[10].color = Color.white; }
        if (speed_Gauge > 380) { Gauge[11].color = RaceUIcolor; } else if (speed_Gauge < 300) { Gauge[11].color = Color.white; }
        if (speed_Gauge > 450) { Gauge[12].color = RaceUIcolor; } else if (speed_Gauge < 450) { Gauge[12].color = Color.white; }
        if (speed_Gauge > 480) { Gauge[13].color = RaceUIcolor; } else if (speed_Gauge < 480) { Gauge[13].color = Color.white; }

        speed_text.text = "" + speed_Gauge;
    }

    //기어
    public void Gear()
    {
        switch (Gear_switch)
        {
            case true:
                Gauge[14].color = RaceUIcolor;
                Gauge[15].color = Color.white;
                Gear_switch = false;
                return;

            case false:
                Gauge[14].color = Color.white;
                Gauge[15].color = RaceUIcolor;
                Gear_switch = true;
                return;
        }
    }

}
