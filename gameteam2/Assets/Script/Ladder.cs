using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{
    public Collider2D platformCollider;
    //사다리 밑으로도 뚫기

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) //플레이어일경우 뚫기
        {
            Physics2D.IgnoreCollision(collision.GetComponent<Collider2D>(), platformCollider, true);
        }
    }

    //사다리 빠져나오면 false로 만들기
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Physics2D.IgnoreCollision(collision.GetComponent<Collider2D>(), platformCollider, false);
        }
    }
}
