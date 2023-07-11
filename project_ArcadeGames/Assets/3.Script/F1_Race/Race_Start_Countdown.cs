using UnityEngine;

public class Race_Start_Countdown : MonoBehaviour
{
    [SerializeField] private GameObject[] Count_start = new GameObject[4];

    private float count = 0;

    void Start()
    {
        Count_start[0].SetActive(false);
        Count_start[1].SetActive(false);
        Count_start[2].SetActive(false);
        Count_start[3].SetActive(false);

        count = 0;
    }

    void Update()
    {
        count += Time.deltaTime;

        if (count > 0)
        {
            Count_start[0].SetActive(true);

            if(count > 1)
            {
                Count_start[0].SetActive(false);
                Count_start[1].SetActive(true);

                if (count > 2)
                {
                    Count_start[1].SetActive(false);
                    Count_start[2].SetActive(true);

                    if (count > 3)
                    {
                        Count_start[2].SetActive(false);
                        Count_start[3].SetActive(true);

                        if(count > 5)
                        {
                            Destroy(gameObject);
                        }
                    }
                }
            }
        }
    }
}
