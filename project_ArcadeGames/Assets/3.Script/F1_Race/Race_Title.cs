using UnityEngine;
using UnityEngine.SceneManagement;

public class Race_Title : MonoBehaviour
{
    [SerializeField] private GameObject Title;
    [SerializeField] private GameObject Map;

    bool MapActive = false;
    float countTime = 4.5f;

    void Start()
    {
        countTime = 4.5f;
        Title.SetActive(true);
        Map.SetActive(false);
    }

    //Title 시작 버튼을 누르면
    public void Switch_Scene()
    {
        Title.SetActive(false);
        Map.SetActive(true);
        MapActive = true;
    }

    private void Update()
    {
        if (Input.anyKey && !MapActive)
        {
            Switch_Scene();
        }

        if (MapActive)
        {
            countTime -= Time.deltaTime;

            if (countTime <= 0)
            {
                countTime = 4.5f;
                SceneManager.LoadScene("F1_Race");
            }
        }
    }

}
