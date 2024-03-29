using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Scene1_mine_fight_GameManager : MonoBehaviour
{
    public static Scene1_mine_fight_GameManager instance;
    public MobPoolManager pool;
    public MobSpawner spawner;

    public int VictoryMobCount;
    public int MaxSpawnMobCount;
    [HideInInspector]
    public int CatchMobCount=0;

    [Header("UI")]
    public Text VictoryCount;
    public Text CatCount;
    public Status playerStatus;

    void Awake()
    {
        instance = this;
        if(VictoryMobCount < MaxSpawnMobCount) VictoryMobCount = MaxSpawnMobCount;
        VictoryCount.text = VictoryMobCount.ToString();
    }

    private void Start()
    {
        for (int i = 0; i < MaxSpawnMobCount; i++)
        {
            spawner.Spawn();
        }
    } //���������� ������ Awake��������

    private void Update()
    {
        int mob_cnt = CurMobCount();
        int dif = MaxSpawnMobCount - mob_cnt;
        if (dif > 0)
        {
            VictoryMobCount -= dif;
            print("���� �� ����: " + VictoryMobCount);
            if (VictoryMobCount <= 0)
            {
                Gameover(); //�¸����Ǹ�ŭ�� ���� ������� ���� �¸�
            }
            else // �¸����Ǳ��� �޼����� ���Ѱ�쿡 �ΰ��� ���
            {
                if(VictoryMobCount > mob_cnt)
                {
                    for (int i = 0; i < dif; i++)
                    {
                        spawner.Spawn();
                    }
                }
                else
                {
                    MaxSpawnMobCount = mob_cnt; //dif�� ���̻� �߻����� �ʾƾߵ�
                }
                CatchMobCount += dif;
            }
        }
        CatCount.text = CatchMobCount.ToString();
    }

    public int CurMobCount()
    {
        int res = 0;
        foreach (Transform child in transform)
        {
            if (child.gameObject.activeSelf) { res++; }
        }
        return res;
    }

    void Gameover()
    {
        playerStatus.player_win = true;
}
}
