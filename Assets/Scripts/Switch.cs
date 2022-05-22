using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Switch : MonoBehaviour
{

    [SerializeField] GameObject door;

    PlayerInput controls;
    bool playerPresent;
    bool flipped;

    void Start()
    {
        controls = new PlayerInput();
        controls.Player.Fire.performed += context => Flip();
        controls.Enable();
    }

    void Flip()
    {
        if (playerPresent)
        {
            if (!flipped)
            {
                Debug.Log("Flipped");
                door.SetActive(false);
                flipped = true;
            }
            else
            {
                Debug.Log("UnFlipped");
                door.SetActive(true);
                flipped = false;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
            playerPresent = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
            playerPresent = false;
    }



}
