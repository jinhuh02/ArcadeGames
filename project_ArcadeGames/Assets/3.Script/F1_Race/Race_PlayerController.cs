using System.Collections;
using UnityEngine;

public class Race_PlayerController : MonoBehaviour
{
    [SerializeField] private Animator player_car_animator;

    [SerializeField] private Race_UI ui;
    [SerializeField] private GameObject start_countdown; 
    [SerializeField] private GameObject Camera;

    public AudioSource _audio;
    [SerializeField] private AudioSource audio_dead;
    [SerializeField] private AudioSource audio_Warning;

    [SerializeField] private AudioClip start_Engine_clip;
    [SerializeField] private AudioClip Warning_clip;
    [SerializeField] private AudioClip dead_clip;
    [SerializeField] private AudioClip Gear_Low_clip;
    [SerializeField] private AudioClip Gear_HI_clip;

    private Color revive_color;
    private SpriteRenderer car_image;

    float start_countdown_waiting;
    bool Input_Left;
    public bool Input_Right;
    float Input_Speed;

    public float speed;
    private bool Gear_switch;
    public bool ending;
    private bool dead_penalty;

    int dead_countdown = 0;

    void Start()
    {
        car_image = gameObject.GetComponent<SpriteRenderer>();
        audio_dead.clip = dead_clip;
        audio_Warning.clip = Warning_clip;
        start_countdown_waiting = 5;
        Input_Left = false;
        Input_Right = false;
        speed = 0;
        Gear_switch = false;
        dead_countdown = 0;
        ending = false;
        dead_penalty = false;
        revive_color.r = 1;
        revive_color.g = 1;
        revive_color.b = 1;
        revive_color.a = 1;
        player_car_animator.speed = speed * Time.deltaTime;
        _audio.clip = start_Engine_clip;
        _audio.Play();
        Instantiate(start_countdown);
    }

    void Update()
    {
        //스타트 카운트다운(5초)를 기다린 후 플레이어의 입력을 받도록
        if (start_countdown_waiting > 0)
        {
            start_countdown_waiting -= Time.deltaTime;
            if (start_countdown_waiting <= 0)
            {
                _audio.clip = Gear_Low_clip;
                _audio.Play();
            }
            return;
        }


        //엔딩일 경우 입력하지 못하도록
        //트리거 발동시에도
        if (!ending && !dead_penalty)
        {
            //애니메이션 속도
            player_car_animator.speed = speed * Time.deltaTime;


            //왼쪽 화살표 키
            if (Input.GetKeyDown(KeyCode.LeftArrow)) { Input_Left = true; }
            if (Input.GetKeyUp(KeyCode.LeftArrow)) { Input_Left = false; }

            //오른쪽 화살표 키
            if (Input.GetKeyDown(KeyCode.RightArrow)) { Input_Right = true; }
            if (Input.GetKeyUp(KeyCode.RightArrow)) { Input_Right = false; }

            //위, 아래 
            Input_Speed = Input.GetAxisRaw("Vertical");

            //스페이스 (LOW<->HI) 기어 바꾸기
            if (Input.GetKeyDown(KeyCode.Space))
            {
                switch (Gear_switch)
                {
                    case true: //기어를 HI로
                        if (_audio.clip == Gear_HI_clip)
                        {
                            _audio.clip = Gear_Low_clip;
                            _audio.Play();
                        }
                        Gear_switch = false;
                        break;
                    case false: //기어를 LOW로
                        
                        if (_audio.clip == Gear_Low_clip)
                        {
                            _audio.clip = Gear_HI_clip;
                            _audio.Play();
                        }
                        Gear_switch = true;
                        break;
                }
                ui.Gear();
            };

            //애니메이션 제어
            player_car_animator.SetBool("Left_move", Input_Left); //왼쪽
            player_car_animator.SetBool("Right_move", Input_Right); //오른쪽
            player_car_animator.SetFloat("Input_UP", Input_Speed); //위+왼쪽 or 위+오른쪽


            //위를 누르면 속도 올라감
            if (Input_Speed.Equals(1) && speed < 500)
            {
                //기어 LOW일때
                if (Gear_switch.Equals(false))
                {
                    if (speed < 100) { speed += 100f * Time.deltaTime; ; }
                    else if (speed < 200) { speed += 10f * Time.deltaTime; ; }
                    else if (speed > 200) { speed += 5f * Time.deltaTime; ; }
                }
                //기어 HI일때
                else
                {
                    if (speed < 100) { speed += 5f * Time.deltaTime;  Debug.Log("기어가 HI입니다! 스페이스를 눌러 바꿔주세요!"); }
                    else if (speed < 200) { speed += 50f * Time.deltaTime; ; }
                    else if (speed > 200) { speed += 70f * Time.deltaTime; ; }
                }

            }

            //아래를 누르면 속도 내려감
            if (Input_Speed.Equals(-1) && speed > 0.3)
            {
                speed -= 70f * Time.deltaTime; ;
            }

            //속도계 
            ui.Speedometer((int)speed);
            //스피드에따른 스코어업
            ui.Score_up(speed / 10000);

            //방향키를 눌러 좌우로 이동
            if (Input_Left.Equals(true) && !speed.Equals(0))
            {
                transform.position += new Vector3(-10f, 0) * Time.deltaTime;
                Camera.transform.position += new Vector3(-10f, 0) * Time.deltaTime;
            }
            if (Input_Right.Equals(true) && !speed.Equals(0))
            {
                transform.position += new Vector3(10f, 0) * Time.deltaTime;
                Camera.transform.position += new Vector3(10f, 0) * Time.deltaTime;
            }

        }
    }

    //커브 구간일 경우 스피드에 따라 강제 -x 이동 (Race_Move_Control로부터 호출받음)
    public void Curve_on(float Curve_speed)
    {
        transform.position += new Vector3(-Curve_speed, 0) * Time.deltaTime;
        Camera.transform.position += new Vector3(-Curve_speed, 0) * Time.deltaTime;
    }

    //장애물과 부딪히면
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("Dead") && ending.Equals(false) && dead_penalty.Equals(false))
        {
            dead_penalty = true;

            Input_Left = false;
            Input_Right = false;
            Input_Speed = 0;

            speed = 0;

            _audio.Stop();
            audio_dead.Play();
            StartCoroutine(nameof(Revive));
        }

        if (coll.gameObject.CompareTag("Wall") && ending.Equals(false))
        {
            audio_Warning.Play();
        }
    }

    IEnumerator Revive()
    {
        while (true)
        {
            dead_countdown++;
            player_car_animator.speed = 1;//이거 왜 안될까
            player_car_animator.SetBool("Dead", true);

            yield return new WaitForSeconds(1f);
            if(dead_countdown > 2)
            {
                dead_countdown = 0;
                break;
            }
        }

        _audio.Play();
        dead_penalty = false;
        player_car_animator.SetBool("Dead", false);

        while (true)
        {
            switch (revive_color.a)
            {
                case 0:
                    revive_color.a = 1;
                    break;
                case 1:
                    revive_color.a = 0;
                    break;
            }
            car_image.color = revive_color;
            dead_countdown++;
            if (dead_countdown > 4)
            {
                dead_countdown = 0;
                break;
            }
            yield return new WaitForSeconds(0.4f);
        }

        revive_color.a = 1;
        car_image.color = revive_color;
        StopCoroutine(nameof(Revive));
        yield break;
    }

    //게임이 종료되면 Game_End 스크립트로부터 호출받음
    public void Stop_co()
    {
        StopAllCoroutines();
    }

}
