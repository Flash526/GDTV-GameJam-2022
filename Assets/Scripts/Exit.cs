using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    [SerializeField] string nextLevel;
    [SerializeField] Sprite openDoorSprite;
    SpriteRenderer rend;

    PlayerInput controls;
    bool playerPresent;
    bool isOpen;


    void Start()
    {
        controls = new PlayerInput();
        controls.Player.Fire.performed += context => Enter();
        controls.Enable();

        rend = GetComponent<SpriteRenderer>();
    }

    void Enter()
    {
        if (playerPresent && isOpen)
        {
            isOpen = false;
            SceneManager.LoadScene(nextLevel);
        }
    }

    public void OpenDoor()
    {
        isOpen = true;
        rend.sprite = openDoorSprite;
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
            playerPresent = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
            playerPresent = false;
    }

}
