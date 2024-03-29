using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Equipment : MonoBehaviour
{
    public GameObject equip;


    void Start()
    {
        // consoleâ ������ ���� �����ϱ����ؼ� �̸� �ʱ�ȭ �����س�. ���ص� ������ü���� ���������.
        try
        {
            equip = GameObject.Find("UI").transform.Find("CharacterUi").gameObject.transform.Find("EquipSet").gameObject.transform.Find("initial").gameObject;
            Debug.Log(equip + "ã��!");
        }
        catch
        {
            Debug.Log(equip + "badge��ã��!");

        }
    }

    void Update()
    {
        Find_Equipment();
        //���丮 1������ ����
        if (NpcQuest.get_badge == 1)
        {
            equip.SetActive(true);
        }
        else if (NpcQuest.get_key == 1)  //battle_result���� get_key 1��ȯ
        {
            equip.SetActive(true);
        }
        else if (NpcQuest.get_basket == 1 )
        {
            equip.SetActive(true);
        }
        else if (NpcQuest.get_water == 1)
        {
            //�ڵ�� ���⼭ basket�̹��� �Ⱥ��̰���.
            GameObject basket = GameObject.Find("UI").transform.Find("CharacterUi").gameObject.transform.Find("EquipSet").gameObject.transform.Find("Basket").gameObject;
            basket.SetActive(false);
            equip.SetActive(true);
        }
        else if (NpcQuest.get_platina == 1)
        {
            equip.SetActive(true);
        }
        else
        {
            equip.SetActive(false);
        }

    }

    void Find_Equipment()
    {

        if (NpcQuest.questnum == 5)
        {
            try
            {
                equip = GameObject.Find("UI").transform.Find("CharacterUi").gameObject.transform.Find("EquipSet").gameObject.transform.Find("Badge").gameObject;
                Debug.Log(equip + "ã��!");
            }
            catch
            {
                Debug.Log(equip + "badge��ã��!");

            }
        }

        else if (NpcQuest.questnum == 10.5f)
        {
            try
            {
                equip = GameObject.Find("UI").transform.Find("CharacterUi").gameObject.transform.Find("EquipSet").gameObject.transform.Find("Key").gameObject;
                Debug.Log(equip + "ã��!");
            }
            catch
            {
                Debug.Log(equip + "key��ã��!");

            }
        }
        else if (NpcQuest.questnum == 15f)
        {
            try
            {
                equip = GameObject.Find("UI").transform.Find("CharacterUi").gameObject.transform.Find("EquipSet").gameObject.transform.Find("Basket").gameObject;
                Debug.Log(equip + "ã��!");
            }
            catch
            {
                Debug.Log(equip + "Basket��ã��!");

            }
        }
        else if (NpcQuest.questnum == 16f)
        {
            try
            {
                equip = GameObject.Find("UI").transform.Find("CharacterUi").gameObject.transform.Find("EquipSet").gameObject.transform.Find("Water_Basket").gameObject;

                Debug.Log(equip + "ã��!");
            }
            catch
            {
                Debug.Log(equip + "Water_Basket��ã��!");

            }
        }

        else if (NpcQuest.questnum == 49f)
        {
            try
            {
                equip = GameObject.Find("UI").transform.Find("CharacterUi").gameObject.transform.Find("EquipSet").gameObject.transform.Find("Platina").gameObject;

                Debug.Log(equip + "ã��!");
            }
            catch
            {
                Debug.Log(equip + "�÷�Ƽ����ã��!");

            }
        }







    }
}
