using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Unity.VisualStudio.Editor;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class BossAi_story2_Final : MonoBehaviour
{
    private bool isAttack;
    private int lastTargetIdx;

    private float save_t;
    private EnemyMovement movement;
    private Status status; //보스 체력에 따라 공격 스킬 확률 변동
    private LineRenderer lr;
    private Battle_Shooter Shooter;


    private SpriteRenderer spriteRenderer;
    AudioSource audiosource;

    [Header("ChangeTargetTime")]
    public float time = 3f;

    [Header("Tanks & Explosions")]
    public List<Animator> tanksAnims;
    public List<Animator> explosionAreas;
    public List<Animator> explosions;
    public GameObject tankBullet;
    public GameObject SlowArea;

    [Header("Target")]
    public GameObject target;

    [Header("MovePoints")]
    public List<Transform> points;

    [Header("Movement&Attack Animation")]
    public Animator anim;

    [Header("Sounds")]
    public List<AudioClip> audioclip = new List<AudioClip>();

    private void Start()
    {
        audiosource = GetComponent<AudioSource>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        status = GetComponent<Status>();
        movement = GetComponent<EnemyMovement>();
        Shooter = GetComponent<Battle_Shooter>();

        save_t = 0;
        lastTargetIdx = -1;

        lr = GetComponent<LineRenderer>();
        InvokeRepeating("Training", 0f, 1.5f);
    }

    //2스테이지 보스 전용 ai
    void Training()
    {
        if (movement.isAttack) return; // 중복 스킬 사용 방지
        StartCoroutine(TankAttack(target.transform.position));
    }

    private void Update()
    {
        if (!movement.isAttack)
        {
            MoveBoss();
        }
    }

    void MoveBoss()
    {
        if (Time.time - save_t > time)
        {
            var idx = UnityEngine.Random.Range(0, points.Count);
            if (lastTargetIdx == idx)
            {
                movement.target = points[lastTargetIdx + (UnityEngine.Random.Range(1, points.Count) % points.Count)].gameObject;
                lastTargetIdx = idx;
            }
            else
            {
                movement.target = points[idx].gameObject;
                lastTargetIdx = idx;
            }
            save_t = Time.time;
        }
    }

    IEnumerator TankAttack(Vector2 t)
    {
        movement.isAttack = true;
        //탱크 총알 개수 정하기
        var bullet_cnt = UnityEngine.Random.Range(0, tanksAnims.Count);
        List<Vector2> bullet_areas_dir = new List<Vector2>() { new Vector2(2f, 0f), new Vector2(-2f, 0f), new Vector2(0f, 2f), new Vector2(0f, -2f) }; //떨어질 지역의 중심좌표 설정을 위한 방향값

        //탱크 총알 개수에 따라 공격할 지역 선택
        List<int> selAreas = new List<int>(); //탱크 개수만큼 리스트 초기화
        for (int i = 0; i < tanksAnims.Count; i++)
        {
            selAreas.Add(i);
        }
        for (int i = 0; i < (tanksAnims.Count - bullet_cnt - 1); i++) //랜덤으로 선택되지 않은 지역은 제외
        {
            selAreas.Remove(UnityEngine.Random.Range(0, selAreas.Count));
        }
        List<Vector2> attackCenterPos = new List<Vector2>();
        //각 공격 지역에서 랜덤 위치를 공격 좌표로 설정
        foreach (var i in selAreas)
        {
            var pos = bullet_areas_dir[i] + t + new Vector2(UnityEngine.Random.Range(-2, 2), UnityEngine.Random.Range(-2, 2));
            attackCenterPos.Add(pos);
            explosionAreas[i].transform.position = pos;
            explosionAreas[i].SetTrigger("Explosion");
        }
        yield return new WaitForSeconds(1.5f);
        movement.isAttack = false;
        //정해진 지점으로 공격
        for (var i = 0; i < attackCenterPos.Count; i++)
        {
            tanksAnims[i].SetTrigger("Shoot");
            yield return new WaitForSeconds(0.1f);
            explosions[i].transform.position = attackCenterPos[i];
            explosions[i].SetTrigger("Explosion");
            //폭탄속 투명 총알 생성
            Instantiate(tankBullet, explosions[i].transform);

            //속도가 느려지는 구덩이 생성
            yield return new WaitForSeconds(0.2f);
            var slow = Instantiate(SlowArea);
            slow.transform.position = attackCenterPos[i];
            if (slow.TryGetComponent<SlowSpotEffect>(out SlowSpotEffect s))
            {
                s.life_time = 5f;
            }

            //총알 발사
            if (anim != null && System.Array.Exists(anim.parameters, p => p.name == "Shoot")) //공격할 애니메이션 확인
            {
                anim.SetTrigger("Shoot"); //캐릭터 애니메이션 내의 원거리 공격 Trigger이름은 일반적으로 Shoot 통일!
                yield return new WaitForSeconds(0.05f); // 애니메이션 재생동안 딜레이
            }
            else
            {
                print("No Character Animation Controller");
            }
            Shooter.Fire(0, (Vector2)target.transform.position - (Vector2)transform.position);
        }

        yield break;
    }
}
