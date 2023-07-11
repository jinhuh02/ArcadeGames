using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Input_esc : MonoBehaviour
{
    [SerializeField] GameObject esc_box; //esc를 누르면 나타나는 UI를 담은 obj box

    bool Esc_switch;

    private void Start()
    {
        Time.timeScale = 1;
        esc_box.SetActive(false);
        Esc_switch = false;
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            switch (Esc_switch)
            {
                case true:
                    Esc_switch = false;
                    break;

                case false:
                    Esc_switch = true;
                    break;
            }
            
            StartCoroutine(Stop_time());
        }
    }

    IEnumerator Stop_time()
    {
        switch (Esc_switch)
        {
            case true:
                esc_box.SetActive(true);
                Time.timeScale = 0;
                yield return new WaitForSeconds(1f);
                break;

            case false:
                esc_box.SetActive(false);
                Time.timeScale = 1;
                yield return new WaitForSeconds(1f);
                break;
        }

        StopCoroutine(Stop_time());
        yield break;
    }

    //esc 화면에서 계속 이어서하기를 누르면 실행되는 메서드
    public void Yes_button()
    {
        esc_box.SetActive(false);
        Time.timeScale = 1;
    }
}
