using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//이거 말고 아예 단서 따로따로 해서 플레이어가 주우면 단서 사라지고 인벤토리에 있던 아이템이 보이게 하는건? 인벤토리가 뜨는 것 보다 구에서 추리하게 할 수 있는거 먼저 구현해보기.
[CreateAssetMenu(fileName = "New Item", menuName = "New Item/item")]
public class Item : ScriptableObject  // 게임 오브젝트에 붙일 필요 X 
{
    public enum ItemType  // 아이템 유형
    {
        Living1,
        Living2,
        Kitchen1,
        Kitchen2,
        Kitchen3,
        Warehouse1,
        Warehouse2,
        student1,
        student2,
        student3,
    }

    public string itemName; // 아이템의 이름
    public ItemType itemType; // 아이템 유형
    public Sprite itemImage; // 아이템의 이미지(인벤 토리 안에서 띄울)
    public GameObject itemPrefab;  // 아이템의 프리팹 (아이템 생성시 프리팹으로 찍어냄)
}
