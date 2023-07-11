using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Race_Current_Location : MonoBehaviour
{

    [SerializeField] private Race_Map map;
    [SerializeField] private Color Transparent;
    [SerializeField] private Image player_Location;

    bool Active_switch = true;
    float start_count = 0;

    void Start()
    {
        //Transparent.r = 0f;
        //Transparent.g = 0.4156863f;
        //Transparent.b = 0.1176471f;
        Transparent.a = 0;
        gameObject.transform.localPosition = new Vector2(-67f, 21f);
        StartCoroutine(nameof(Player_Location_co));
    }

    public void Move_MiniMap_Location(int remaining_distance)
    {
        if (remaining_distance < 10)
        {
            switch (remaining_distance)
            {
                case 0:
                    gameObject.transform.localPosition = new Vector2(-67f, 21f);
                    break;
                case 2:
                    gameObject.transform.localPosition = new Vector2(-67f, 21f);
                    break;
                case 4:
                    gameObject.transform.localPosition = new Vector2(-57f, 21f);
                    break;
                case 5:
                    gameObject.transform.localPosition = new Vector2(-47f, 21f);
                    break;
                case 7:
                    gameObject.transform.localPosition = new Vector2(-37f, 21f);
                    break;
                case 9:
                    gameObject.transform.localPosition = new Vector2(-27f, 21f);
                    break;
            }
        }
        else if (remaining_distance < 20)
        {
            switch (remaining_distance)
            {
                case 11:
                    gameObject.transform.localPosition = new Vector2(-17f, 21f);
                    break;
                case 12:
                    gameObject.transform.localPosition = new Vector2(-7f, 21f);
                    break;
                case 14:
                    gameObject.transform.localPosition = new Vector2(3f, 21f);
                    break;
                case 16:
                    gameObject.transform.localPosition = new Vector2(13f, 21f);
                    break;
                case 18:
                    gameObject.transform.localPosition = new Vector2(23f, 21f);
                    break;
                case 19:
                    gameObject.transform.localPosition = new Vector2(33f, 21f);
                    break;
            }
        }
        else if (remaining_distance < 30)
        {
            switch (remaining_distance)
            {
                case 21:
                    gameObject.transform.localPosition = new Vector2(43f, 21f);
                    break;
                case 23:
                    gameObject.transform.localPosition = new Vector2(53f, 17f);
                    break;
                case 25:
                    gameObject.transform.localPosition = new Vector2(63f, 13f);
                    break;
                case 26:
                    gameObject.transform.localPosition = new Vector2(67f, 9f);
                    break;
                case 29:
                    gameObject.transform.localPosition = new Vector2(70f, 5f);
                    break;
            }
        }
        else if (remaining_distance < 40)
        {
            switch (remaining_distance)
            {
                case 30:
                    gameObject.transform.localPosition = new Vector2(74f, 1f);
                    break;
                case 32:
                    gameObject.transform.localPosition = new Vector2(74f, -3f);
                    break;
                case 33:
                    gameObject.transform.localPosition = new Vector2(74f, -7f);
                    break;
                case 35:
                    gameObject.transform.localPosition = new Vector2(74f, -11f);
                    break;
                case 37:
                    gameObject.transform.localPosition = new Vector2(74f, -15f);
                    break;
                case 39:
                    gameObject.transform.localPosition = new Vector2(70f, -19f);
                    break;
            }
        }
        else if (remaining_distance < 50)
        {
            switch (remaining_distance)
            {
                case 40:
                    gameObject.transform.localPosition = new Vector2(67f, -23f);
                    break;
                case 42:
                    gameObject.transform.localPosition = new Vector2(63f, -27f);
                    break;
                case 44:
                    gameObject.transform.localPosition = new Vector2(53f, -31f);
                    break;
                case 46:
                    gameObject.transform.localPosition = new Vector2(43f, -35f);
                    break;
                case 47:
                    gameObject.transform.localPosition = new Vector2(33f, -35f);
                    break;
                case 49:
                    gameObject.transform.localPosition = new Vector2(23f, -35f);
                    break;
            }
        }
        else if (remaining_distance < 60)
        {
            switch (remaining_distance)
            {
                case 51:
                    gameObject.transform.localPosition = new Vector2(13f, -35f);
                    break;
                case 53:
                    gameObject.transform.localPosition = new Vector2(3f, -35f);
                    break;
                case 54:
                    gameObject.transform.localPosition = new Vector2(-7f, -35f);
                    break;
                case 56:
                    gameObject.transform.localPosition = new Vector2(-17f, -35f);
                    break;
                case 58:
                    gameObject.transform.localPosition = new Vector2(-27f, -35f);
                    break;
            }
        }
        else if (remaining_distance < 70)
        {
            switch (remaining_distance)
            {
                case 60:
                    gameObject.transform.localPosition = new Vector2(-37f, -35f);
                    break;
                case 61:
                    gameObject.transform.localPosition = new Vector2(-47f, -35f);
                    break;
                case 63:
                    gameObject.transform.localPosition = new Vector2(-57f, -35f);
                    break;
                case 65:
                    gameObject.transform.localPosition = new Vector2(-67f, -35f);
                    break;
                case 67:
                    gameObject.transform.localPosition = new Vector2(-77f, -35f);
                    break;
                case 68:
                    gameObject.transform.localPosition = new Vector2(-87f, -35f);
                    break;
            }
        }
        else if (remaining_distance < 80)
        {
            switch (remaining_distance)
            {
                case 70:
                    gameObject.transform.localPosition = new Vector2(-97f, -35f);
                    break;
                case 72:
                    gameObject.transform.localPosition = new Vector2(-107f, -31f);
                    break;
                case 74:
                    gameObject.transform.localPosition = new Vector2(-114f, -27f);
                    break;
                case 75:
                    gameObject.transform.localPosition = new Vector2(-120f, -23f);
                    break;
                case 77:
                    gameObject.transform.localPosition = new Vector2(-125f, -19f);
                    break;
                case 79:
                    gameObject.transform.localPosition = new Vector2(-128f, -15f);
                    break;
            }
        }
        else if (remaining_distance < 90)
        {
            switch (remaining_distance)
            {
                case 81:
                    gameObject.transform.localPosition = new Vector2(-130f, -11f);
                    break;
                case 82:
                    gameObject.transform.localPosition = new Vector2(-131f, -7f);
                    break;
                case 84:
                    gameObject.transform.localPosition = new Vector2(-131f, -3f);
                    break;
                case 86:
                    gameObject.transform.localPosition = new Vector2(-131f, 1f);
                    break;
                case 88:
                    gameObject.transform.localPosition = new Vector2(-128f, 5f);
                    break;
                case 89:
                    gameObject.transform.localPosition = new Vector2(-125f, 9f);
                    break;
            }
        }
        else
        {
            switch (remaining_distance)
            {
                case 91:
                    gameObject.transform.localPosition = new Vector2(-117f, 13f);
                    break;
                case 93:
                    gameObject.transform.localPosition = new Vector2(-107f, 17f);
                    break;
                case 95:
                    gameObject.transform.localPosition = new Vector2(-97f, 21f);
                    break;
                case 96:
                    gameObject.transform.localPosition = new Vector2(-87f, 21f);
                    break;
                case 98:
                    gameObject.transform.localPosition = new Vector2(-77f, 21f);
                    break;
                case 100:
                    gameObject.transform.localPosition = new Vector2(-67f, 21f);
                    break;
            }
        }
    }

    IEnumerator Player_Location_co() //깜빡깜빡
    {
        while (true)
        {
            start_count++;
            if (start_count == 5)
            {
                break;
            }
            yield return new WaitForSeconds(1);
        }

        while (true)
        {
            switch (Active_switch)
            {
                case true:
                    Transparent.a = 0;
                    player_Location.color = Transparent;
                    Active_switch = false;
                    yield return new WaitForSeconds(0.5f);
                    break;
                case false:
                    Transparent.a = 1;
                    player_Location.color = Transparent;
                    Active_switch = true;
                    yield return new WaitForSeconds(0.5f);
                    break;
            }
        }
    }

    //게임이 종료되면 Game_End 스크립트로부터 호출받음
    public void Stop_co()
    {
        StopAllCoroutines();
    }
}

