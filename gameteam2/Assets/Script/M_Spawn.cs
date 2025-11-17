using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_Spawn : MonoBehaviour
{
    [SerializeField]
    private float random = 0;
    [SerializeField]
    private GameObject monsterObj = null;
    [SerializeField]
    private GameObject monsterPos = null;

    public Transform target; // 따라갈 타겟의 트랜스 폼

    private float relativeHeigth = 8.0f; // 높이 즉 y값
    private float xDistance = 35.0f; // x값
    public float dampSpeed = 2;  //따라가는 속도 짧으면 타겟과 같이 움직인다.

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("RandomMonster", 10, 3); //10초후 부터, _Random함수를 3초마다 반복해서 실행 시킵니다.
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = target.position + new Vector3(-xDistance, relativeHeigth, 0); // 타겟 포지선에 해당 위치를 더해.. 즉 타겟 주변에 위치할 위치를 담는다.. 일정의 거리를 구하는 방법
        transform.position = Vector3.Lerp(transform.position, newPos, Time.deltaTime * dampSpeed); //그 둘 사이의 값을 더해 보정한다. 이렇게 되면 멀어지면 따라간다.
    }

    private void RandomMonster()
    {
            if (GameManager.IsMonster == false) //몬스터
            {
                random = Random.Range(0, 1000);

                if (random > 900)
                {
                    GameManager.IsMonster = true;
                    GameObject monster = (GameObject)Instantiate(monsterObj, monsterPos.transform.position, Quaternion.identity);

                    Monster.M_isWalk = true;
                }
            }
    }
}
