using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class NpcQuest
{
    public static GameObject Npc; 
    public static float questnum = 0f;

    public static int get_badge; //����Ʈ��6�� ���� ����Ʈ������  1�̸� ����  ,get 1�̵Ǹ� ui���� on����
    public static int use_badge; // 1: ����� 0: ������ , use�� 1�̵Ǹ� ui���� off�β�������
    public static int clear_badge_mission; // clear���η� ������ ����Ʈâ ���� ���ؼ�.

    public static int get_key; //����Ʈ12�� ���� ����Ʈ������ ����� ��ȭâ�� ���⿡ clear���� �����ʿ� ����.
    public static int use_key;

    public static int get_basket;
    public static int use_basket;

    public static int get_water;
    public static int use_water;

    public static int Derrick_win;
    public static int Sokoban_win;

    public static int get_platina;
    public static int use_platina = 0;


}
