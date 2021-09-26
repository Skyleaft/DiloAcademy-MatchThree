using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIGameOver : MonoBehaviour
{
    public AudioSource audioBGM;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void Show()
    {
        gameObject.SetActive(true);
        audioBGM.Stop();
        SoundManager.Instance.PlayGameOver();
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
