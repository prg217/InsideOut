using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Spawn : MonoBehaviour
{
    public Transform target; // 따라갈 타겟의 트랜스 폼

    private float relativeHeigth = 4.0f; // 높이 즉 y값
    private float xDistance = 0f; // x값

    private bool isIn = false;

    public Selection myid;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 newPos = target.position + new Vector3(-xDistance, relativeHeigth, 0); // 타겟 포지선에 해당 위치를 더해.. 즉 타겟 주변에 위치할 위치를 담는다.. 일정의 거리를 구하는 방법
        transform.position = newPos;
    }

    // Update is called once per frame
    void Update()
    {
        if (isIn && Input.GetKeyDown(KeyCode.Space))
        {
            //일단 질문->단서 선택->질문->단서 선택 반복하게 하자
            GameObject.Find("TalkManager").GetComponent<TalkManager>().SLog(myid); //번호에 따라 로그 입력
            GameObject.Find("TalkManager").GetComponent<TalkManager>().ShowDialogue(); //쇼다이얼 함수 불러옴

            Destroy(gameObject);
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
        }
    }
}