using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 3f;
    [SerializeField]
    private float random = 0;
    [SerializeField]
    private GameObject monsterObj = null;
    [SerializeField]
    private GameObject monsterPos = null;
    //HP 변수 만들어야겠어~

    void Start()
    {
        InvokeRepeating("RandomMonster", 10, 3); //10초후 부터, _Random함수를 3초마다 반복해서 실행 시킵니다.
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();

        //만약 단서가 0개면 여긴 단서가 없어...라고 말함
        //숨을때 레이어 바꾸기 프로젝트세팅 -피직스 -레이어 콜리즌 메트릭스들어가면 이 레이어끼리 콜라이더를 할거냐 안할거냐(이것도 강의에 있던 것 같아) 박스 콜라이더 닳으면 HP닳아
        //몬스터 닿으면 이미지 띄우고 HP 닳아야지 그 후 애니메이션 쓰러짐->일어남... 이건 좀 애매한데 못하겠음 기획자한테 말하기
    }

    private void PlayerMove()
    {
        float h = Input.GetAxis("Horizontal");
        float playerSpeed = h * moveSpeed * Time.deltaTime;
        Vector3 vector3 = new Vector3();
        vector3.x = playerSpeed;
        transform.Translate(vector3);

        if (h < 0)
        {
            //GetComponent<Animator>().SetBool("Walk", true);
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (h == 0)
        {
            //GetComponent<Animator>().SetBool("Walk", false);
        }
        else
        {
            //GetComponent<Animator>().SetBool("Walk", true);
            transform.localScale = new Vector3(1, 1, 1);
        }
    }

    private void RandomMonster()
    {
        if (GameManager.instance.IsMonster == false) //몬스터
        {
            random = Random.Range(0, 1000);

            if (random > 900)
            {
                GameManager.instance.IsMonster = true;
                GameObject monster = (GameObject)Instantiate(monsterObj, monsterPos.transform.position, Quaternion.identity);
            }
        }
    }
}
