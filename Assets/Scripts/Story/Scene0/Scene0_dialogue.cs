using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Scene0_dialogue : MonoBehaviour
{
    public GameObject text_show;
    public GameObject map_show;
    public Text text;

    int talknum = 0;
    string[] talkbox = new string[5];

    void Awake()
    {
        talkbox[0] = "���ΰ�: ��...���� �����߱�... ";
        talkbox[1] = "���ΰ�: ���Ⱑ �ڵ��� ������� ���� ������ �̷� ���� �Ʒ����ΰ�? ";
        talkbox[2] = "���ΰ�: Ȯ���� �� ��ΰ� ���� ������ ���� ���̴±�..";
        talkbox[3] = "���ΰ�: ������ ������ �����ϴ� �ڵ������.. �������� �� �ű��ϱ�.";
        talkbox[4] = "���ΰ�: �������� ���� �� �迡 �� �ѷ�����?";
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if(talknum == 0)
            {
                text.text = talkbox[talknum];
                text_show.SetActive(true);
                talknum = 1;
            }
            else if (talknum == 1)
            {
                text.text = talkbox[talknum];
                text_show.SetActive(true);
                talknum = 2;
            }
            else if (talknum == 2)
            {
                text.text = talkbox[talknum];
                text_show.SetActive(true);
                map_show.SetActive(true);
                talknum = 3;
            }
            else if (talknum == 3)
            {
                text.text = talkbox[talknum];
                text_show.SetActive(true);
                talknum = 4;
            }
            else if (talknum == 4)
            {
                text.text = talkbox[talknum];
                text_show.SetActive(true);
                talknum = 5;
            }
            else if (talknum == 5)
            {
                SceneManager.LoadScene(1);
            }
        }




    }
}
