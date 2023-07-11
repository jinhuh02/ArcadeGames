using UnityEngine;

public class Pinball_ball : MonoBehaviour
{
    [SerializeField] private Pinball_player_controller player;
    private Rigidbody2D _rigidbody;


    void Start()
    {
        _rigidbody = gameObject.GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        gameObject.transform.position = new Vector3(3.505f, 0.4f);
    }


    public void Start_pinball(float ball_start_power)
    {
        if(gameObject.transform.position.x < 3.7f && gameObject.transform.position.y < -1.1f)
        {
            _rigidbody.velocity = Vector2.up * ball_start_power;
        }
    }

    private void OnTriggerEnter2D(Collider2D Trigger)
    {
        if (Trigger.gameObject.CompareTag("Dead"))
        {
            player.Dead_ball_pinball();
            gameObject.SetActive(false);
        }
    }
}
