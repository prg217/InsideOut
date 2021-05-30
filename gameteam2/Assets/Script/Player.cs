using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D myrigidbody;

    [SerializeField]
    private float moveSpeed = 5f;
    [SerializeField]
    private float random = 0;
    [SerializeField]
    private GameObject monsterObj = null;
    [SerializeField]
    private GameObject monsterPos = null;

    //public int HP = 20;

    void Start()
    {
        InvokeRepeating("RandomMonster", 10, 3); //10초후 부터, _Random함수를 3초마다 반복해서 실행 시킵니다.
        myrigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();

        //만약 단서가 0개면 여긴 단서가 없어...라고 말함
        //숨을때 레이어 바꾸기 프로젝트세팅 -피직스 -레이어 콜리즌 메트릭스들어가면 이 레이어끼리 콜라이더를 할거냐 안할거냐(이것도 강의에 있던 것 같아) 박스 콜라이더 닳으면 HP닳아
        //몬스터 닿으면 이미지 띄우고 HP 닳아야지 그 후 애니메이션 쓰러짐->일어남... 이건 좀 애매한데 못하겠음 기획자한테 말하기
    }

    private void FixedUpdate()
    {
        if(isLadder)
        {
            float ver = Input.GetAxis("Vertical");
            myrigidbody.gravityScale = 0;
            myrigidbody.velocity = new Vector2(myrigidbody.velocity.x, ver * moveSpeed);
        }

        else
        {
            myrigidbody.gravityScale = 5f;
        }

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
            transform.localScale = new Vector3(-7, 7, 7);
        }
        else if (h == 0)
        {
            //GetComponent<Animator>().SetBool("Walk", false);
        }
        else
        {
            //GetComponent<Animator>().SetBool("Walk", true);
            transform.localScale = new Vector3(7, 7, 7);
        }
    }

    //사다리(?)이동
    public bool isLadder;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Ladder"))//사다리 인식하기 ladder라는 태그를 만나면?
        {
            isLadder = true;
            
            //사다리가 true면 위아래로 움직이게 한다
            //Debug.Log("사다리 만남");
        }
        if (collision.CompareTag("Monster"))
        {
            //Debug.Log("접촉");
            //HP.hp -= 2f;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)//사다리 빠져나오면?
    {
        if (collision.CompareTag("Ladder"))//ladder라는 태그를 만나면?
        {
            isLadder = false;
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
