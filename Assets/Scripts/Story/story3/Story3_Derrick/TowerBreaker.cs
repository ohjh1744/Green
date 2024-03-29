using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TowerBreaker : MonoBehaviour
{
    private List<GameObject> clearOrder = new();
    public GameObject[] ClearOrderPoints;
    public Sprite BrokenTopSprite;
    public SpriteRenderer TopSpriteRenderer;
    public GameObject QuestPoints;

    GameObject DetoSo_potal;

    void Start()
    {
        if(NpcQuest.Derrick_win == 1)
        {
            QuestPoints.SetActive(false);
            TopSpriteRenderer.sprite = BrokenTopSprite;
        }

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            var hit = Physics2D.GetRayIntersection(ray);
            if (hit && hit.collider.TryGetComponent<TowerBreakPoint>(out TowerBreakPoint p))
            {
                p.BreakAction(0.1f);
            }
        }


    }

    public void UpdatePuzzle(GameObject point)
    {
        //포인트지점 추가
        clearOrder.Add(point);
        point.SetActive(false);

        bool flag = false;
        for (int i = 0; i < clearOrder.Count; i++)
        {
            if (ClearOrderPoints[i] != clearOrder[i]) // 순서 다른 경우 초기화
            {
                flag = true;

            }
        }
        if (flag)
        {
            foreach (var item in clearOrder)
            {
                item.SetActive(true);
            }
            clearOrder.Clear();
        }
        int j;
        for (j = 0; j < transform.childCount; j++)
        {
            if (transform.GetChild(j).gameObject.active == true)
            {
                break;
            }
        }
        if (j == transform.childCount)
        {
            TopSpriteRenderer.sprite = BrokenTopSprite;
            Win();
        }
    }


    // 이긴 경우
    void Win()
    {
        NpcQuest.questnum = 47;
        NpcQuest.Derrick_win = 1;
        try
        {
            DetoSo_potal = GameObject.Find("Potal").transform.Find("DetoSo").gameObject;
        }
        catch

        {
            Debug.Log(DetoSo_potal + " DetoSo_potal 못찾음!");
        }

        DetoSo_potal.SetActive(true);
        

    }
}
