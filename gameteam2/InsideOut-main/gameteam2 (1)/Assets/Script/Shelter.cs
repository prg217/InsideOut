using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shelter : MonoBehaviour
{
    private float hideSpeed = 3f;
    bool isHide;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        isHide = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        float hide = Input.GetAxis("Hide");
        float playerSpeed = hide * hideSpeed * Time.deltaTime;
        Vector3 vector3 = new Vector3();
        vector3.x = playerSpeed;
        transform.Translate(vector3);

        if (hide < 0)
        {
            transform.localScale = new Vector3(-0.23f, 0.23f, 0.23f);
            animator.SetBool("isHide", true);
        }
        else if (hide == 0)
        {
            GetComponent<Animator>().SetBool("isHide", false);
        }
        else
        {
            transform.localScale = new Vector3(0.23f, 0.23f, 0.23f);
            animator.SetBool("isHide", true);
        }

    }

    //쉘터 태그를 만났을 때 좌 컨트롤 누르고 있을때 동안 플레이어 레이어를 Hide로 바꿔주기
    private void OnTriggerStay2D(Collider2D collision) //접촉하고 있을 때
    {
        if (collision.CompareTag("Player"))
        {
            if (Input.GetKey(KeyCode.LeftControl)) //좌 컨트롤 누르고 있을 동안만
            {
                GameObject.Find("Player").layer = 6; //Hide
                Player.move = false;

                isHide = true;

                //누르면 애니메이션

            }
            else //떼었을 때
            {
                GameObject.Find("Player").layer = 0; //디폴트(다시 몬스터 맞음)
                Player.move = true;
            }
        }
    }
}
