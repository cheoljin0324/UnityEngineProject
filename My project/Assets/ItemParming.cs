using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemParming : MonoBehaviour
{
    Collider[] settingItemCollider;
    List<GameObject> itemSetting = new List<GameObject>();

    List<GameObject> UserItem = new List<GameObject>();

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            UserItem.Add(itemSetting[0]);
            itemSetting[0].gameObject.SetActive(false);
        }
    }

    public void ItemSearch()
    {
        settingItemCollider = Physics.OverlapSphere(transform.position, 3f);
        if(itemSetting.Count != 0)
        {
            itemSetting.Clear();
        }
        for(int i =0;i <settingItemCollider.Length; i++)
        {
            if (settingItemCollider[i].CompareTag("Item"))
            {
                itemSetting.Add(settingItemCollider[i].gameObject);
            }
        }
    }
}
