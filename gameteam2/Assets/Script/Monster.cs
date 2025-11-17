using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    //박스콜라이더 사용해서 부딪히는거 만들기
    [SerializeField]
    private float moveSpeed = 4f;
    [SerializeField]
    private float direction = 1f;

    Animator animator1;

    static public bool M_isWalk = false;

    //몬스터 한 방향에서만 스폰되게 스폰의 x축을 고정하거나 아님 소환때 플레이어 방향으로 쫓아오게... 아니면 숨으면 인식 못하고 지나가기

    // Start is called before the first frame update
    void Start()
    {
        animator1 = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(M_isWalk)
        {
            
            float speed = moveSpeed * Time.deltaTime * direction;
            Vector3 vector = new Vector3(speed, 0, 0);
            transform.Translate(vector);

            animator1.SetBool("isWalk_M", true);

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Wall") //벽에 부딪히면 없어짐
        {
            GameManager.IsMonster = false;
            Destroy(gameObject, 2f);
        }

        if (collision.collider.tag == "Player") //플레이어랑 부딪히면 안부딪히던거 레이어 문제였음 숨기는 애니메이션과 레이어만 바꿔줌 되는듯
        {
            GameManager.IsMonster = false;
            //GameManager.instance.HP -= 2;
            HP.hp -= 2f;
            Destroy(gameObject);
        }

    }
}
