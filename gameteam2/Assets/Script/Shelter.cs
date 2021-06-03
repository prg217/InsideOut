using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shelter : MonoBehaviour
{
    static public bool isHide;


    void Start()
    {
        isHide = false;
    }


    //쉘터 태그를 만났을 때 좌 컨트롤 누르고 있을때 동안 플레이어 레이어를 Hide로 바꿔주기
    private void OnTriggerStay2D(Collider2D collision) //접촉하고 있을 때
    {
        if (collision.CompareTag("Shelter"))
        {
            if (Input.GetKey(KeyCode.LeftControl)) //좌 컨트롤 누르고 있을 동안만
            {
                GameObject.Find("Player").layer = 6; //Hide
                // Player.move = false;
                
                isHide = true;

            }
            else //떼었을 때
            {
                GameObject.Find("Player").layer = 0; //디폴트(다시 몬스터 맞음)

                isHide = false;
            }
        }
    }
}
