using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Change_S : MonoBehaviour
{

    SpriteRenderer sprite;

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();

        sprite.enabled = false;
    }



    // Update is called once per frame


    private void OnTriggerEnter2D(Collider2D collision) //접촉하고 있을 때
    {

        if (collision.CompareTag("Player"))
        {
            sprite.enabled = true;

        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {
            sprite.enabled = false;

        }
    }

}
