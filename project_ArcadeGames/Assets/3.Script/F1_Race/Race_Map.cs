using UnityEngine;

public class Race_Map : MonoBehaviour
{
    [SerializeField] private Race_Game_End gameEnding;
    [SerializeField] private Race_PlayerController player;
    [SerializeField] private Race_Current_Location mini_map;
    [SerializeField] private Race_UI ui;
    [SerializeField] private Race_Move_Control move;

    public float Map_size;
    public float size_save;

    public float player_location = 0;

    int number_of_completions = 0;
    public bool curve = false;
    public bool c_return = false;

    float stopwatch;


    void Start()
    {
        Map_size = 200;
        size_save = Map_size;

        number_of_completions = 0;
        curve = false;
        c_return = false;
        stopwatch = 0;
    }

    void Update()
    {
        player_location = 100 - (Map_size * 100 / size_save);

        stopwatch += Time.deltaTime;
        //�ӵ��� ���� ���� ����� �پ����(0.5�ʸ���)
        if (stopwatch >= 0.5 && player.speed > 1)
        {
            stopwatch = 0;
            //Debug.Log("�̵��� �Ÿ�% : " + player_location);

            //�̴� �ʿ����� ��ġ ǥ��
            mini_map.Move_MiniMap_Location((int)player_location);

            switch (player.speed / 50)
            {
                case 0: //50����
                    Map_size -= 0.1f;
                    break;
                case 1: //50~99
                    Map_size -= 0.2f;
                    break;
                case 2: //100~149
                    Map_size -= 0.4f;
                    break;
                case 3: //150~199
                    Map_size -= 0.5f;
                    break;
                case 4: //200~249
                    Map_size -= 0.7f;
                    break;
                case 5: //250~299
                    Map_size -= 0.8f;
                    break;
                case 6: //300~349
                    Map_size -= 1f;
                    break;
                case 7: //350~399
                    Map_size -= 1.5f;
                    break;
                case 8: //400~449
                    Map_size -= 2f;
                    break;
                default: //450~500
                    Map_size -= 2.5f;
                    break;
            }
        }


        //���� �� ������ ������ ���� Ŀ�걸�� ����
        if(player_location > 98)
        {
            c_return = false;
        }else if (player_location > 87)
        {
            curve = false;
            c_return = true;
        }else if(player_location > 69)
        {
            curve = true;
        }else if (player_location > 50)
        {
            c_return = false;
        }else if (player_location > 38)
        {
            curve = false;
            c_return = true;
        }else if (player_location > 22)
        {
            c_return = false;
            curve = true;
        }

        //���� ���� ���� 
        if (curve.Equals(true) || c_return.Equals(true))
        {
            Move_Link();
        }

        //2���� ����
        if (Map_size == 0)
        {
            Debug.Log("1��° ���� ����");
            //1��° ����
            number_of_completions++;
            Map_size = size_save;
            ui.Set_currentLimit();

            //2��° ����
            if (number_of_completions.Equals(2)) 
            {
                //���� Ŭ����
                gameEnding.GameEnd_Race(true);
            }
        }
    }


    void Move_Link()
    {
        if (curve)
        {
            move.Curve_True();
        }

        if (c_return)
        {
            move.Curve_return_True();
        }
    }
}
