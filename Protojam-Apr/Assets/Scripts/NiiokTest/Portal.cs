using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    [SerializeField]
    string sceneToLoad;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Fader.Instance.LoadScene(sceneToLoad);
    }
}
