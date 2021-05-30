using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HP : MonoBehaviour
{
    Image HPBar;
    float MaxHP = 20f;
    public static float hp;

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
