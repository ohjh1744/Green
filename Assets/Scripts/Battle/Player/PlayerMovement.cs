using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(TrailRenderer))]
public class PlayerMovement : MonoBehaviour
{

    float h;
    float v;
    bool isDash;
    bool isDashCoolDown;
    bool isHorizionMove;
    Rigidbody2D rb;
    TrailRenderer tr;
    SkillUIProvider skillUIProvider;
    UICoolTimeControl dashUI;

    //����޴�â�̳� �̴ϸ�â������ fire�Լ� �ȸ԰��ϵ���
    public GameObject submenu;
    public GameObject Ui_minimap;

    [Header("PlayerMovement")]
    public bool LockDiagonal = true; //�밢�� �̵� ��ݿ���
    public float Speed = 5f;
    public Animator anim;

    [HideInInspector] public Vector2 dirVec;

    [Header("Dash Setting")]
    public string KeySetting;
    public float DashPower = 14f;
    public float DashTime = 0.1f;
    public float DashCoolDown = 1F;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        tr = GetComponent<TrailRenderer>();
        if (TryGetComponent<SkillUIProvider>(out skillUIProvider))
        {
            dashUI = skillUIProvider.CoolTimeDash;
        }
        dirVec = Vector2.down;
        isDash = false;
        isDashCoolDown = false;

    }

    // Update is called once per frame
    void Update()
    {

        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");
        // Ű �Է�(����,����) ��

        bool hDown = Input.GetButtonDown("Horizontal");
        bool vDown = Input.GetButtonDown("Vertical");
        bool hUp = Input.GetButtonUp("Horizontal");
        bool vUp = Input.GetButtonUp("Vertical");
        // Ű Down,Up üũ


        if (hDown)
            isHorizionMove = true;
        else if (vDown)
            isHorizionMove = false;
        else if (hUp || vUp)
            isHorizionMove = h != 0;
        //Ű �ߺ� �Է� ó��

        if (anim != null)
        {
            if (anim.GetInteger("vAxisRaw") != v)
            { //���� v���� �ٸ� ��쿡 �ִϸ��̼� ��ȭ
                anim.SetBool("isChange", true);
                anim.SetInteger("vAxisRaw", (int)v);
            }
            else if (anim.GetInteger("hAxisRaw") != h) //���� ���� �ٸ� ��쿡 �ִϸ��̼� ��ȭ
            {
                anim.SetBool("isChange", true);
                anim.SetInteger("hAxisRaw", (int)h);
            }
            else anim.SetBool("isChange", false);
        }
        // �̵� �ִϸ��̼�

        if ((vDown || hUp || vUp) && v == 1)
            dirVec = Vector2.up;
        else if ((vDown || hUp || vUp) && v == -1)
            dirVec = Vector2.down;
        else if ((hDown || hUp || vUp) && h == -1)
            dirVec = Vector2.left;
        else if ((hDown || hUp || vUp) && h == 1)
            dirVec = Vector2.right;

        //�ٶ󺸴� ���⺤�� ����

        bool dash = Input.GetButtonDown(KeySetting);
        if (dash&&!isDashCoolDown)
        {
            Can_Dash();
        }
    }

    private void FixedUpdate()
    {
        if (isDash) return; //�뽬�߿��� �̵� �Ұ�, but ������Ʈ���� Ű�Է� ������ �����ؾߵ�

        Vector2 moveVec = new Vector2(h, v);

        float adjustSpeed = 1f; // �밢�� �̵��� �ӵ� ����
        if (h != 0 && v != 0) adjustSpeed = 0.7f;

        if (LockDiagonal)
        {
            moveVec = isHorizionMove ? new Vector2(h, 0) : new Vector2(0, v);
            adjustSpeed = 1f;
        } //�밢���̵� ���ϴ� ��쿡 isHorizonMove�� ���� ���� �Ǵ� ���� �̵��� ����

        rb.velocity = moveVec * Speed * adjustSpeed;
    }

    private IEnumerator Dash()
    {
        isDash = true;
        isDashCoolDown = true;
        rb.velocity = new Vector2(dirVec.x * DashPower, dirVec.y * DashPower);
        tr.emitting = true;
        yield return new WaitForSeconds(DashTime);
        if(dashUI!= null) StartCoroutine(dashUI.CoolTime(DashCoolDown));
        isDash = false;
        tr.emitting = false;
        yield return new WaitForSeconds(DashCoolDown);
        isDashCoolDown = false;
    }

    void Can_Dash()
    {

        // ����޴��� �ʹ�ư ������������ ��ȭ���ϵ��ϸ���
        submenu = GameObject.Find("UI").transform.Find("MenuSet").gameObject;
        Ui_minimap = GameObject.Find("UI").transform.Find("Map_button").transform.Find("MiniMapUi").gameObject;

        if (submenu.activeSelf == false && Ui_minimap.activeSelf == false)
        {
            StartCoroutine(Dash());
        }
    }
}
