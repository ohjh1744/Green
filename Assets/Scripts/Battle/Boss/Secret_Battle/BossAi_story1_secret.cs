using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Battle_Shooter))] //���Ÿ� ���ݽÿ� �ʼ�
[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(EnemyMovement))]
public class BossAi_story1_secret : MonoBehaviour
{
    private float last_attack_time;
    private EnemyMovement movement;
    private Battle_Shooter shooter;
    private LineRenderer lr;
    private ParticleSystem ps;
    private NavMeshAgent agent;


    AudioSource audiosource;

    [Header("Attack Animation")]
    public Animator anim;

    [Header("VFX")]
    public List<Material> particle_mat;


    [Header("Sounds")]
    public List<AudioClip> audioclip = new List<AudioClip>();

    // Start is called before the first frame update
    void Start()
    {
        last_attack_time = Time.time;
        agent = GetComponent<NavMeshAgent>();
        shooter = GetComponent<Battle_Shooter>();
        movement = GetComponent<EnemyMovement>();
        audiosource = GetComponent<AudioSource>();


        // �ؿ��ִ� �ڵ�� �Ʒ� ������ ����� �ڵ�
        lr = GetComponent<LineRenderer>();
        ps = GetComponent<ParticleSystem>();
        ps.Stop();
        InvokeRepeating("Training_1", 0f, 1f); //1�ʸ��� �Ʒ� ���� AI ����
    }

    //�Ʒ� ���� ���� ai
    void Training_1()
    {
        if (movement.isAttack) return; // �ߺ� ��ų ��� ����
        if (Time.time - last_attack_time > 5f) // 5�� �̻� ������ ���� ��쿡 ���Ÿ� ���� ����
        {
            StartCoroutine(Burst3());
        }
        else if(Random.Range(0,100) < 40) // 40%Ȯ���� Rush����
        {
            StartCoroutine(Rush());
        } else if(Vector2.Distance(movement.target.transform.position, transform.position) < 2f)
        {
            StartCoroutine(Slash());
        } 
    }


    //�Ʒ� ���� ���� ��ų
    private IEnumerator Rush() // �������� ��ο� ��ֹ��� �����ÿ� �����ϴ� ��ų, ��θ� �̸� �˷��ְ� ����
    {
        movement.isAttack = true;
        RaycastHit2D hit = Physics2D.BoxCast(GetComponent<BoxCollider2D>().bounds.center, GetComponent<BoxCollider2D>().bounds.size, 0f ,new Vector2(movement.direction.x, movement.direction.y), 100f, (-1) - (1 << LayerMask.NameToLayer("Ignore Raycast")));
        if (hit.collider != null && hit.collider.CompareTag("Player"))
        {
            if(lr !=  null) {
                lr.material = particle_mat[4];
                lr.enabled = true;
                lr.SetPosition(0, transform.position);
                lr.SetPosition(1, transform.position + (new Vector3(hit.point.x, hit.point.y, 0) - transform.position).normalized * 3f);
            }
            float up = Vector2.Dot(movement.face_direction, Vector2.up);
            float down = Vector2.Dot(movement.face_direction, Vector2.down);
            float left = Vector2.Dot(movement.face_direction, Vector2.left);
            float right = Vector2.Dot(movement.face_direction, Vector2.right);
            float maxDirection = Mathf.Max(up, down, left, right);
            var render = gameObject.GetComponent<ParticleSystemRenderer>();
            if(render != null) {
                if (maxDirection == down)
                    render.material = particle_mat[0];
                else if (maxDirection == up)
                    render.material = particle_mat[1];
                else if (maxDirection == left)
                    render.material = particle_mat[2];
                else render.material = particle_mat[3]; // �ٶ󺸴� ���⿡ ���� �ܻ� ���͸��� �޶���
            }
            yield return new WaitForSeconds(1f);
            if(ps!=null && lr!=null)
            {
                ps.Play();
                lr.enabled = false;
            }
            float DashPower = 10f;
            var rb = GetComponent<Rigidbody2D>();
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            rb.velocity = new Vector2(movement.direction.x * DashPower, movement.direction.y * DashPower);

            audiosource.clip = audioclip[0];
            audiosource.Play();

            yield return new WaitForSeconds(1f);
            rb.velocity = agent.velocity;
            if (ps!=null) 
                ps.Stop();
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            last_attack_time = Time.time; //������ ���� �����ÿ� �ð� �ʱ�ȭ
        }
        movement.isAttack = false;
        yield return null;
    }
    private IEnumerator Slash() // ���� �Ÿ����� ��������� Į�� �ֵθ��� ���� ���� ��ų, ���� �����̴� ��� ����
    {
        audiosource.clip = audioclip[1];
        audiosource.Play();
        movement.isAttack = true;
        if(anim != null)
        {
            anim.SetTrigger("Attack");
            yield return new WaitForSeconds(0.5f);
            print("Slash2");
        }
        last_attack_time = Time.time;
        movement.isAttack = false;
        yield return null;
    }

    private IEnumerator Burst3() // ���Ÿ� ȭ���� 3�����ϴ� ��ų, �⸦ ������ �׼��� ���� ���� ������ ����
    {
        audiosource.clip = audioclip[2];
        movement.isAttack = true;
        print("Burst3");
        for (int i = 0; i<3; i++) {
            var dir = (movement.target.transform.position - transform.position).normalized; //�� �߻�ø��� Ÿ�� ��ġ ����
            if (shooter.Fire(0, dir) == false) { break; }
            audiosource.Play();
            yield return new WaitForSeconds(0.5f);
            last_attack_time = Time.time; //������ ���� �����ÿ� �ð� �ʱ�ȭ
        }
        movement.isAttack = false;
        yield return null;
    }
}
