using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Switch : MonoBehaviour
{

    [SerializeField] GameObject door;

    PlayerInput controls;
    bool playerPresent;
    bool isFlipped;
    [SerializeField] bool isOneWay;

    [SerializeField] Sprite unFlipped;
    [SerializeField] Sprite flipped;
    SpriteRenderer rend;

    void Start()
    {
        controls = new PlayerInput();
        controls.Player.Fire.performed += context => Flip();
        controls.Enable();

        rend = GetComponent<SpriteRenderer>();
    }

    void Flip()
    {
        if (playerPresent)
        {
            if (!isFlipped)
            {
                if (door != null) door.SetActive(false);
                rend.sprite = flipped;
                isFlipped = true;
            }
            else
            {
                if (isOneWay) return;

                if (door != null) door.SetActive(true);
                rend.sprite = unFlipped;
                isFlipped = false;
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
