using UnityEngine;
using UnityEngine.SceneManagement;

public class AnyKey_SceneMove : MonoBehaviour
{
    [SerializeField] string scene_name;

    void Update()
    {
        if (Input.anyKey)
        {
            SceneManager.LoadScene(scene_name);
        }
    }
}
