using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Title_Menu : MonoBehaviour
{
    public string tiltleBtn;

    public void startGame()
    {
        //æ¿¿Ã∏ß
        SceneManager.LoadScene("Main");
    }
}
