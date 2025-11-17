using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Title_Menu : MonoBehaviour
{
    public static bool start1 = false;
    public string tiltleBtn;

    //public GameObject obj1;

    void Start()
    {
        GameManager.IsMonster = true;
        
    }
    
    public static void startGame()
    {
        //æ¿¿Ã∏ß

        start1 = true;
    
        SceneManager.LoadScene("Main");
        
    }  
    
   

}

