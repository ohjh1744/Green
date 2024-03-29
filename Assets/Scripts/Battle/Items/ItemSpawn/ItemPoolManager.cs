using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[Serializable]
public struct ItemPoolInf
{
    public GameObject Item;
    public int MaxCount;
}

public class ItemPoolManager : MonoBehaviour
{
    public List<ItemPoolInf> Items;

    List<GameObject>[] pools;

    void Awake()
    {
        pools = new List<GameObject>[Items.Count];
        for (int i = 0; i < Items.Count; i++)
        {
            pools[i] = new List<GameObject>();
        }
    }

    public GameObject Get(int idx)
    {
        if(idx < 0 || idx+1 > Items.Count ) return null; //�ε��� ������ ��� ��� null��ȯ
        GameObject select = null;

        foreach (GameObject item in pools[idx])
        {
            if (!item.activeSelf)
            {
                select = item;
                select.SetActive(true);
                break;
            }
        }

        if (select == null) 
        {
            if (Items[idx].MaxCount <= pools[idx].Count) return null; //������ �ִ�ġ�� �ʰ��� ��� null��ȯ
            select = Instantiate(Items[idx].Item, transform);
            pools[idx].Add(select);
        }
        return select;
    }


    ///�߰��ϰ� ���� ������ ��ɿ� ���� �ٸ� Ŭ������ �����ϰ� ���
}
