using UnityEngine;

public class Pinball_sound_play : MonoBehaviour
{
    private AudioSource _audio;

    void Start()
    {
        _audio = gameObject.GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _audio.Play();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //조건, 젤리일 경우 오브젝트의 태그를 Jelly로 설정해두어야 한다
        if (gameObject.CompareTag("Jelly"))
        {
            Pinball_get_point point = gameObject.GetComponent<Pinball_get_point>();
            if (point.timer <= 1) 
            {
                _audio.Play();
            }
            else 
            { 
                return; 
            }
        }
        else
        {
            _audio.Play();
        }
    }
}
