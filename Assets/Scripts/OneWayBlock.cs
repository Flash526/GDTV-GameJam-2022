using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneWayBlock : MonoBehaviour
{
    [SerializeField] Sprite activatedSprite;
    BoxCollider2D boxCollider;
    SpriteRenderer rend;
    bool isFlipped;



    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();
        boxCollider.isTrigger = true;
        this.gameObject.layer = LayerMask.NameToLayer("Default");
    }


    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            boxCollider.isTrigger = false;
            rend.sprite = activatedSprite;
            this.gameObject.layer = LayerMask.NameToLayer("Ground");
        }
    }
}
