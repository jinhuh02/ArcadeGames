using UnityEngine;

public class Race_ground_control : MonoBehaviour
{

    [SerializeField] private Race_PlayerController player;
    [SerializeField] private Animator ground_animator;

    private void Start()
    {
        ground_animator = GetComponent<Animator>();
    }


    //���� ����Ʈ�� ���� ������ �ִϸ��̼� �ӵ� ����
    void FixedUpdate()
    {
        ground_animator.speed = player.speed * Time.deltaTime;
    }


    //Ŀ�걸���϶� Race_Move_Control ��ũ��Ʈ�κ��� ȣ�����
    public void Curve_move_Right(float move_num_x)
    {
        transform.position = new Vector3(move_num_x, transform.position.y);
        
    }
    public void Curve_move_Return(float move_num_x)
    {
        transform.position = new Vector3(-move_num_x, transform.position.y);
    }

}
