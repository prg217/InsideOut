using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HP : MonoBehaviour
{
    Image HPBar;
    public static float MaxHP = 20f;
    public static float hp; //실시간 반영되는 플레이어의 체력

    // Start is called before the first frame update
    void Start()
    {
        HPBar = GetComponent<Image>();
        hp = MaxHP;
    }

    // Update is called once per frame
    void Update()
    {
        HPBar.fillAmount = hp / MaxHP;
        
    }
}
