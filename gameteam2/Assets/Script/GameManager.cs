using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    public static int clueCount = 0; //단서 몇 개 모았나 체크

    public GameObject dark1; //처음 방이기 때문에 어둠 사라지게
    public GameObject dark2; //처음 시작하는 방에서 다음 방을 못가게

    public GameObject menuSet; //게임메뉴 구현
    public GameObject endSet; //죽었을 때 메뉴 구현

    // public GameObject player;

    private AudioSource audioSource;
    private AudioSource audioSource1;

    private bool Act = false;

    public static bool IsMonster;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource1 = GetComponent<AudioSource>();

        if (Title_Menu.start1 == true) //게임 시작하면?
        {
            dark1.gameObject.SetActive(false); 
            dark2.gameObject.SetActive(false);

            IsMonster = false;

            AudioClip audioClip = Resources.Load<AudioClip>("481652__themoviemacher__shadow-maker-library") as AudioClip;
            GetComponent<AudioSource>().clip = audioClip;
            audioSource1.Play();
        }

        else if(Title_Menu.start1 == false)
        {
            
            audioSource1.Stop();
        }

    }

    public static int photo = 0; //찢어진 사진 2개 먹었나 체크

    void Update()
    {
        //버튼은 앵간하면 update에

        if (Input.GetButtonDown("Cancel"))  //esc키 누르면? 메뉴버튼 활성화
        {
            if (menuSet.activeSelf) //켜져있다
            {
                menuSet.SetActive(false); //끄기
            }

            else //꺼져있으면?
            {
                menuSet.SetActive(true); //켜기
            }

        }

        if (HP.hp <= 0) //hp 0이면?
        {
            endSet.SetActive(true);

            Player.isWalk = false;

            if (Act == false)
            {
                Act = true;
                AudioClip audioClip = Resources.Load<AudioClip>("273373__sturmankin__wood-17a-boots-walk") as AudioClip;
                GetComponent<AudioSource>().clip = audioClip;
                audioSource.Play();

                IsMonster = true;
            }          
        }

        else
        {
            endSet.SetActive(false);

            if (Act == true)
            {
                Act = false;
                audioSource.Stop();
            }
        }

    }

    public void GameSave()
    {
        //뭘 저장할까..
        //플레이어 위치
        //열어진 lock 아이디
        //먹은 단서들
        //

    }

    public void GameExit() //게임 종료하기~
    {
        Application.Quit();
    }

    public void Restart_Game()
    {
        SceneManager.LoadScene("tiltleBtn"); //재시작
        Title_Menu.start1 = false;
        Title_Menu.startGame();

    }

    public void Reset()
    {
        //hp
        //인벤토리 오브젝트 다 삭제
        //초기위치?
    }
}

