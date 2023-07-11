using UnityEngine;
using UnityEngine.SceneManagement;

public class Follows_MousePointer : MonoBehaviour
{
    private void Start()
    {
        //Ŀ�� ����
        Cursor.visible = false; 
    }

    private void Update()
    {
        //Vector3 mousePosition = Input.mousePosition;
        //ScreenToWorldPoint�� ����Ͽ� ������ǥ�� ��ȯ

        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = mousePosition;
    }

    //Ÿ��Ʋ ��ư�� ����� �޼ҵ�
    //2��° Ŭ���� �� ��ȯ
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
