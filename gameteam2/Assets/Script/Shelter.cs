using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shelter : MonoBehaviour
{
    static public bool isHide;
    public bool changeH;
   

    [SerializeField]
    private GameObject s1;
    [SerializeField]
    private GameObject s2;
    [SerializeField]
    private GameObject s3;
  

    void Start()
    {
        isHide = false;
        changeH = false;
    }


    //쉘터 태그를 만났을 때 좌 컨트롤 누르고 있을때 동안 플레이어 레이어를 Hide로 바꿔주기
    private void OnTriggerStay2D(Collider2D collision) //접촉하고 있을 때
    {
        if (collision.CompareTag("Shelter"))
        {
            changeH = true;

            if (changeH == true)
            {
                //부엌일때
                if (collision.gameObject.layer == 15)
                {
                    
                    s1.gameObject.SetActive(true);
                }
                //창고일때
                if (collision.gameObject.layer == 16)
                {
                    s2.gameObject.SetActive(true);
                }
                //공부방일때
                if (collision.gameObject.layer == 17)
                {
                    s3.gameObject.SetActive(true);
                }

            }

            if (Input.GetKey(KeyCode.LeftControl)) //좌 컨트롤 누르고 있을 동안만
            {
                GameObject.Find("Player").layer = 6; //Hide
                // Player.move = false;

                isHide = true;


            }
            else //떼었을 때
            {
                GameObject.Find("Player").layer = 0; //디폴트(다시 몬스터 맞음)

                isHide = false;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)//쉘터 빠져나오면
    {
        if (collision.CompareTag("Shelter"))
        {
            changeH = false;

            if(changeH == false)
            {
                if (collision.gameObject.layer == 15)
                {

                    s1.gameObject.SetActive(false);
                }
                //창고일때
                if (collision.gameObject.layer == 16)
                {
                    s2.gameObject.SetActive(false);
                }
                //공부방일때
                if (collision.gameObject.layer == 17)
                {
                    s3.gameObject.SetActive(false);
                }

            }

        }
    }
}
