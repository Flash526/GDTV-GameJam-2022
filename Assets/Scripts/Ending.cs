using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ending : MonoBehaviour
{
    [SerializeField] GameObject endCanvas;

    public void BackToTitle()
    {
        SceneManager.LoadScene("TitleScreen");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            endCanvas.SetActive(true);
            FindObjectOfType<PlayerController>().enabled = false;
        }
    }

}
