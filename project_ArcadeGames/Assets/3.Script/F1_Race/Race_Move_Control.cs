using UnityEngine;

public class Race_Move_Control : MonoBehaviour
{
    //������ obj���� ��Ƶ� �迭
    [SerializeField] public GameObject[] ground = new GameObject[52];
    [SerializeField] private Race_ground_control[] ground_script = new Race_ground_control[52];
    [SerializeField] private GameObject sky;

    //������ �Ÿ��� ��Ƶ� �迭
    private float[] move_num_x = new float[52] { 11.4f, 11.06f, 10.6f, 10.2f, 9.78f, 9.25f, 9.1f, 8.68f, 8.35f, 8.08f, 7.71f, 7.39f, 7.17f, 6.76f, 6.47f, 6.19f, 5.97f, 5.63f, 5.31f, 5.31f, 4.89f, 4.71f, 4.41f, 4.17f, 3.95f, 3.8f, 3.58f, 3.58f, 3.15f, 2.95f, 2.78f, 2.58f, 2.48f, 2.3f, 2.11f, 2f, 1.8f, 1.65f, 1.52f, 1.41f, 1.32f, 1.11f, 1.04f, 0.95f, 0.76f, 0.69f, 0.56f, 0.5f, 0.37f, 0.24f, 0.17f, 0.1f };

    //���ǵ�� �Ÿ�
    [SerializeField] private Race_PlayerController player;
    [SerializeField] public Race_Map map;

    private void Start()
    {
        for (int i = 0; i < 52; i++)
        {
            ground_script[i] = ground[i].GetComponent<Race_ground_control>();
        }
    }

    //Ŀ�� ����(curve = true)�� ������ Race_Map���� ȣ���� �Լ�
    public void Curve_True()
    {
        float location = map.player_location;

        float move_x = player.speed / 50;
        if (location > 26 && location < 50)
        {
            player.Curve_on(move_x);
        }
        else if (location > 73)
        {
            player.Curve_on(move_x);
        }

        if (location < 33)
        {
            int step = (int)((location - 23) / 0.125f);
            if (step < 0)
            {
                step = 0;
            }
            if (step >= 72)
            {
                step = 72;
            }
            for (int i = 0; i < 52; i++)
            {
                ground_script[i].Curve_move_Right(((move_num_x[i]) / 72) * step);
            }

        }

        else if (location > 67)
        {
            int step = (int)((location - 70) / 0.125f);
            if (step < 0)
            {
                step = 0;
            }
            if (step >= 72)
            {
                step = 72;
            }
            for (int i = 0; i < 52; i++)
            {
                ground_script[i].Curve_move_Right(((move_num_x[i]) / 72) * step);
            }

        }

        if (player.speed > 0 && player.Input_Right)
        {
            sky.transform.position += new Vector3(-0.3f, 0) * Time.deltaTime;
        }
    }

    //Ŀ�� ������ ������ ���ΰ� �ٽ� �������� ���ƿ;� �� ��
    public void Curve_return_True()
    {
        float location = map.player_location;

        float move_x = player.speed / 50;
        if (location < 46)
        {
            player.Curve_on(move_x);
        }
        else if (location > 85)
        {
            player.Curve_on(move_x);
        }


        if (location < 53)
        {
            float temp = (location - 39) / 0.125f;
            int step = 72 - (int)temp;  //int step = 36 - (int)((location - 39) / 0.25f);
            if (step < 0)
            {
                step = 0;
            }
            if (step >= 72)
            {
                step = 72;
            }
            for (int i = 0; i < 52; i++)
            {
                ground_script[i].Curve_move_Right(((move_num_x[i]) / 72) * step);
            }
        }

        else if (location > 85)
        {
            float temp = (location - 88) / 0.125f;
            int step = 72 - (int)temp;
            if (step < 0)
            {
                step = 0;
            }
            if (step >= 72)
            {
                step = 72;
            }
            for (int i = 0; i < 52; i++)
            {
                ground_script[i].Curve_move_Right(((move_num_x[i]) / 72) * step);
            }
        }

        if (player.speed > 0 && player.Input_Right) //�÷��̾ �������� ��������
        {
            sky.transform.position += new Vector3(-0.1f, 0) * Time.deltaTime;
        }
    }

}