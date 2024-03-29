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
            if(!wasPlay) { anim.Play(0); enemyMovement.isAttack = false; wasPlay = isPlay; } //�߰��� ���۵Ǵ� �����ӿ��� �ȴ� �ִϸ��̼� �����ϰ� ������� (��ȸ��)
            if (Time.time - last_attack_time - attack_delay > 0) // ��ų ���� ������ ���� ���� ���� ��� ������, �ʿ������ ���ְ� Fire�� �ᵵ �������ϴ�.
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
                enemyMovement.isAttack = false; //�̵� �Ͻ����� ����
            }
        }
    }

    void ShootAttack()
    {
        if(shooter.Fire(0, enemyMovement.direction))
        {
            audio.Play(0);
            enemyMovement.isAttack = true;
            last_attack_time = Time.time; //�ð� �����ϰ� 1~5�� ������ �����̿� ���� ���� ����
        }
    }

    void SpinAttack()
    {
        if (Vector2.Distance(enemyMovement.target.transform.position, transform.position) < enemyMovement.agent.stoppingDistance) //NavAgent�� StoppintDistance�� ���� ���� �Ÿ� ���ϱ�
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
        if (select.Count > 0) //NavAgent�� StoppintDistance�� ���� ���� �Ÿ� ���ϱ�
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
            select[idx].curHp += GetComponent<Status>().atk; // ���� �������ͽ��� ���ݷ¸�ŭ ȸ��
            last_attack_time = Time.time; //�ð� �����ϰ� 1~5�� ������ �����̿� ���� ���� �Ѿ� �߻�
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
        // ���� �ڵ�� �� ������ ���� �ʱ� ��������
    }
}
