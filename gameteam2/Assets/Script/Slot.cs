using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler //마우스의 포인터가 충돌범위안에 들어 올때 들어오는 이벤트와 마우스의 포인터가 충돌범위밖으로 나갈 때 들어오는 이벤트
{
    [SerializeField]
    private GameObject go_Base;

    public static GameObject[] clue = null;
    public int arraySize = 15;

    void Start()
    {
        clue = new GameObject[arraySize];
    }

    // 마우스 커서가 슬롯에 들어갈 때 발동
    public void OnPointerEnter(PointerEventData eventData)
    {
        go_Base.SetActive(true);
    }

    // 마우스 커서가 슬롯에서 나올 때 발동
    public void OnPointerExit(PointerEventData eventData)
    {
        go_Base.SetActive(false);
    }
}
