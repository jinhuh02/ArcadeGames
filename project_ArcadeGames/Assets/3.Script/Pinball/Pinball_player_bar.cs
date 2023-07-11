using UnityEngine;

public class Pinball_player_bar : MonoBehaviour
{
    [SerializeField] private Rigidbody2D ball_rg;
    [SerializeField] private Pinball_player_controller player;

    [SerializeField] private bool Left;
    [SerializeField] private float speed;

    AudioSource _audio;

    void Start()
    {
        ball_rg = GameObject.FindGameObjectWithTag("ball").GetComponent<Rigidbody2D>();
        _audio = gameObject.GetComponent<AudioSource>();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("ball")) { return; } //ball�̿��� �浹�� ����
        if(Left.Equals(true) && !player.player_Input_L.Equals(true)) { return; } //left���� ��� ������ �����߸� �����
        if(Left.Equals(false) && !player.player_Input_R.Equals(true)) { return; } //right���� ��� �������� �����߸� �����

        float direction_x = 0f;
        float direction_y = 0f;

        if (ball_rg.velocity.x < 0) //������->�������� ���� �ε��� ��
        {
            direction_x = -0.1f; //�������� ���� ƨ�ܾ� �� v
        }

        if (ball_rg.velocity.x > 0) //����->���������� ���� �ε��� ��
        {
            direction_x = 0.1f; //���������� ���� ƨ�ܾ� �� v
        }

        Vector2 ball_current_Pos = collision.transform.position;
        Vector2 coll_current_Pos = transform.position;
        Vector2 coll_pos = ball_current_Pos - coll_current_Pos;

        //���� �Ʒ� ������
        if (coll_pos.y < 0) 
        {
            direction_y = -0.1f; //�Ʒ��� ƨ��
        }

        //���� ���� ������
        if (coll_pos.y > 0)
        {
            direction_y = 1f; //���� ƨ��
        }

        Vector2 move = new Vector2(direction_x, direction_y);

        ball_rg.velocity = move * speed;

        _audio.Play();
    }
}