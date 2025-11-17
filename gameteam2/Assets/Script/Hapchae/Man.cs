using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Man : MonoBehaviour
{
    private bool isIn = false;
    private bool isTalk = false;

    public ClueId myid;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        if (isTalk == false && isIn && Input.GetKeyDown(KeyCode.Space)) //높이 있는 물체는 바닥까지 박스 콜라이더를 늘릴것!!
        {
            isTalk = true;
            GameObject.Find("TalkManager").GetComponent<TalkManager>().Log(myid); //번호에 따라 로그 입력
            GameObject.Find("TalkManager").GetComponent<TalkManager>().ShowDialogue(); //쇼다이얼 함수 불러옴
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) //접촉하고 있을 때
    {
        if (collision.CompareTag("Player"))
        {
            isIn = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isIn = false;
            isTalk = false;
        }
    }
}

