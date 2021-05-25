using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    //박스콜라이더 사용해서 부딪히는거 만들기
    [SerializeField]
    private float moveSpeed = 2f;
    [SerializeField]
    private float direction = 1f;

    //몬스터 한 방향에서만 스폰되게 스폰의 x축을 고정하거나 아님 소환때 플레이어 방향으로 쫓아오게... 아니면 숨으면 인식 못하고 지나가기

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float speed = moveSpeed * Time.deltaTime * direction;
        Vector3 vector = new Vector3(speed, 0, 0);
        transform.Translate(vector);

        if (GameManager.instance.IsMonster == false)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Wall") //벽에 부딪히면 없어짐
        {
            GameManager.instance.IsMonster = false;
        }

    }
}
