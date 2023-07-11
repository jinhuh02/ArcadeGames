using UnityEngine;

public class Race_EnemyCar_Control : MonoBehaviour
{
    [SerializeField] private Race_PlayerController player;
    [SerializeField] private Animator enemy_animator;
    [SerializeField] private Race_Move_Control move;

    private bool Seat;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Race_PlayerController>();
        enemy_animator = gameObject.GetComponent<Animator>();
        move = GameObject.FindGameObjectWithTag("GameController").GetComponent<Race_Move_Control>();
        transform.localScale = new Vector2(0, 0);
    }

    private void OnEnable()
    {
        transform.localScale = new Vector2(0, 0);
        transform.position = new Vector2(0, 0.7f);

        //true=왼쪽  false=오른쪽
        if(Random.Range(0, 2).Equals(0))
        {
            Seat = true;
        }
        else
        {
            Seat = false;
        }
    }

    private void FixedUpdate()
    {
        //에너미는 꾸준히 아래로 내려간다 -y
        //플레이어 스피드가 0일 경우 빠른 속도로 +y되며 (0.015)
        //플레이어 스피드가 500일 경우 빠른 속도로 -y된다 (-0.035)
        //플레이어 스피드가 150일 경우 y가 변하지 않는다 (0)

        Down_speed();
        LocalScale_switch();
        Follow_Point_x(transform.position.y);

        Curve_Enemy_Car(transform.position.y);
        Enemy_Animator_Control(move.map.curve || move.map.c_return);
    }

    //플레이어의 스피드에 따라 내려오는 속도가 달라짐
    public void Down_speed()
    {
        float downSpeed =  ((player.speed - 150) / 10000);
        transform.position += new Vector3(0, -downSpeed);
    }

    void LocalScale_switch()
    {
        //y의 위치에 따라
        //로컬스케일 조절 (0,0) -> (4, 4)
        if (transform.position.y > 3f)         { transform.localScale = new Vector2(0f, 0f); gameObject.SetActive(false); }
        else if (transform.position.y > 0.7f)  { transform.localScale = new Vector2(0f, 0f); } //-0.14  0.21
        else if (transform.position.y > 0.6f)  { transform.localScale = new Vector2(0.5f, 0.5f); } //-0.19 0.23
        else if (transform.position.y > 0.4f)  { transform.localScale = new Vector2(0.6f, 0.6f); } //-0.31  0.35
        else if (transform.position.y > 0.3f)  { transform.localScale = new Vector2(0.8f, 0.8f); } //-0.39  0.44
        else if (transform.position.y > 0.2f)  { transform.localScale = new Vector2(1f, 1f); } //-0.44  0.5
        else if (transform.position.y > 0.1f)  { transform.localScale = new Vector2(1.5f, 1.5f); } //-0.53  0.64
        else if (transform.position.y > 0f)    { transform.localScale = new Vector2(2f, 2f); } //-0.69  0.71
        else if (transform.position.y > -0.1f) { transform.localScale = new Vector2(2.5f, 2.5f); } //-0.75  0.87
        else if (transform.position.y > -0.2f) { transform.localScale = new Vector2(3f, 3f); } //-0.83  0.94
        else if (transform.position.y > -0.3f) { transform.localScale = new Vector2(3.2f, 3.2f); } //-0.89 -0.99
        else if (transform.position.y > -0.4f) { transform.localScale = new Vector2(3.5f, 3.5f); } //-0.97  1.08
        else if (transform.position.y > -0.5f) { transform.localScale = new Vector2(3.7f, 3.7f); } //-1  1.2
        else if (transform.position.y > -0.6f) { transform.localScale = new Vector2(4f, 4f); } //-1.13  1.2
        else if (transform.position.y < -5f)   { transform.localScale = new Vector2(0, 0); gameObject.SetActive(false); }
    }


    //반의 확률로 왼쪽 오른쪽 갈림
    void Follow_Point_x(float y_pos)
    {
        if (Seat)
        {
            //왼쪽
            if (y_pos > 0.7f) { transform.position = new Vector2(-0.14f, y_pos); } //-0.14  0.21
            else if (y_pos > 0.6f) { transform.position = new Vector2(-0.19f, y_pos); } //-0.19 0.23
            else if (y_pos > 0.4f) { transform.position = new Vector2(-0.31f, y_pos); } //-0.31  0.35
            else if (y_pos > 0.3f) { transform.position = new Vector2(-0.39f, y_pos); } //-0.39  0.44
            else if (y_pos > 0.2f) { transform.position = new Vector2(-0.44f, y_pos); } //-0.44  0.5
            else if (y_pos > 0.1f) { transform.position = new Vector2(-0.53f, y_pos); } //-0.53  0.64
            else if (y_pos > 0f) { transform.position = new Vector2(-0.69f, y_pos); } //-0.69  0.71
            else if (y_pos > -0.1f) { transform.position = new Vector2(-0.75f, y_pos); } //-0.75  0.87
            else if (y_pos > -0.2f) { transform.position = new Vector2(-0.83f, y_pos); } //-0.83  0.94
            else if (y_pos > -0.3f) { transform.position = new Vector2(-0.89f, y_pos); } //-0.89 -0.99
            else if (y_pos > -0.4f) { transform.position = new Vector2(-0.97f, y_pos); } //-0.97  1.08
            else if (y_pos > -0.5f) { transform.position = new Vector2(-1f, y_pos); } //-1  1.2
            else if (y_pos > -0.6f) { transform.position = new Vector2(-1.13f, y_pos); } //-1.13  1.2
            else if (y_pos > -0.8f) { transform.position = new Vector2(-1.2f, y_pos); } //-1.2  1.4
            else if (y_pos > -1f) { transform.position = new Vector2(-1.43f, y_pos); } //-1.43  1.48
            else if (y_pos > -1.5f) { transform.position = new Vector2(-1.85f, y_pos); } //-1.85  1.94
            else if (y_pos > -2f) { transform.position = new Vector2(-2.45f, y_pos); } //-2.45  2.13
            else if (y_pos > -2.5f) { transform.position = new Vector2(-2.5f, y_pos); } //-2.5  2.7
            else if (y_pos > -3f) { transform.position = new Vector2(-2.85f, y_pos); } //-2.85  3.35
            else if (y_pos > -3.5f) { transform.position = new Vector2(-3.4f, y_pos); } //-3.4  3.21
            else if (y_pos > -4f) { transform.position = new Vector2(-4.51f, y_pos); } //-4.51  4.17
        }
        else
        {
            //오른쪽
            if (y_pos > 0.7f) { transform.position = new Vector2(0.21f, y_pos); } //-0.14  0.21
            else if (y_pos > 0.6f) { transform.position = new Vector2(0.23f, y_pos); } //-0.19 0.23
            else if (y_pos > 0.4f) { transform.position = new Vector2(0.35f, y_pos); } //-0.31  0.35
            else if (y_pos > 0.3f) { transform.position = new Vector2(0.44f, y_pos); } //-0.39  0.44
            else if (y_pos > 0.2f) { transform.position = new Vector2(0.5f, y_pos); } //-0.44  0.5
            else if (y_pos > 0.1f) { transform.position = new Vector2(0.64f, y_pos); } //-0.53  0.64
            else if (y_pos > 0f) { transform.position = new Vector2(0.71f, y_pos); } //-0.69  0.71
            else if (y_pos > -0.1f) { transform.position = new Vector2(0.87f, y_pos); } //-0.75  0.87
            else if (y_pos > -0.2f) { transform.position = new Vector2(0.94f, y_pos); } //-0.83  0.94
            else if (y_pos > -0.3f) { transform.position = new Vector2(0.99f, y_pos); } //-0.89 0.99
            else if (y_pos > -0.4f) { transform.position = new Vector2(1.08f, y_pos); } //-0.97  1.08
            else if (y_pos > -0.5f) { transform.position = new Vector2(1.2f, y_pos); } //-1  1.2
            else if (y_pos > -0.6f) { transform.position = new Vector2(1.2f, y_pos); } //-1.13  1.2
            else if (y_pos > -0.8f) { transform.position = new Vector2(1.4f, y_pos); } //-1.2  1.4
            else if (y_pos > -1f) { transform.position = new Vector2(1.48f, y_pos); } //-1.43  1.48
            else if (y_pos > -1.5f) { transform.position = new Vector2(1.94f, y_pos); } //-1.85  1.94
            else if (y_pos > -2f) { transform.position = new Vector2(2.13f, y_pos); } //-2.45  2.13
            else if (y_pos > -2.5f) { transform.position = new Vector2(2.7f, y_pos); } //-2.5  2.7
            else if (y_pos > -3f) { transform.position = new Vector2(3.35f, y_pos); } //-2.85  3.35
            else if (y_pos > -3.5f) { transform.position = new Vector2(3.21f, y_pos); } //-3.4  3.21
            else if (y_pos > -4f) { transform.position = new Vector2(4.17f, y_pos); } //-4.51  4.17
        }
    }


    //만약 커브면
    //ground[]에 따라 꺾어
    void Curve_Enemy_Car(float y_pos)
    {

        //ground x만큼 이동
        if (y_pos > 0.7f) { transform.position += new Vector3(move.ground[0].transform.position.x, 0); } 
        else if (y_pos > 0.6f) { transform.position += new Vector3(move.ground[1].transform.position.x, 0); } 
        else if (y_pos > 0.4f) { transform.position += new Vector3(move.ground[3].transform.position.x, 0); } 
        else if (y_pos > 0.3f) { transform.position += new Vector3(move.ground[4].transform.position.x, 0); } 
        else if (y_pos > 0.2f) { transform.position += new Vector3(move.ground[5].transform.position.x, 0); } 
        else if (y_pos > 0.1f) { transform.position += new Vector3(move.ground[6].transform.position.x, 0); } 
        else if (y_pos > 0f) { transform.position += new Vector3(move.ground[7].transform.position.x, 0); } 
        else if (y_pos > -0.1f) { transform.position += new Vector3(move.ground[8].transform.position.x, 0); }
        else if (y_pos > -0.2f) { transform.position += new Vector3(move.ground[9].transform.position.x, 0); }
        else if (y_pos > -0.3f) { transform.position += new Vector3(move.ground[10].transform.position.x, 0); }
        else if (y_pos > -0.4f) { transform.position += new Vector3(move.ground[11].transform.position.x, 0); }
        else if (y_pos > -0.5f) { transform.position += new Vector3(move.ground[12].transform.position.x, 0); } 
        else if (y_pos > -0.6f) { transform.position += new Vector3(move.ground[13].transform.position.x, 0); }
        else if (y_pos > -0.8f) { transform.position += new Vector3(move.ground[15].transform.position.x, 0); } 
        else if (y_pos > -1f) { transform.position += new Vector3(move.ground[20].transform.position.x, 0); } 
        else if (y_pos > -1.5f) { transform.position += new Vector3(move.ground[25].transform.position.x, 0); }
        else if (y_pos > -2f) { transform.position += new Vector3(move.ground[30].transform.position.x, 0); } 
        else if (y_pos > -2.5f) { transform.position += new Vector3(move.ground[35].transform.position.x, 0); } 
        else if (y_pos > -3f) { transform.position += new Vector3(move.ground[40].transform.position.x, 0); } 
        else if (y_pos > -3.5f) { transform.position += new Vector3(move.ground[45].transform.position.x, 0); } 
        else if (y_pos > -4f) { transform.position += new Vector3(move.ground[50].transform.position.x, 0); }
    }

    public void Enemy_Animator_Control(bool Curve_is_true) 
    {
        enemy_animator.SetBool("Curve", Curve_is_true);
    }

}
