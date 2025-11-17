using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//https://www.youtube.com/watch?v=KIqG7YggSE8 참고
//이건 단서 전용으로 하고 낯선 남자와의 대화같은건 이거 복붙해서 따로 만들자

[System.Serializable]
public class Dialogue
{
    [TextArea]
    public string dialogue;
}
public enum ClueId
{
    Man = 1,

    BrokenTrophy = 100,
    ColdFood = 101,
    DreamCatcher = 102,
    GrandmaPicture = 103,
    MainbedroomKey = 104,
    Medicalpaper = 105,
    MusicSheetMusicStand = 106,
    Note = 107,
    PhotoPiece = 108,
    Poster = 109,
    PracticeroomKey = 110,
    Sleepingpills = 111,
    StorageroomKey = 112,
    StudentroomKey = 113,
    TrophyMedal = 114,
    ViolinCase = 115,
}

public enum Selection
{
    Reasoning = 300,

    GrandmaPicture_Photo = 211,
    TrophyMedal_Poster = 223,
    BrokenTrophy_ViolinCase = 215,
    ColdFood_Note = 208,
    Medicalpaper_Sleepingpills = 216,

    //합친걸로 만들어놓기
}

public class TalkManager : MonoBehaviour
{
    [SerializeField]
    private GameObject sprite_DialogueBox = null;
    [SerializeField]
    private Text txt_Dialogue;

    private bool isDialogue = false;
    [SerializeField]
    private int count = 0;

    [SerializeField]
    private List<string> dialogue = new List<string>();

    [SerializeField]
    private GameObject monster = null;

    [SerializeField]
    private GameObject reasoning = null;

    private bool isChury = false;

    private int cut = 0;

    [SerializeField]
    private GameObject[] clue = null;

    private int endCount = 0;

    [SerializeField]
    private GameObject[] end = null;

    public bool endCheck = false;

    private bool isTalk = false;

    private AudioSource audioSource;

    public static bool talk = false;


    // Dictionary<string, > dictionary = new Dictionary<string, >();  나중에 열라리 써야지...

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void ShowDialogue()
    {
        OnOff(true);
        count = 0;
        NextDialogue();
        //몬스터 스폰 끄고 플레이어 이동도 끄기 이걸 위해 플레이어에 있던 몬스터 몬스터 스폰으로 옮겼음
        //움직일때 대화창 뜨면 움직이는 그대로 대화창 뜨는 것을 확인 시간 없으니 패스
        Player.isWalk = false;
        //몬스터 스폰 펄스 삭제함

        if (HP.hp <= 0) //hp 0이면?
        {
            OnOff(false);
            reasoning.gameObject.SetActive(false);
        }

    }

    public void Log(ClueId check)
    {
        switch (check)
        {
            case ClueId.Man:
                talk = true;
                dialogue.Add("...");
                dialogue.Add("의문의 사내 : 악몽에서 벗어나고 싶다 했지?");
                dialogue.Add("그러면 나를 도와줬음 좋겠는데.");
                dialogue.Add("방법은 간단해. 내가 지금 바쁜 몸이라… 나 대신 이 꿈의 문제를 해결해줘.");
                dialogue.Add("아, 어려운 건 절대 아니고~ 그냥 이 꿈에서 무슨 일이 일어나는지 알아내면 되는 거야.");
                dialogue.Add("가서 단서들을 다 모으게 되면, 꿈에서 무슨 일이 일어났는지 추리를 할 수 있는 빛나는 구가 알아서 나타나.");
                dialogue.Add("그러면 너는 구의 힘을 빌려서 모은 단서를 가지고 추리를 하면 돼.");
                dialogue.Add("하지만 아시다시피 여기에도 악몽의 흔적들이 돌아다니긴 하는데, 그럴 때는 그냥 숨으면 금방 지나가~ 별거 아니야!");
                dialogue.Add("그래도 웬만하면 악몽의 흔적을 피하도록 해. 여러 번 마주치다 자칫하면 악몽에서 영원히 못 벗어날 수 있거든~.");
                dialogue.Add("Esc키를 누르면 메뉴창을 열 수 있어");
                dialogue.Add("z키를 누르면 인벤토리 창을 열 수 있어");
                dialogue.Add("노란색으로 빛나는 곳에서 단서를 찾을 수 있어");
                dialogue.Add("파란색으로 빛나는 곳에서는 숨을 수 있어");
                dialogue.Add("그럼 행운을 빌게~!");
                talk = false;
                break;
            case ClueId.BrokenTrophy:
                talk = true;
                dialogue.Add("트로피가 완전히 망가졌어….");
                talk = false;
                break;
            case ClueId.ColdFood:
                talk = true;
                dialogue.Add("먹은 흔적이 없는 멀쩡한 음식인데 왜 버렸지?");
                talk = false;
                break;
            case ClueId.DreamCatcher:
                talk = true;
                dialogue.Add("왠지 모르게 익숙한 느낌이 들어.");
                talk = false;
                break;
            case ClueId.GrandmaPicture:
                talk = true;
                dialogue.Add("어딘가 익숙한 느낌이 드는데….");
                talk = false;
                break;
            case ClueId.MainbedroomKey:
                talk = true;
                dialogue.Add(" ");
                dialogue.Add("안방 열쇠를 찾았다!");
                talk = false;
                break;
            case ClueId.Medicalpaper:
                talk = true;
                dialogue.Add("'절대 안정을 취해야 한다….' 이게 뭐야, 병원 진료 내역?");
                talk = false;
                break;
            case ClueId.MusicSheetMusicStand:
                talk = true;
                dialogue.Add("이거는 바이올린 악보인데… 이 집에 바이올린 연주자가 사는 건가?");
                talk = false;
                break;
            case ClueId.Note:
                talk = true;
                dialogue.Add("'오늘은 내가 간호하러 병원에 갈게. 어머님 상태는 많이 양호해졌어. 얘는 아직도 밥을 안 먹어?' 라고 쪽지에 적혀 있네… 누가 아팠나?");
                talk = false;
                break;
            case ClueId.PhotoPiece:
                talk = true;
                if (GameManager.photo >= 2)
                {
                    dialogue.Add("사진 조각을 완성했어!");
                }
                else
                {
                    dialogue.Add("이 사진 조각은… 다른 사진 조각을 찾으면 완성할 수 있을 것 같아.");
                }
                talk = false;
                break;
            case ClueId.Poster: //오류 확인 바람
                talk = true;
                dialogue.Add(" ");
                dialogue.Add("무슨 콩쿠르 관련 포스터가 이렇게 많지?");
                talk = false;
                break;
            case ClueId.PracticeroomKey:
                talk = true;
                dialogue.Add("연습실 열쇠를 찾았다!");
                talk = false;
                break;
            case ClueId.Sleepingpills:
                talk = true;
                dialogue.Add("수면제라고 적힌 약통이 있어.");
                talk = false;
                break;
            case ClueId.StorageroomKey:
                talk = true;
                dialogue.Add("창고 열쇠를 찾았다!");
                talk = false;
                break;
            case ClueId.StudentroomKey:
                talk = true;
                dialogue.Add("학생방 열쇠를 찾았다!");
                talk = false;
                break;
            case ClueId.TrophyMedal:
                talk = true;
                dialogue.Add("트로피와 메달이 엄청 많아!");
                talk = false;
                break;
            case ClueId.ViolinCase:
                talk = true;
                dialogue.Add("케이스 위에 먼지가 뿌옇게 쌓여 있어…. 오랫동안 연주를 안 했나 봐.");
                talk = false;
                break;
        }
    }

    public void SLog(Selection check)
    {
        switch (check)
        {
            case Selection.Reasoning:
                talk = true;
                isChury = true;
                Destroy(monster); //변경점 : 몬스터 삭제
                dialogue.Add("이 꿈… 보면 볼수록 너무 익숙하다 싶었는데… 그 사진들은….");
                cut++;
                reasoning.SetActive(true);
                break;
            case Selection.GrandmaPicture_Photo:
                dialogue.Clear();
                if (cut == 1)
                {
                    Destroy(clue[0]);
                    Destroy(clue[1]);
                    isTalk = true;
                    reasoning.SetActive(false);
                    //여기서 해당 단서 없애주기
                    dialogue.Add("액자 속 사진은 할머니의 젊은 시절 모습이고, 찢어진 이 사진은 어릴 적 바쁜 부모님때문에 할머니댁에서 잠시 지냈을 때 찍었던 사진이야.");
                    dialogue.Add("할머니는 유명 바이올린리스트였고, 그런 할머니와 연주했을 때가 정말 즐거웠어. 그래서 나도 할머니처럼 되고 싶었지.");
                    dialogue.Add("그래서 다시 집으로 돌아왔을 때 본격적으로 바이올린을 연주하기 시작했을 거야. 집에 있던 많은…");

                    cut++;
                }
                else
                {
                    dialogue.Add("그건 아닌 것 같아, 다시 생각해보자.");
                    HP.hp -= 2;
                    switch (cut)
                    {
                        case 1:
                            dialogue.Add("이 꿈… 보면 볼수록 너무 익숙하다 싶었는데… 그 사진들은….");
                            break;
                        case 2:
                            dialogue.Add("액자 속 사진은 할머니의 젊은 시절 모습이고, 찢어진 이 사진은 어릴 적 바쁜 부모님때문에 할머니댁에서 잠시 지냈을 때 찍었던 사진이야.");
                            dialogue.Add("할머니는 유명 바이올린리스트였고, 그런 할머니와 연주했을 때가 정말 즐거웠어. 그래서 나도 할머니처럼 되고 싶었지.");
                            dialogue.Add("그래서 다시 집으로 돌아왔을 때 본격적으로 바이올린을 연주하기 시작했을 거야. 집에 있던 많은…");
                            break;
                        case 3:
                            dialogue.Add("콩쿠르 관련 포스터들과 메달과 트로피… 나는 열심히 했어. 다들 내가 할머니를 닮아 재능이 있다고도 했고 나도 그렇게 믿으면서 열심히 했으니까.");
                            dialogue.Add("지치고 힘들어하긴 했지만 할머니처럼 되고 싶은 마음에 힘들더라도 열심히 했어. 하지만 그 날 이후로 바이올린을…");
                            break;
                        case 4:
                            dialogue.Add("바이올린을 제대로 볼 수 없었어. 트로피만 봐도 그 날이 생각나고 바이올린 연주를 하려 하면 자꾸 할머니가 생각나서….");
                            dialogue.Add("그래서 부모님이 내 눈에 안보이게 일단 치워 주셨지….");
                            dialogue.Add("하… 당시 그 날은… 내 콩쿠르 경연이 있는 날이었어. 최근 들어 내가 힘들어 하는데 중요한 콩쿠르가 있다고 하니까 할머니께서 나를 응원하러 오신다고 하셨지. 하지만 그 날…");
                            break;
                        case 5:
                            dialogue.Add("할머니가… 나를 보러 오시는 길에… 교통사고가 나서…나는 그 사실을 내가 대상을 받고 뒤늦게 바보같이 할머니를 찾을 때 알게 되었어.");
                            dialogue.Add("너무 놀란 나머지 나는 그 자리에서 쓰러졌고… 얼마 뒤 깨어났지만 나 때문에 할머니가 그렇게 된 것 같다는 죄책감에 잠도 제대로 못 자고 밥도 계속 굶었지.");
                            dialogue.Add("내 상태가 걱정된 부모님은 나를 억지로 병원에 데려가셨지… 그리고 나는");
                            break;
                        case 6:
                            dialogue.Add("할머니가… 나를 보러 오시는 길에… 교통사고가 나서…나는 그 사실을 내가 대상을 받고 뒤늦게 바보같이 할머니를 찾을 때 알게 되었어.");
                            dialogue.Add("너무 놀란 나머지 나는 그 자리에서 쓰러졌고… 얼마 뒤 깨어났지만 나 때문에 할머니가 그렇게 된 것 같다는 죄책감에 잠도 제대로 못 자고 밥도 계속 굶었지.");
                            dialogue.Add("내 상태가 걱정된 부모님은 나를 억지로 병원에 데려가셨지… 그리고 나는");
                            break;
                        default:
                            break;
                    }
                }
                break;
            case Selection.TrophyMedal_Poster:
                dialogue.Clear();
                if (cut == 2)
                {
                    Destroy(clue[2]);
                    Destroy(clue[3]);
                    reasoning.SetActive(false);
                    dialogue.Add("콩쿠르 관련 포스터들과 메달과 트로피… 나는 열심히 했어. 다들 내가 할머니를 닮아 재능이 있다고도 했고 나도 그렇게 믿으면서 열심히 했으니까.");
                    dialogue.Add("지치고 힘들어하긴 했지만 할머니처럼 되고 싶은 마음에 힘들더라도 열심히 했어. 하지만 그 날 이후로 바이올린을…");

                    cut++;
                }
                else
                {
                    dialogue.Add("그건 아닌 것 같아, 다시 생각해보자.");
                    HP.hp -= 2;
                    switch (cut)
                    {
                        case 1:
                            dialogue.Add("이 꿈… 보면 볼수록 너무 익숙하다 싶었는데… 그 사진들은….");
                            break;
                        case 2:
                            dialogue.Add("액자 속 사진은 할머니의 젊은 시절 모습이고, 찢어진 이 사진은 어릴 적 바쁜 부모님때문에 할머니댁에서 잠시 지냈을 때 찍었던 사진이야.");
                            dialogue.Add("할머니는 유명 바이올린리스트였고, 그런 할머니와 연주했을 때가 정말 즐거웠어. 그래서 나도 할머니처럼 되고 싶었지.");
                            dialogue.Add("그래서 다시 집으로 돌아왔을 때 본격적으로 바이올린을 연주하기 시작했을 거야. 집에 있던 많은…");
                            break;
                        case 3:
                            dialogue.Add("콩쿠르 관련 포스터들과 메달과 트로피… 나는 열심히 했어. 다들 내가 할머니를 닮아 재능이 있다고도 했고 나도 그렇게 믿으면서 열심히 했으니까.");
                            dialogue.Add("지치고 힘들어하긴 했지만 할머니처럼 되고 싶은 마음에 힘들더라도 열심히 했어. 하지만 그 날 이후로 바이올린을…");
                            break;
                        case 4:
                            dialogue.Add("바이올린을 제대로 볼 수 없었어. 트로피만 봐도 그 날이 생각나고 바이올린 연주를 하려 하면 자꾸 할머니가 생각나서….");
                            dialogue.Add("그래서 부모님이 내 눈에 안보이게 일단 치워 주셨지….");
                            dialogue.Add("하… 당시 그 날은… 내 콩쿠르 경연이 있는 날이었어. 최근 들어 내가 힘들어 하는데 중요한 콩쿠르가 있다고 하니까 할머니께서 나를 응원하러 오신다고 하셨지. 하지만 그 날…");
                            break;
                        case 5:
                            dialogue.Add("할머니가… 나를 보러 오시는 길에… 교통사고가 나서…나는 그 사실을 내가 대상을 받고 뒤늦게 바보같이 할머니를 찾을 때 알게 되었어.");
                            dialogue.Add("너무 놀란 나머지 나는 그 자리에서 쓰러졌고… 얼마 뒤 깨어났지만 나 때문에 할머니가 그렇게 된 것 같다는 죄책감에 잠도 제대로 못 자고 밥도 계속 굶었지.");
                            dialogue.Add("내 상태가 걱정된 부모님은 나를 억지로 병원에 데려가셨지… 그리고 나는");
                            break;
                        case 6:
                            dialogue.Add("할머니가… 나를 보러 오시는 길에… 교통사고가 나서…나는 그 사실을 내가 대상을 받고 뒤늦게 바보같이 할머니를 찾을 때 알게 되었어.");
                            dialogue.Add("너무 놀란 나머지 나는 그 자리에서 쓰러졌고… 얼마 뒤 깨어났지만 나 때문에 할머니가 그렇게 된 것 같다는 죄책감에 잠도 제대로 못 자고 밥도 계속 굶었지.");
                            dialogue.Add("내 상태가 걱정된 부모님은 나를 억지로 병원에 데려가셨지… 그리고 나는");
                            break;
                        default:
                            break;
                    }
                }
                break;
            case Selection.BrokenTrophy_ViolinCase:
                dialogue.Clear();
                if (cut == 3)
                {
                    Destroy(clue[4]);
                    Destroy(clue[5]);
                    reasoning.SetActive(false);
                    dialogue.Add("바이올린을 제대로 볼 수 없었어. 트로피만 봐도 그 날이 생각나고 바이올린 연주를 하려 하면 자꾸 할머니가 생각나서….");
                    dialogue.Add("그래서 부모님이 내 눈에 안보이게 일단 치워 주셨지….");
                    dialogue.Add("하… 당시 그 날은… 내 콩쿠르 경연이 있는 날이었어. 최근 들어 내가 힘들어 하는데 중요한 콩쿠르가 있다고 하니까 할머니께서 나를 응원하러 오신다고 하셨지. 하지만 그 날…");

                    cut++;
                }
                else
                {
                    dialogue.Add("그건 아닌 것 같아, 다시 생각해보자.");
                    HP.hp -= 2;
                    switch (cut)
                    {
                        case 1:
                            dialogue.Add("이 꿈… 보면 볼수록 너무 익숙하다 싶었는데… 그 사진들은….");
                            break;
                        case 2:
                            dialogue.Add("액자 속 사진은 할머니의 젊은 시절 모습이고, 찢어진 이 사진은 어릴 적 바쁜 부모님때문에 할머니댁에서 잠시 지냈을 때 찍었던 사진이야.");
                            dialogue.Add("할머니는 유명 바이올린리스트였고, 그런 할머니와 연주했을 때가 정말 즐거웠어. 그래서 나도 할머니처럼 되고 싶었지.");
                            dialogue.Add("그래서 다시 집으로 돌아왔을 때 본격적으로 바이올린을 연주하기 시작했을 거야. 집에 있던 많은…");
                            break;
                        case 3:
                            dialogue.Add("콩쿠르 관련 포스터들과 메달과 트로피… 나는 열심히 했어. 다들 내가 할머니를 닮아 재능이 있다고도 했고 나도 그렇게 믿으면서 열심히 했으니까.");
                            dialogue.Add("지치고 힘들어하긴 했지만 할머니처럼 되고 싶은 마음에 힘들더라도 열심히 했어. 하지만 그 날 이후로 바이올린을…");
                            break;
                        case 4:
                            dialogue.Add("바이올린을 제대로 볼 수 없었어. 트로피만 봐도 그 날이 생각나고 바이올린 연주를 하려 하면 자꾸 할머니가 생각나서….");
                            dialogue.Add("그래서 부모님이 내 눈에 안보이게 일단 치워 주셨지….");
                            dialogue.Add("하… 당시 그 날은… 내 콩쿠르 경연이 있는 날이었어. 최근 들어 내가 힘들어 하는데 중요한 콩쿠르가 있다고 하니까 할머니께서 나를 응원하러 오신다고 하셨지. 하지만 그 날…");
                            break;
                        case 5:
                            dialogue.Add("할머니가… 나를 보러 오시는 길에… 교통사고가 나서…나는 그 사실을 내가 대상을 받고 뒤늦게 바보같이 할머니를 찾을 때 알게 되었어.");
                            dialogue.Add("너무 놀란 나머지 나는 그 자리에서 쓰러졌고… 얼마 뒤 깨어났지만 나 때문에 할머니가 그렇게 된 것 같다는 죄책감에 잠도 제대로 못 자고 밥도 계속 굶었지.");
                            dialogue.Add("내 상태가 걱정된 부모님은 나를 억지로 병원에 데려가셨지… 그리고 나는");
                            break;
                        case 6:
                            dialogue.Add("할머니가… 나를 보러 오시는 길에… 교통사고가 나서…나는 그 사실을 내가 대상을 받고 뒤늦게 바보같이 할머니를 찾을 때 알게 되었어.");
                            dialogue.Add("너무 놀란 나머지 나는 그 자리에서 쓰러졌고… 얼마 뒤 깨어났지만 나 때문에 할머니가 그렇게 된 것 같다는 죄책감에 잠도 제대로 못 자고 밥도 계속 굶었지.");
                            dialogue.Add("내 상태가 걱정된 부모님은 나를 억지로 병원에 데려가셨지… 그리고 나는");
                            break;
                        default:
                            break;
                    }
                }
                break;
            case Selection.ColdFood_Note:
                dialogue.Clear();
                if (cut == 4)
                {
                    Destroy(clue[6]);
                    Destroy(clue[7]);
                    reasoning.SetActive(false);
                    dialogue.Add("할머니가… 나를 보러 오시는 길에… 교통사고가 나서…나는 그 사실을 내가 대상을 받고 뒤늦게 바보같이 할머니를 찾을 때 알게 되었어.");
                    dialogue.Add("너무 놀란 나머지 나는 그 자리에서 쓰러졌고… 얼마 뒤 깨어났지만 나 때문에 할머니가 그렇게 된 것 같다는 죄책감에 잠도 제대로 못 자고 밥도 계속 굶었지.");
                    dialogue.Add("내 상태가 걱정된 부모님은 나를 억지로 병원에 데려가셨지… 그리고 나는");

                    cut++;
                }
                else
                {
                    dialogue.Add("그건 아닌 것 같아, 다시 생각해보자.");
                    HP.hp -= 2;
                    switch (cut)
                    {
                        case 1:
                            dialogue.Add("이 꿈… 보면 볼수록 너무 익숙하다 싶었는데… 그 사진들은….");
                            break;
                        case 2:
                            dialogue.Add("액자 속 사진은 할머니의 젊은 시절 모습이고, 찢어진 이 사진은 어릴 적 바쁜 부모님때문에 할머니댁에서 잠시 지냈을 때 찍었던 사진이야.");
                            dialogue.Add("할머니는 유명 바이올린리스트였고, 그런 할머니와 연주했을 때가 정말 즐거웠어. 그래서 나도 할머니처럼 되고 싶었지.");
                            dialogue.Add("그래서 다시 집으로 돌아왔을 때 본격적으로 바이올린을 연주하기 시작했을 거야. 집에 있던 많은…");
                            break;
                        case 3:
                            dialogue.Add("콩쿠르 관련 포스터들과 메달과 트로피… 나는 열심히 했어. 다들 내가 할머니를 닮아 재능이 있다고도 했고 나도 그렇게 믿으면서 열심히 했으니까.");
                            dialogue.Add("지치고 힘들어하긴 했지만 할머니처럼 되고 싶은 마음에 힘들더라도 열심히 했어. 하지만 그 날 이후로 바이올린을…");
                            break;
                        case 4:
                            dialogue.Add("바이올린을 제대로 볼 수 없었어. 트로피만 봐도 그 날이 생각나고 바이올린 연주를 하려 하면 자꾸 할머니가 생각나서….");
                            dialogue.Add("그래서 부모님이 내 눈에 안보이게 일단 치워 주셨지….");
                            dialogue.Add("하… 당시 그 날은… 내 콩쿠르 경연이 있는 날이었어. 최근 들어 내가 힘들어 하는데 중요한 콩쿠르가 있다고 하니까 할머니께서 나를 응원하러 오신다고 하셨지. 하지만 그 날…");
                            break;
                        case 5:
                            dialogue.Add("할머니가… 나를 보러 오시는 길에… 교통사고가 나서…나는 그 사실을 내가 대상을 받고 뒤늦게 바보같이 할머니를 찾을 때 알게 되었어.");
                            dialogue.Add("너무 놀란 나머지 나는 그 자리에서 쓰러졌고… 얼마 뒤 깨어났지만 나 때문에 할머니가 그렇게 된 것 같다는 죄책감에 잠도 제대로 못 자고 밥도 계속 굶었지.");
                            dialogue.Add("내 상태가 걱정된 부모님은 나를 억지로 병원에 데려가셨지… 그리고 나는");
                            break;
                        case 6:
                            dialogue.Add("할머니가… 나를 보러 오시는 길에… 교통사고가 나서…나는 그 사실을 내가 대상을 받고 뒤늦게 바보같이 할머니를 찾을 때 알게 되었어.");
                            dialogue.Add("너무 놀란 나머지 나는 그 자리에서 쓰러졌고… 얼마 뒤 깨어났지만 나 때문에 할머니가 그렇게 된 것 같다는 죄책감에 잠도 제대로 못 자고 밥도 계속 굶었지.");
                            dialogue.Add("내 상태가 걱정된 부모님은 나를 억지로 병원에 데려가셨지… 그리고 나는");
                            break;
                        default:
                            break;
                    }
                }
                break;
            case Selection.Medicalpaper_Sleepingpills:
                dialogue.Clear();
                if (cut == 5)
                {
                    Destroy(clue[8]);
                    Destroy(clue[9]);
                    reasoning.SetActive(false);

                    dialogue.Add("여러 처방을 받고 잠을 못 잔다고 해서 수면제까지 처방을 받았고.");
                    dialogue.Add("솔직히 약을 먹어도 상태는 크게 진전이 없었어. 나 스스로가 계속 숨어 있었으니까. 결국… 방에서 안 나오고 약만 먹고 잠만 겨우 드는 상태까지 왔었어.");
                    dialogue.Add("그러다가… 우연히 자각몽이라는 것을 알게 되었어. 자신의 마음대로 꿈을 꿀 수 있다는 말에 여러 번 시도 끝에 성공했지.");
                    dialogue.Add("자각몽을 통해 나는 꿈 속을 도피를 하였어. 꿈 속에서 마음대로 할 수 있고…현실을 안 볼 수 있다는 점이 너무 좋았으니까.");
                    dialogue.Add("하지만… 자각몽을 실패한 그 날부터… 악몽이 계속 꿈 속에 나타나 나를 쭉 괴롭혔어… 그리고 그 이후론 정장을 입은 그 사람이… 나를 도와줬고.");

                    isChury = true;
                    endCheck = true;
                    cut++;

                    //OnOff(false);
                    //test
                 

                }
                else
                {
                    dialogue.Add("그건 아닌 것 같아, 다시 생각해보자.");
                    HP.hp -= 2;
                    switch (cut)
                    {
                        case 1:
                            dialogue.Add("이 꿈… 보면 볼수록 너무 익숙하다 싶었는데… 그 사진들은….");
                            break;
                        case 2:
                            dialogue.Add("액자 속 사진은 할머니의 젊은 시절 모습이고, 찢어진 이 사진은 어릴 적 바쁜 부모님때문에 할머니댁에서 잠시 지냈을 때 찍었던 사진이야.");
                            dialogue.Add("할머니는 유명 바이올린리스트였고, 그런 할머니와 연주했을 때가 정말 즐거웠어. 그래서 나도 할머니처럼 되고 싶었지.");
                            dialogue.Add("그래서 다시 집으로 돌아왔을 때 본격적으로 바이올린을 연주하기 시작했을 거야. 집에 있던 많은…");
                            break;
                        case 3:
                            dialogue.Add("콩쿠르 관련 포스터들과 메달과 트로피… 나는 열심히 했어. 다들 내가 할머니를 닮아 재능이 있다고도 했고 나도 그렇게 믿으면서 열심히 했으니까.");
                            dialogue.Add("지치고 힘들어하긴 했지만 할머니처럼 되고 싶은 마음에 힘들더라도 열심히 했어. 하지만 그 날 이후로 바이올린을…");
                            break;
                        case 4:
                            dialogue.Add("바이올린을 제대로 볼 수 없었어. 트로피만 봐도 그 날이 생각나고 바이올린 연주를 하려 하면 자꾸 할머니가 생각나서….");
                            dialogue.Add("그래서 부모님이 내 눈에 안보이게 일단 치워 주셨지….");
                            dialogue.Add("하… 당시 그 날은… 내 콩쿠르 경연이 있는 날이었어. 최근 들어 내가 힘들어 하는데 중요한 콩쿠르가 있다고 하니까 할머니께서 나를 응원하러 오신다고 하셨지. 하지만 그 날…");
                            break;
                        case 5:
                            dialogue.Add("할머니가… 나를 보러 오시는 길에… 교통사고가 나서…나는 그 사실을 내가 대상을 받고 뒤늦게 바보같이 할머니를 찾을 때 알게 되었어.");
                            dialogue.Add("너무 놀란 나머지 나는 그 자리에서 쓰러졌고… 얼마 뒤 깨어났지만 나 때문에 할머니가 그렇게 된 것 같다는 죄책감에 잠도 제대로 못 자고 밥도 계속 굶었지.");
                            dialogue.Add("내 상태가 걱정된 부모님은 나를 억지로 병원에 데려가셨지… 그리고 나는");
                            break;
                        case 6:
                            dialogue.Add("할머니가… 나를 보러 오시는 길에… 교통사고가 나서…나는 그 사실을 내가 대상을 받고 뒤늦게 바보같이 할머니를 찾을 때 알게 되었어.");
                            dialogue.Add("너무 놀란 나머지 나는 그 자리에서 쓰러졌고… 얼마 뒤 깨어났지만 나 때문에 할머니가 그렇게 된 것 같다는 죄책감에 잠도 제대로 못 자고 밥도 계속 굶었지.");
                            dialogue.Add("내 상태가 걱정된 부모님은 나를 억지로 병원에 데려가셨지… 그리고 나는");
                            break;
                        default:
                            break;
                    }
                }
                break;
            default:
                dialogue.Clear();
                dialogue.Add("그건 아닌 것 같아, 다시 생각해보자.");
                HP.hp -= 2;

                switch (cut)
                {
                    case 1:
                        dialogue.Add("이 꿈… 보면 볼수록 너무 익숙하다 싶었는데… 그 사진들은….");
                        break;
                    case 2:
                        dialogue.Add("액자 속 사진은 할머니의 젊은 시절 모습이고, 찢어진 이 사진은 어릴 적 바쁜 부모님때문에 할머니댁에서 잠시 지냈을 때 찍었던 사진이야.");
                        dialogue.Add("할머니는 유명 바이올린리스트였고, 그런 할머니와 연주했을 때가 정말 즐거웠어. 그래서 나도 할머니처럼 되고 싶었지.");
                        dialogue.Add("그래서 다시 집으로 돌아왔을 때 본격적으로 바이올린을 연주하기 시작했을 거야. 집에 있던 많은…");
                        break;
                    case 3:
                        dialogue.Add("콩쿠르 관련 포스터들과 메달과 트로피… 나는 열심히 했어. 다들 내가 할머니를 닮아 재능이 있다고도 했고 나도 그렇게 믿으면서 열심히 했으니까.");
                        dialogue.Add("지치고 힘들어하긴 했지만 할머니처럼 되고 싶은 마음에 힘들더라도 열심히 했어. 하지만 그 날 이후로 바이올린을…");
                        break;
                    case 4:
                        dialogue.Add("바이올린을 제대로 볼 수 없었어. 트로피만 봐도 그 날이 생각나고 바이올린 연주를 하려 하면 자꾸 할머니가 생각나서….");
                        dialogue.Add("그래서 부모님이 내 눈에 안보이게 일단 치워 주셨지….");
                        dialogue.Add("하… 당시 그 날은… 내 콩쿠르 경연이 있는 날이었어. 최근 들어 내가 힘들어 하는데 중요한 콩쿠르가 있다고 하니까 할머니께서 나를 응원하러 오신다고 하셨지. 하지만 그 날…");
                        break;
                    case 5:
                        dialogue.Add("할머니가… 나를 보러 오시는 길에… 교통사고가 나서…나는 그 사실을 내가 대상을 받고 뒤늦게 바보같이 할머니를 찾을 때 알게 되었어.");
                        dialogue.Add("너무 놀란 나머지 나는 그 자리에서 쓰러졌고… 얼마 뒤 깨어났지만 나 때문에 할머니가 그렇게 된 것 같다는 죄책감에 잠도 제대로 못 자고 밥도 계속 굶었지.");
                        dialogue.Add("내 상태가 걱정된 부모님은 나를 억지로 병원에 데려가셨지… 그리고 나는");
                        break;
                    case 6:
                        dialogue.Add("할머니가… 나를 보러 오시는 길에… 교통사고가 나서…나는 그 사실을 내가 대상을 받고 뒤늦게 바보같이 할머니를 찾을 때 알게 되었어.");
                        dialogue.Add("너무 놀란 나머지 나는 그 자리에서 쓰러졌고… 얼마 뒤 깨어났지만 나 때문에 할머니가 그렇게 된 것 같다는 죄책감에 잠도 제대로 못 자고 밥도 계속 굶었지.");
                        dialogue.Add("내 상태가 걱정된 부모님은 나를 억지로 병원에 데려가셨지… 그리고 나는");
                        break;
                    default:
                        break;
                }
                break;
        }


    }

    private void OnOff(bool _flag)
    {
        sprite_DialogueBox.gameObject.SetActive(_flag);
        txt_Dialogue.gameObject.SetActive(_flag);

        isDialogue = _flag;
    }

    private void NextDialogue()
    {
        txt_Dialogue.text = dialogue[count];
        count++; //대화창 개수?
    }

    private void Update()
    {
        if (isDialogue == true)
        {
           

            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (count < dialogue.Count)
                {
                    NextDialogue();
                }
                else //대화 끝나면
                {
                    if (isChury == false)
                    {
                        OnOff(false);
                        //다시 키기
                        Player.isWalk = true;
                        dialogue.Clear();
                    }
                    if (endCheck == true)
                    {
                        dialogue.Add("엔딩");
                        InvokeRepeating("Ending", 0, 5);
                    }
                    else if (isTalk)
                    {
                        reasoning.SetActive(true);
                    }
                }
            }
        }
    }

    private void Ending()
    {
            AudioClip audioClip = Resources.Load<AudioClip>("Autumn Allure _ unminus.com") as AudioClip;
            GetComponent<AudioSource>().clip = audioClip;
            audioSource.Play();

        if (endCount == 0)
        {
            end[0].SetActive(true);
            endCount++;
        }
        else if (endCount == 1)
        {
            end[0].SetActive(false);
            end[1].SetActive(true);
            endCount++;
        }
        else if (endCount == 2)
        {
            end[1].SetActive(false);
            end[2].SetActive(true);
            endCount++;
        }
        else if (endCount == 3)
        {
            end[2].SetActive(false);
            end[3].SetActive(true);
            endCount++;
        }
        else if (endCount == 4)
        {
            end[3].SetActive(false);
            end[4].SetActive(true);
            endCount++;
        }
        else if (endCount == 5)
        {
            end[4].SetActive(false);
            end[5].SetActive(true);
            endCount++;
        }
        else if (endCount == 6)
        {
            SceneManager.LoadScene("tiltleBtn");
        }
    }
}