using System.Collections;
using UnityEngine;

public class Pinball_get_point : MonoBehaviour
{
    [SerializeField] private Pinball_player_controller player;
    [SerializeField] private SpriteRenderer sprite;
    [SerializeField] private int point;

    //����, ������ ��� �ν����� â���� üũ������Ѵ�
    [SerializeField] bool jelly;
    Color Transparent;
    public float timer = 0;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Pinball_player_controller>();
        sprite = gameObject.GetComponent<SpriteRenderer>();

        Transparent.r = 1;
        Transparent.g = 1;
        Transparent.b = 1;
        Transparent.a = 0;
        timer = 0;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //���ΰ� ���� ��ü�� ball�̶�� ����Ʈ ��
        if (collision.gameObject.CompareTag("ball"))
        {
            player.Score_up_pinball(point);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ball") && timer.Equals(0))
        {
            player.Score_up_pinball(point);

            if (jelly)
            {
                Transparent.a = 0;
                sprite.color = Transparent;
                StartCoroutine(nameof(Jelly_spawn_count));
            }
        }
    }

    IEnumerator Jelly_spawn_count()
    {
        while (true)
        {
            timer++;
            yield return new WaitForSeconds(1f);
            if (timer >= 3)
            {
                timer = 0;
                break;
            }
        }

        Transparent.a = 1;
        sprite.color = Transparent;
        StopCoroutine(nameof(Jelly_spawn_count));
        yield break;
    }
}
