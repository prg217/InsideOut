using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clue : MonoBehaviour
{
    [SerializeField]
    private GameObject inven = null;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision) //접촉하고 있을 때
    {
        if (collision.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.Space)) //높이 있는 물체는 바닥까지 박스 콜라이더를 늘릴것!!
            {
                Destroy(gameObject); //대사창 추가할때는 다른 스크립트 만들어서 넣는게 편할듯...
                inven.gameObject.SetActive(true);
            }
        }
    }
}
