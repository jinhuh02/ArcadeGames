using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pinball_light : MonoBehaviour
{
    [SerializeField] private GameObject _light;

    void Start()
    {
        //조건, 첫번째 자식 오브젝트가 light이도록 하이어라키를 배치하여야 한다 //차피 light 외의 자식오브젝트도 없지만
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
