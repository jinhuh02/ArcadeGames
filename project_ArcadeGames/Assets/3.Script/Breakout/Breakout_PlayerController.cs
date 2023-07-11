using UnityEngine;

public class Breakout_PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody2D bar_rigidbody;
    [SerializeField] private AudioSource bounce_ball_audio;

    void Start()
    {
        if (speed == 0)
        {
            speed = 10f;
        }

        bar_rigidbody = gameObject.GetComponent<Rigidbody2D>();
        bounce_ball_audio = gameObject.GetComponent<AudioSource>();
    }

    void Update()
    {
        float playerInput = Input.GetAxisRaw("Horizontal");

        switch (playerInput)
        {
            case -1:
                bar_rigidbody.velocity = Vector2.left * speed;
                break;

            case 1:
                bar_rigidbody.velocity = Vector2.right * speed;
                break;

            default:
                bar_rigidbody.velocity = Vector2.zero;
                break;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ball"))
        {
            bounce_ball_audio.Play();
            
            //공에 닿을 때마다 x스케일이 줄어들음 (그래도 없어지면 안되니까 1f 남겨두자)
            if(transform.localScale.x >= 1f)
            {
                transform.localScale = new Vector2(transform.localScale.x - 0.3f, transform.localScale.y);
            }
        }
    }
}
