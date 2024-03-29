using HardLight2DUtil;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(EnemyMovement))]
public class EnemyAI : MonoBehaviour
{
    public enum AttackType
    {
        SpinAttack,
        ShootAttack,
        Heal
    }

    private bool wasPlay = false;
    private float last_attack_time;
    private float attack_delay;
    private Battle_Shooter shooter;
    private Animator anim;
    private EnemyMovement enemyMovement;

    [Header("AttackType")]
    public AttackType attack;
    [Header("AttackPauseTime")]
    public float attackPauseTime = 2f;
    [Header("AttackTime Cycle")]
    public float minTimeCycle = 1f;
    public float maxTimeCycle = 5f;
    [Header("Sfx")]
    public AudioSource audio;

    [HideInInspector]
    public bool isPlay;
    

    // Start is called before the first frame update
    void Start()
    {
        enemyMovement = GetComponent<EnemyMovement>();
        TryGetComponent<Animator>(out anim);
        TryGetComponent<Battle_Shooter>(out shooter);
        last_attack_time = Time.time + 2f;
        transform.rotation = Quaternion.Euler(0, 0, 0);
        if(anim!= null) anim.StopPlayback();
        wasPlay = false;
        isPlay = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlay)
        {
            if(!wasPlay) { anim.Play(0); enemyMovement.isAttack = false; wasPlay = isPlay; } //추격이 시작되는 프레임에서 걷는 애니메이션 시작하게 만들어줌 (일회성)
            if (Time.time - last_attack_time - attack_delay > 0) // 스킬 성공 유무에 따라 공격 직후 잠깐 멈춤기능, 필요없으면 없애고 Fire만 써도 괜찮습니다.
            {
                switch(attack)
                {
                    case AttackType.ShootAttack:
                        ShootAttack(); break;
                    case AttackType.SpinAttack:
                        SpinAttack(); break;
                    case AttackType.Heal:
                        Heal(); break;
                }
                attack_delay = Random.Range(minTimeCycle, maxTimeCycle);
            }
            if (Time.time - last_attack_time < attackPauseTime) return;
            else
            {
                enemyMovement.isAttack = false; //이동 일시정지 해제
            }
        }
    }

    void ShootAttack()
    {
        if(shooter.Fire(0, enemyMovement.direction))
        {
            audio.Play(0);
            enemyMovement.isAttack = true;
            last_attack_time = Time.time; //시간 랜덤하게 1~5초 사이의 딜레이에 따라 랜덤 공격
        }
    }

    void SpinAttack()
    {
        if (Vector2.Distance(enemyMovement.target.transform.position, transform.position) < enemyMovement.agent.stoppingDistance) //NavAgent의 StoppintDistance로 근접 공격 거리 정하기
        {
            if(!audio.isPlaying)
            {
                audio.loop = true;
                audio.Play(0);
            }
            enemyMovement.isAttack = true;
            anim.SetBool("spinAttack", true);
            last_attack_time = Time.time;
        }
        else
        {
            audio.Stop();
            anim.SetBool("spinAttack", false);
        }
    }

    void Heal()
    {
        Status[] frends = transform.parent.GetComponentsInChildren<Status>();
        List<Status> select = new List<Status>();
        for (int i = 0; i < frends.Length; i++)
        {
            Status status = frends[i];
            if( status.curHp < status.hp) { select.Add(status); }
        }
        if (select.Count > 0) //NavAgent의 StoppintDistance로 근접 공격 거리 정하기
        {
            int idx = Random.Range(0, select.Count);
            enemyMovement.isAttack = true;
            anim.SetTrigger("heal");
            var otheranim = GetComponentInChildren<OtherHealingEffectControl>(true);
            if(otheranim != null)
            {
                otheranim.createPos = select[idx].transform.position;
                otheranim.gameObject.SetActive(true);
                otheranim.CreateEffect();
            }
            audio.Play(0);
            select[idx].curHp += GetComponent<Status>().atk; // 본인 스테이터스의 공격력만큼 회복
            last_attack_time = Time.time; //시간 랜덤하게 1~5초 사이의 딜레이에 따라 랜덤 총알 발사
        }
    }

    private void OnEnable()
    {
        enemyMovement = GetComponent<EnemyMovement>();
        enemyMovement.target = GameObject.Find("Player").gameObject;
        if (anim!=null) anim.StopPlayback();
        enemyMovement.isAttack = true;
        isPlay = false;
        wasPlay = false;
        last_attack_time = Time.time + 2f;
        // 위의 코드는 몹 리젠을 위한 초기 설정값임
    }
}
