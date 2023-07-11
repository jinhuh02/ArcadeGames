using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Race_Game_End : MonoBehaviour
{
    [SerializeField] private GameObject rece_gameOver;
    [SerializeField] private AudioSource rece_gameOver_audio;
    [SerializeField] private GameObject rece_gameWin;
    [SerializeField] private AudioSource rece_gameWin_audio;

    [SerializeField] private GameObject player_car;
    [SerializeField] private Race_PlayerController player_script;

    [SerializeField] private Text score;
    [SerializeField] private Race_UI ui;

    //코루틴을 사용하는 스크립트 (player_script && Current_Location_script)
    [SerializeField] Race_Current_Location Current_Location_script;

    public void Start()
    {
        rece_gameOver_audio = rece_gameOver.GetComponent<AudioSource>();
        rece_gameWin_audio = rece_gameWin.GetComponent<AudioSource>();

        rece_gameOver.SetActive(false);
        rece_gameWin.SetActive(false);
    }

    public void GameEnd_Race(bool type)
    {
        player_script.ending = true;
        ui.ending = true;

        player_script.speed = 0;
        Stop_croutine_all();

        //game win
        if (type.Equals(true)) 
        {
            rece_gameWin.SetActive(true);
            score.text = "score : " + (int)ui.score_Total;
            player_script.GetComponent<AudioSource>().Stop();
            rece_gameWin_audio.Play();

            player_car.transform.position = new Vector2(0, player_car.transform.position.y);

            StartCoroutine(nameof(Player_win_move_co));
        }

        //game over
        if (type.Equals(false)) 
        {
            rece_gameOver.SetActive(true);
            player_script.GetComponent<AudioSource>().Stop();
            rece_gameOver_audio.Play();
        }
    }

    void Player_win_move(float yPos)
    {
        if (yPos > 0.7f) { player_car.transform.localScale = new Vector2(0f, 0f); } 
        else if (yPos > 0.6f) { player_car.transform.localScale = new Vector2(0.5f, 0.5f); }
        else if (yPos > 0.4f) { player_car.transform.localScale = new Vector2(0.6f, 0.6f); }
        else if (yPos > 0.3f) { player_car.transform.localScale = new Vector2(0.8f, 0.8f); }
        else if (yPos > 0.2f) { player_car.transform.localScale = new Vector2(1f, 1f); }
        else if (yPos > 0.1f) { player_car.transform.localScale = new Vector2(1.5f, 1.5f); }
        else if (yPos > 0f) { player_car.transform.localScale = new Vector2(2f, 2f); } 
        else if (yPos > -0.1f) { player_car.transform.localScale = new Vector2(2.5f, 2.5f); }
        else if (yPos > -0.2f) { player_car.transform.localScale = new Vector2(3f, 3f); } 
        else if (yPos > -0.3f) { player_car.transform.localScale = new Vector2(3.2f, 3.2f); }
        else if (yPos > -0.4f) { player_car.transform.localScale = new Vector2(3.5f, 3.5f); }
        else if (yPos > -0.5f) { player_car.transform.localScale = new Vector2(3.7f, 3.7f); }
        else if (yPos > -0.6f) { player_car.transform.localScale = new Vector2(4f, 4f); }
    }

    IEnumerator Player_win_move_co()
    {
        while (true)
        {
            player_car.transform.position += new Vector3(0, 0.1f);
            Player_win_move(player_car.transform.position.y);

            if (player_car.transform.position.y > 0.7f)
            {
                StopCoroutine(nameof(Player_win_move_co));
                yield break;
            }
            yield return new WaitForSeconds(0.08f);
        }
    }

    void Stop_croutine_all()
    {
        //혹시라도 작동중인 코루틴을 멈추기 위하여
        //public void Stop_co() { StopAllCoroutines(); } 

        Current_Location_script.Stop_co();
        player_script.Stop_co();
    }
}
