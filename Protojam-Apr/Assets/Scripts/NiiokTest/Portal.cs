using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    [SerializeField]
    Collider2D trigger;
    [SerializeField]
    string sceneName;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var handle = SceneManager.LoadSceneAsync(sceneName);
        //handle.
    }
}
