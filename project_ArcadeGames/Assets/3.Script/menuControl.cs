using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuControl : MonoBehaviour
{

    [SerializeField] private GameObject machine_pinball;
    [SerializeField] private GameObject machine_pinball_light;
    [SerializeField] private GameObject machine_breakout;
    [SerializeField] private GameObject machine_breakout_light;
    [SerializeField] private GameObject machine_race;
    [SerializeField] private GameObject machine_race_light;

    [SerializeField] private AudioSource menu_move_sound_L;
    [SerializeField] private AudioSource menu_move_sound_R;
    [SerializeField] private AudioSource menu_choice_sound;

    //�ɺ��� �����̶�� 0, �߾��̶�� 1, �������̶�� 2
    int menu_pos = 0;

    bool left;

    private void Start()
    {
        Time.timeScale = 1;
        machine_pinball_light.SetActive(false);
        machine_breakout_light.SetActive(false);
        machine_race_light.SetActive(false);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Left_button();
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Right_button();
        }
        if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            Scene_choice();
        }
    }

    public void Left_button()
    {
        switch (menu_pos)
        {
            case 0:
                menu_pos = 2;
                break;
            case 1:
                menu_pos = 0;
                break;
            case 2:
                menu_pos = 1;
                break;
        }
        left = true;
        Move_menu(left);
        menu_move_sound_L.Play();
    }

    public void Right_button()
    {
        switch (menu_pos)
        {
            case 0:
                menu_pos = 1;
                break;
            case 1:
                menu_pos = 2;
                break;
            case 2:
                menu_pos = 0;
                break;
        }
        left = false;
        Move_menu(left);
        menu_move_sound_R.Play();
    }

    private void Move_menu(bool left)
    {
        if (left.Equals(true))
        {
            switch (machine_pinball.transform.position.x)
            {
                case -10: //�������� | ���̽� | �ɺ�
                    machine_pinball.transform.position += new Vector3(20f, 0);
                    machine_breakout.transform.position += new Vector3(-10f, 0);
                    machine_race.transform.position += new Vector3(-10f, 0);
                    break;
                case 0: //�ɺ� | �������� | ���̽�
                    machine_pinball.transform.position += new Vector3(-10f, 0);
                    machine_breakout.transform.position += new Vector3(-10f, 0);
                    machine_race.transform.position += new Vector3(20f, 0);
                    break;
                case 10: //���̽� | �ɺ� | ��������
                    machine_pinball.transform.position += new Vector3(-10f, 0);
                    machine_breakout.transform.position += new Vector3(20f, 0);
                    machine_race.transform.position += new Vector3(-10f, 0);
                    break;
            }
        }
        else
        {
            switch (machine_pinball.transform.position.x)
            {
                case -10: //���̽� | �ɺ� | ��������
                    machine_pinball.transform.position += new Vector3(10f, 0);
                    machine_breakout.transform.position += new Vector3(10f, 0);
                    machine_race.transform.position += new Vector3(-20f, 0);
                    break;
                case 0: //�������� | ���̽� | �ɺ�
                    machine_pinball.transform.position += new Vector3(10f, 0);
                    machine_breakout.transform.position += new Vector3(-20f, 0);
                    machine_race.transform.position += new Vector3(10f, 0);
                    break;
                case 10: //�ɺ� | �������� | ���̽�
                    machine_pinball.transform.position += new Vector3(-20f, 0);
                    machine_breakout.transform.position += new Vector3(10f, 0);
                    machine_race.transform.position += new Vector3(10f, 0);
                    break;
            }
        }
    }


    //������ �������� ���
    public void Scene_choice()
    {
        StartCoroutine(nameof(WaitForSongEnd_co));
    }

    IEnumerator WaitForSongEnd_co()
    {
        menu_choice_sound.Play();
        switch (menu_pos)
        {
            case 0:
                machine_breakout_light.SetActive(true);
                break;
            case 1:
                machine_pinball_light.SetActive(true);
                break;
            case 2:
                machine_race_light.SetActive(true);
                break;
        }

        //menu_choice ����� �Ϸ�ɶ����� �������� �Ѿ�� ����
        yield return new WaitUntil(() => !menu_choice_sound.isPlaying);

        switch (menu_pos)
        {
            case 0:
                SceneManager.LoadScene("Breakout");
                break;
            case 1:
                SceneManager.LoadScene("Pinball");
                break;
            case 2:
                SceneManager.LoadScene("Title_Race");
                break;
        }
        StopCoroutine(nameof(WaitForSongEnd_co));
        yield break;
    }
}
