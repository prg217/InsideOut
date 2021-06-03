using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static bool inventory = false;
    [SerializeField]
    private GameObject go_InventoryBase = null; // Inventory_Base 이미지
    [SerializeField]
    private GameObject go_SlotsParent = null;  // Slot들의 부모인 Grid Setting 

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            inventory = !inventory;

            if (inventory)
            {
                OpenInventory();
            }
            else
            {
                CloseInventory();
            }

        }
    }

    private void OpenInventory()
    {
        go_InventoryBase.SetActive(true);
    }

    private void CloseInventory()
    {
        go_InventoryBase.SetActive(false);
    }

}
