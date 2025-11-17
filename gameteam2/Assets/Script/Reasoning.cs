using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reasoning : MonoBehaviour
{
    public ClueId myid;

    private bool isChoice = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Down()
    {
        Debug.Log("클릭");
        //이미지 파일을 어둡게 하든 외곽선 있게하든 일단 바꾸기 코드 추가 바람
        isChoice = true;

        if (isChoice)
        {
            GameObject.Find("chury").GetComponent<chury>().Save(myid); //번호에 따라 로그 입력
        }
        else
        {

        }
    }
}
