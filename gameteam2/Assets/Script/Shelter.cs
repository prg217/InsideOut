using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shelter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //쉘터 태그를 만났을 때 좌 컨트롤 누르고 있을때 동안 플레이어 레이어를 Hide로 바꿔주기(애니메이션도 넣어야혀...)
    private void OnTriggerStay2D(Collider2D collision) //접촉하고 있을 때
    {
        if (collision.CompareTag("Player"))
        {
            if (Input.GetKey(KeyCode.LeftControl)) //좌 컨트롤 누르고 있을 동안만
            {
                GameObject.Find("Player").layer = 6; //Hide
                Player.move = false;
            }
            else //떼었을 때
            {
                GameObject.Find("Player").layer = 0; //디폴트(다시 몬스터 맞음)
                Player.move = true;
            }
        }
    }
}
