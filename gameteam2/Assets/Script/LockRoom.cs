using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockRoom : MonoBehaviour
{
    [SerializeField]
    private GameObject Pt_Lock;
    [SerializeField]
    private GameObject St_Lock;
    [SerializeField]
    private GameObject Md_Lock;
    [SerializeField]
    private GameObject Sg_Lock;


    //private AudioSource audioSource_door_L;
    //private AudioSource audioSource_door_C;



    // [SerializeField]
    //private GameObject[] lockList;

    //private GameObject Lock_obj = null;

    GameObject key1;
    GameObject key2;
    GameObject key3;
    GameObject key4;

    //private SpriteRenderer _spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        key1 = GameObject.Find("PT_K");
        key2 = GameObject.Find("ST_K");
        key3 = GameObject.Find("Md_K");
        key4 = GameObject.Find("SG_K");

        // audioSource_door_L = GetComponent<AudioSource>();//문잠긴거
        // audioSource_door_C = GetComponent<AudioSource>();//문열린거
    }

    // Update is called once per frame
    void Update()
    {
        //true된 오브젝트 찾아


        Lock_Check();

    }

    //배치하면 키 순서대로 ++시켜 그 숫자면 문이 열리도록하기
    //안방-창고-학생-방-연습실 순으로
    void Lock_Check()
    {
        if (Player.isLock == false) //플레이어와 닿았을 때
        {


            //일단 확인한다
            if (key1 == null && Player.Id == 1)
            {
                Pt_Lock.gameObject.SetActive(false);
                //Destroy(Pt_Lock.gameObject);

                Player.Id = 0;


            }

            if (key2 == null && Player.Id == 2)
            {
                St_Lock.gameObject.SetActive(false);
                //Destroy(St_Lock.gameObject);

                Player.Id = 0;


            }

            if (key3 == null && Player.Id == 3)//충돌한게 맞는 오브제인지
            {
                Md_Lock.gameObject.SetActive(false);
              //  Destroy(Md_Lock.gameObject);

                Player.Id = 0;

            }

            if (key4 == null && Player.Id == 4)
            {
                Sg_Lock.gameObject.SetActive(false);
               // Destroy(Sg_Lock.gameObject);

                Player.Id = 0;


            }
        }



    }

    /*
    IEnumerator Fade_Out()
    {
        yield return new WaitForSeconds(1);
        while (_spriteRenderer.color.a > 0)
        {
            var color = _spriteRenderer.color;
            //color.a is 0 to 1. So .5*time.deltaTime will take 2 seconds to fade out
            color.a -= (.5f * Time.deltaTime);

            _spriteRenderer.color = color;
            //wait for a frame
            yield return null;
        }

        Destroy(this.gameObject);
    }
     */
}
