using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    public static GameObject[] clue = null;
    public int arraySize = 15;

    void Start()
    {
        clue = new GameObject[arraySize];
    }
}
