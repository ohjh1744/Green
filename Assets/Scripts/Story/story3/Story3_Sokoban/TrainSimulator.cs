using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[System.Serializable]


public struct PathInf
{
    public int EventPathIdx;
    public BlockControl[] EventBlocks;
}

[System.Serializable]
public struct TrainPath
{
    public Vector3[] points;
    public PathInf[] EventPaths;
}

public class TrainSimulator : MonoBehaviour
{
    private bool isCollision = false;
    private int resetEndPathIdx;
    private int pathIdx;
    public Vector3 startPos;
    public int EndPathIdx;
    public TrainControl Train;
    public float TrainSpeed;
    public TrainPath TrainPath;


    public GameObject Trail;
    public GameObject Light_image;


    void Game_finish()
    {
        if (NpcQuest.Sokoban_win == 1)
        {
            Light_image.SetActive(false);
            Trail.GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    void Start()
    {
        pathIdx = 0;
        Train.transform.position = startPos;
        resetEndPathIdx = EndPathIdx;

        Game_finish();
    }

    // Update is called once per frame
    void Update()
    {
        Game_finish();

        if (Input.GetMouseButtonDown(0) && isCollision)
        {
            pathIdx = 0;
            EndPathIdx = resetEndPathIdx;
            Train.transform.position = startPos;
            Train.isPaussd = false;
        }

        if (Train.isPaussd) return;

        // 설정된 지점까지 열차 이동
        if (Train.transform.position != TrainPath.points[pathIdx])
        {
            Train.transform.position = Vector2.MoveTowards(Train.transform.position, TrainPath.points[pathIdx], TrainSpeed * Time.deltaTime);
        }
        else //해당 지점이 분기점 지점인지 확인
        {
            if (EndPathIdx == pathIdx) return;

            var isReset = false;
            foreach (var item in TrainPath.EventPaths)
            {
                // 특정 위치에서 기차 분기점있는지 확인하고 있으면 path 갱신
                if (item.EventPathIdx == pathIdx)
                {
                    isReset = ResetPath(item);
                    break;
                }
            }
            if (!isReset)
            {
                pathIdx++;
            }
            //열차 회전 갱신
            var dif = TrainPath.points[pathIdx] - Train.transform.position;
            var rotationZ = Mathf.Atan2(dif.y, dif.x) * Mathf.Rad2Deg;
            Train.transform.rotation = Quaternion.Euler(0, 0, rotationZ + 90f);
        }
    }

    bool ResetPath(PathInf inf)
    {
        foreach (var item in inf.EventBlocks)
        {
            //만약 해당 block지점이 안막힌 경우 정해진 pathPointIndex로 경로 재설정
            if (!item.isBlocked)
            {
                pathIdx = item.NextPathPointIdx;
                EndPathIdx = item.EndPathPointIdx;
                return true; //경로가 새로 갱신된 경우 true반환
            }
        }
        return false; //경로가 새로 갱신되지 않은 경우 false반환
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Player"))
        {
            isCollision = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.collider.CompareTag("Player"))
        {
            isCollision = false;

        }
    }
}
