using UnityEngine;

public class Race_Enemy_spawner : MonoBehaviour
{

    [SerializeField] private GameObject position_obj;
    [SerializeField] private GameObject[] Enemy_Box = new GameObject[20];
    [SerializeField] private GameObject Enemy_1;
    [SerializeField] private GameObject Enemy_2;

    float timer;
    int random;


    void Start()
    {
        timer = 0;

        for(int i=0; i<20; i++)
        {
            if (i % 2 == 1)//Ȧ����� 1,3,5,7,9...
            {
                GameObject enemy = Instantiate(Enemy_1);
                Enemy_Box[i] = enemy;

            }
            else //¦����� 2,4,6,8,10...
            {
                GameObject enemy = Instantiate(Enemy_2);
                Enemy_Box[i] = enemy;
            }
            Enemy_Box[i].SetActive(false);
        }
    }

    private void FixedUpdate()
    {
        timer += Time.deltaTime;
        if (timer >= 5)
        {
            timer = 0;
            //5�ʸ��� 1/2 Ȯ���� ��ֹ� ����
            random = Random.Range(0, 2);
            Debug.Log("1�� ��� Enemy ����" + random);
            if (random == 1)
            {
                Enemy_car_spawner();
            }
        }
    }

    void Enemy_car_spawner()
    {
        for(int i=0; i<20; i++)
        {
            if (!Enemy_Box[i].activeSelf)
            {
                Enemy_Box[i].SetActive(true);
                return;
            }
        }
    }
}
