using UnityEngine;
using UnityEngine.SceneManagement;

public class Follows_MousePointer : MonoBehaviour
{
    private void Start()
    {
        //커서 숨김
        Cursor.visible = false; 
    }

    private void Update()
    {
        //Vector3 mousePosition = Input.mousePosition;
        //ScreenToWorldPoint를 사용하여 월드좌표로 변환

        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = mousePosition;
    }

    //타이틀 버튼에 사용할 메소드
    //2번째 클릭에 씬 전환
    int click_number = 0;
    public void Next_Scene()
    {
        click_number++;
        if (click_number.Equals(2))
        {
            Cursor.visible = true;
            SceneManager.LoadScene("menu");
        }
    }

}
