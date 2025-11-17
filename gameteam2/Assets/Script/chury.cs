using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chury : MonoBehaviour
{
    [SerializeField]
    private ClueId save1 = 0;
    [SerializeField]
    private ClueId save2 = 0;
    [SerializeField]
    private int id = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Save(ClueId save)
    {
        if (save1 == 0)
        {
            save1 = save;
        }
        else if (save1 == save)
        {
            save1 = save;
        }
        else if (save2 == 0)
        {
            save2 = save;
        }
        else if (save2 == save)
        {
            save2 = save;
        }
        else
        {
            save1 = save2;
            save2 = save;
        }

        id = (int)save1 + (int)save2;
    }

    public void Down()
    {
        GameObject.Find("TalkManager").GetComponent<TalkManager>().SLog((Selection)id); //번호에 따라 로그 입력
        GameObject.Find("TalkManager").GetComponent<TalkManager>().ShowDialogue(); //쇼다이얼 함수 불러옴
    }
}
