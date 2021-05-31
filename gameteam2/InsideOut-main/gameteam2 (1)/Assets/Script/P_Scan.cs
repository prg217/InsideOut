using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class P_Scan : MonoBehaviour
{
    [SerializeField]
    private GameObject ScanObj1 = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision) //접촉시작
    {
        //테두리 이미지로 바꾸고
        if (collision.CompareTag("Shelter")) //상호작용 가능한 오브젝트들 추가해주기
        {
            //참고 : https://marsland.tistory.com/461
            ScanObj1.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("love") as Sprite; //Resources에 저장된 이미지 불러와준거
        }
    }

    private void OnTriggerExit2D(Collider2D collision) //접촉끝
    {
        //여기서 다시 원래 이미지
        if (collision.CompareTag("Shelter"))
        {
            ScanObj1.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("toky") as Sprite;
        }
    }
}
