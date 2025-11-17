using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder_S : MonoBehaviour
{
    private AudioSource audioSource;

    private bool Act_L = false;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.move && Act_L == false)
        {
            Act_L = true;
            AudioClip audioClip = Resources.Load<AudioClip>("273373__sturmankin__wood-17a-boots-walk") as AudioClip;
            GetComponent<AudioSource>().clip = audioClip;
            audioSource.Play();
        }
        else if (Player.move == false &&Act_L)
        {
            Act_L = false;
            audioSource.Stop();
        }
    }
}