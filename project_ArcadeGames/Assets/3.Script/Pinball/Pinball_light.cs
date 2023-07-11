using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pinball_light : MonoBehaviour
{
    [SerializeField] private GameObject _light;

    void Start()
    {
        //����, ù��° �ڽ� ������Ʈ�� light�̵��� ���̾��Ű�� ��ġ�Ͽ��� �Ѵ� //���� light ���� �ڽĿ�����Ʈ�� ������
        _light = transform.GetChild(0).gameObject;
        _light.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        StartCoroutine(Light_co());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(Light_co());
    }

    IEnumerator Light_co()
    {
        _light.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        _light.SetActive(false);
        StopCoroutine(Light_co());
        yield break;
    }
}
