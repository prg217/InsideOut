using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Photo : MonoBehaviour
{
    [SerializeField]
    private GameObject inven = null;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision) //접촉하고 있을 때
    {
        if (collision.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Destroy(gameObject);
                GameManager.photo++;

                if (GameManager.photo >= 2)
                {
                    inven.gameObject.SetActive(true);
                }
            }
        }
    }
}
