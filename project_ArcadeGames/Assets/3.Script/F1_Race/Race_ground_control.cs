using UnityEngine;

public class Race_ground_control : MonoBehaviour
{

    [SerializeField] private Race_PlayerController player;
    [SerializeField] private Animator ground_animator;

    private void Start()
    {
        ground_animator = GetComponent<Animator>();
    }


    //차의 스피트에 따라 도로의 애니메이션 속도 조절
    void FixedUpdate()
    {
        ground_animator.speed = player.speed * Time.deltaTime;
    }


    //커브구간일때 Race_Move_Control 스크립트로부터 호출받음
    public void Curve_move_Right(float move_num_x)
    {
        transform.position = new Vector3(move_num_x, transform.position.y);
        
    }
    public void Curve_move_Return(float move_num_x)
    {
        transform.position = new Vector3(-move_num_x, transform.position.y);
    }

}
