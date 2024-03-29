using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class PlayerAction : MonoBehaviour
{
    public float Speed;
    public GameManager manager;

    Rigidbody2D rigid;
    Animator anim;
    float h;
    float v;
    bool isHorizonMove;
    Vector3 dirVec;

    //����޴�â�̳� �̴ϸ�â������ ��ȭâ �ȴ������� �ϱ����� ����
    public GameObject submenu;
    public GameObject Ui_minimap;


    void Awake()
    {
        
        //��������׽�Ʈ�� -> ��б������Ѿ�� �÷��̾������Ǻ���  �������ɵ�?
        if(CheckEnter.EnterSecretbattle == 1)
        {
            if(SceneManager.GetActiveScene().buildIndex == 2)
            {
                transform.position = new Vector2(9, -3.5f);
                CheckEnter.EnterSecretbattle = 0;
            } 
        }

        //��б����� -> ���ε��óѾ�� ������ ����
        if(CheckEnter.EnterSecrethouse == 1)
        {
            if (SceneManager.GetActiveScene().buildIndex == 1)
            {
                transform.position = new Vector2(-21.5f, 20.5f);
                CheckEnter.EnterSecrethouse = 0;
            }
        }
        //�̷ξ� -> ���� ���þ��Ѿ�� �����Ǻ���
        if(CheckEnter.FromCitytoMiro == 1)
        {
            if (SceneManager.GetActiveScene().buildIndex == 1)
            {
                transform.position = new Vector2(11f, 29.5f);
                CheckEnter.FromCitytoMiro = 0;
            }
        }

        //���� -> �̷ξ� �Ѿ�� �����Ǻ���
        if (CheckEnter.FromMirotoGaia == 1)
        {
            if (SceneManager.GetActiveScene().buildIndex == 4)
            {
                transform.position = new Vector2(13f, 3f);
                CheckEnter.FromMirotoGaia = 0;
            }
        }

        //������������� -> �����Ѿ��
        if (CheckEnter.FromGaiatofight == 1)
        {
            if (SceneManager.GetActiveScene().buildIndex == 5)
            {
                transform.position = new Vector2(17f, 12f);
                CheckEnter.FromGaiatofight = 0;
            }
        }

        //1������������ -> �Ʒ���
        if (CheckEnter.FromAreatoBoss == 1)
        {
            if (SceneManager.GetActiveScene().buildIndex == 1)
            {
                transform.position = new Vector2(9f, 19f);
                CheckEnter.FromAreatoBoss = 0;
            }
        }

        //2���������� -> �Ʒ���
        if (CheckEnter.FromAreatoFire == 1)
        {
            if (SceneManager.GetActiveScene().buildIndex == 1)
            {
                transform.position = new Vector2(16f, 19f);
                CheckEnter.FromAreatoFire = 0;
            }
        }

        if (CheckEnter.FromFiretoDesert == 1)
        {
            if (SceneManager.GetActiveScene().buildIndex == 8)
            {
                transform.position = new Vector2(7f, 0);
                CheckEnter.FromFiretoDesert = 0;
            }
        }

        if (CheckEnter.FromDesrttoTop == 1)
        {
            if (SceneManager.GetActiveScene().buildIndex == 9)
            {
                transform.position = new Vector2(5f, 13f);
                CheckEnter.FromDesrttoTop = 0;
            }
        }

        if (CheckEnter.FromToptoKilled == 1)
        {
            if (SceneManager.GetActiveScene().buildIndex == 10)
            {
                transform.position = new Vector2(-1.5f, 33f);
                CheckEnter.FromToptoKilled = 0;
            }
        }

        if (CheckEnter.FromDeserttoSecret == 1)
        {
            if (SceneManager.GetActiveScene().buildIndex == 9)
            {
                transform.position = new Vector2(29.12f, 13f);
                CheckEnter.FromDeserttoSecret = 0;
            }
        }

        if (CheckEnter.FromSecrettoFightNinja == 1)
        {
            if (SceneManager.GetActiveScene().buildIndex == 12)
            {
                transform.position = new Vector2(8.29f, -2.41f);
                CheckEnter.FromSecrettoFightNinja = 0;
            }
        }

        if (CheckEnter.FromDeserttoEscape == 1)
        {
            if (SceneManager.GetActiveScene().buildIndex == 9)
            {
                transform.position = new Vector2(44f, -1f);
                CheckEnter.FromDeserttoEscape = 0;
            }
        }

        if (CheckEnter.FromEscapetoExp == 1)
        {
            if (SceneManager.GetActiveScene().buildIndex == 14)
            {
                transform.position = new Vector2(11f, 2.5f);
                CheckEnter.FromEscapetoExp = 0;
            }
        }

        if (CheckEnter.FromDeserttoRo == 1)
        {
            if (SceneManager.GetActiveScene().buildIndex == 9)
            {
                transform.position = new Vector2(17.08f, -16.46f);
                CheckEnter.FromDeserttoRo = 0;
            }
        }

        if (CheckEnter.FromOctoOthouse == 1)
        {
            if (SceneManager.GetActiveScene().buildIndex == 19)
            {
                transform.position = new Vector2(-14.26f, -11.82f);
                CheckEnter.FromDeserttoRo = 0;
            }
        }

        if (CheckEnter.FromOctoCrab == 1)
        {
            if (SceneManager.GetActiveScene().buildIndex == 19)
            {
                transform.position = new Vector2(-2.02f, 8.45f);
                CheckEnter.FromOctoCrab = 0;
            }
        }

        if (CheckEnter.FromOctoDerrick == 1)
        {
            if (SceneManager.GetActiveScene().buildIndex == 19)
            {
                transform.position = new Vector2(13f, 11f);
                CheckEnter.FromOctoDerrick = 0;
            }
        }

        if (CheckEnter.FromDetoSo == 1)
        {
            if (SceneManager.GetActiveScene().buildIndex == 23)
            {
                transform.position = new Vector2(10f, 0.9f);
                CheckEnter.FromDetoSo = 0;
            }
        }

        if (CheckEnter.FromOctoPo == 1)
        {
            if (SceneManager.GetActiveScene().buildIndex == 19)
            {
                transform.position = new Vector2(13.5f, -16f);
                CheckEnter.FromOctoPo = 0;
            }
        }



        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
       

    }

 
    void Update()
    {
        Debug.Log(NpcQuest.questnum);
        Debug.Log(NpcQuest.Npc);
        //move value
        //�����߿��� �������̰�
        h = manager.isTalking ? 0 : Input.GetAxisRaw("Horizontal");
        v = manager.isTalking ? 0 : Input.GetAxisRaw("Vertical");

        //Check Button Down & Up
        bool hDown = manager.isTalking ? false : Input.GetButtonDown("Horizontal");
        bool vDown = manager.isTalking ? false : Input.GetButtonDown("Vertical");
        bool hUp = manager.isTalking ? false : Input.GetButtonUp("Horizontal");
        bool vUp= manager.isTalking ? false : Input.GetButtonUp("Vertical");
     

        //Check Horizontal Move
        // ray direction -> �� ������ ���� ����.
        if (hDown)
        {
            isHorizonMove = true;
            if(h == 1)
            {
                dirVec = Vector3.right;
            }
            else if(h == -1)
            {
                dirVec = Vector3.left;
            }
 
        }
        else if (vDown)
        {
            isHorizonMove = false;
            if (v == 1)
            {
                dirVec = Vector3.up;
            }
            else if (v == -1)
            {
                dirVec = Vector3.down;
            }
        }
        else if(hUp || vUp) // v- h - v or h - v - h �� �̵��Ҷ� ���ߴ� ���� ,  �翷Ű�� �������¿��� ����Ű�� ���� �̵������ʰ� ���ߴ� ���� �����ڵ�
        {
            isHorizonMove = h != 0;
            if(!(h == 0 && v == 0))   // ray�� ��� ���� �� ���� hup || vUp ���Ƕ����� �����Ƿ� �������� �־������. ��, �����츸 �����ϸ� ray�� ��������.
            {
                dirVec = isHorizonMove ? new Vector3(h, 0, 0) : new Vector3(0, v, 0);
            }

        }

        PlayerAnimation();   
        UseItem();
        Can_talk();


    }


    void FixedUpdate()
    {
        Playermove();
        scanNpc();

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // ��б��� ���� ����
        if(collision.tag == "Secrethouse")
        {
            CheckEnter.EnterSecrethouse = 1;
            SceneManager.LoadScene(2);
        }

        //��б��� ������� ����
        else if (collision.tag == "Secretbattle")
        {
            CheckEnter.EnterSecretbattle = 1;
            SceneManager.LoadScene(3);
        }

        else if (collision.tag == "Area")
        {
            SceneManager.LoadScene(1);
        }

        else if (collision.tag == "AreatoMiro")
        {
            CheckEnter.FromCitytoMiro = 1;
            SceneManager.LoadScene(4);
        }

        else if(collision.tag == "MirotoGaia")
        {
            CheckEnter.FromMirotoGaia = 1;
            SceneManager.LoadScene(5);
        }
        else if(collision.tag == "GaiatoMiro")
        {
            SceneManager.LoadScene(4);
        }
        else if (collision.tag == "Gaiatofight")
        {
            CheckEnter.FromGaiatofight = 1;
            SceneManager.LoadScene(6);
        }
        else if (collision.tag == "AreatoBoss")
        {
            CheckEnter.FromAreatoBoss = 1;
            SceneManager.LoadScene(7);
        }
        else if (collision.tag ==  "AreatoFire")
        {
            CheckEnter.FromAreatoFire = 1;
            SceneManager.LoadScene(8);
        }
        else if (collision.tag == "FiretoArea")
        {
            SceneManager.LoadScene(1);
        }
        else if(collision.tag == "FiretoDesert")
        {
            CheckEnter.FromFiretoDesert = 1;
            SceneManager.LoadScene(9);
        }
        else if (collision.tag == "DeserttoFire")
        {
            SceneManager.LoadScene(8);
        }
        else if (collision.tag == "DeserttoTop")
        {
            CheckEnter.FromDesrttoTop = 1;
            SceneManager.LoadScene(10);
        }
        else if (collision.tag == "ToptoDesert")
        {
            SceneManager.LoadScene(9);
        }
        else if (collision.tag == "ToptoKilled")
        {
            CheckEnter.FromToptoKilled = 1;
            SceneManager.LoadScene(11);
        }
        else if (collision.tag == "KilledtoTop")
        {
            SceneManager.LoadScene(10);
        }
        else if (collision.tag == "DeserttoSecret")
        {
            CheckEnter.FromDeserttoSecret = 1;
            SceneManager.LoadScene(12);
        }
        else if (collision.tag == "SecrettoDesert")
        {
            SceneManager.LoadScene(9);
        }
        else if (collision.tag == "SecrettoFightNinja")
        {
            CheckEnter.FromSecrettoFightNinja = 1;
            SceneManager.LoadScene(13);
        }
        else if (collision.tag == "DeserttoEscape")
        {
            CheckEnter.FromDeserttoEscape = 1;
            SceneManager.LoadScene(14);
        }
        else if (collision.tag == "EscapetoDesert")
        {
            SceneManager.LoadScene(9);
        }
        else if (collision.tag == "EscapetoExp")
        {
            CheckEnter.FromEscapetoExp = 1;
            SceneManager.LoadScene(15);
        }
        else if (collision.tag == "ExptoBoss")
        {
            SceneManager.LoadScene(16);
        }
        else if (collision.tag == "ExptoEscape")
        {
            SceneManager.LoadScene(14);
        }
        else if (collision.tag == "DeserttoRo")
        {
            CheckEnter.FromDeserttoRo = 1;
            SceneManager.LoadScene(17);
        }
        else if (collision.tag == "RotoDesert")
        {
            SceneManager.LoadScene(9);
        }
        else if(collision.tag == "LoadtoWhale")
        {
            SceneManager.LoadScene(18);
        }
        else if (collision.tag == "WhaletoOc")
        {
            SceneManager.LoadScene(19);
        }
        else if (collision.tag == "OctoOthouse")
        {
            CheckEnter.FromOctoOthouse = 1;
            SceneManager.LoadScene(20);
        }
        else if (collision.tag == "OthousetoOc")
        {
            SceneManager.LoadScene(19);
        }
        else if (collision.tag == "OctoCrab")
        {
            CheckEnter.FromOctoCrab = 1;
            SceneManager.LoadScene(22);
        }
        else if (collision.tag == "CrabtoOc")
        {
            SceneManager.LoadScene(19);
        }
        else if (collision.tag == "OctoDerrick")
        {
            CheckEnter.FromOctoDerrick = 1;
            SceneManager.LoadScene(23);
        }
        else if (collision.tag == "DerricktoOc")
        {
            SceneManager.LoadScene(19);
        }
        else if (collision.tag == "DetoSo")
        {
            CheckEnter.FromDetoSo = 1;
            SceneManager.LoadScene(24);
        }
        else if (collision.tag == "SotoDe")
        {
            SceneManager.LoadScene(23);
        }
        else if (collision.tag == "OctoPo")
        {
            CheckEnter.FromOctoPo = 1;
            SceneManager.LoadScene(25);
        }
        else if (collision.tag == "PotoOc")
        {
            SceneManager.LoadScene(19);
        }





    }

    void Can_talk()
    {

        // ����޴��� �ʹ�ư ������������ ��ȭ���ϵ��ϸ���
        submenu = GameObject.Find("UI").transform.Find("MenuSet").gameObject;
        Ui_minimap = GameObject.Find("UI").transform.Find("Map_button").transform.Find("MiniMapUi").gameObject;

        if (submenu.activeSelf == false && Ui_minimap.activeSelf == false)
        {
            talk();
            monologue();
        }
    }


    void PlayerAnimation()
    {
        //animation
        //transition�� ���������� �¿�� �ִϸ��̼ǵ����� �ȴ�. //����Ǽ�? �ٵ� ����..
        //isChange�� walk �ΰ����̻���� ��ġ���ʰ� �۵�����.
        if (anim.GetInteger("hAxisRaw") != h)
        {
            anim.SetBool("isChange", true);
            anim.SetInteger("hAxisRaw", (int)h);
        }
        else if (anim.GetInteger("vAxisRaw") != v)
        {
            anim.SetBool("isChange", true);
            anim.SetInteger("vAxisRaw", (int)v);
        }
        else
        {
            anim.SetBool("isChange", false);
        }
    }

    void Playermove()
    {
        //�÷��� ���� �ϳ��� ����, �����̵� ����
        //Move
        Vector2 moveVec = isHorizonMove ? new Vector2(h, 0) : new Vector2(0, v);
        rigid.velocity = moveVec * Speed;
    }

    void UseItem()
    {
        if(NpcQuest.get_badge == 1)
        {
            if (Input.GetButtonDown("UseItem"))
            {
                NpcQuest.use_badge = 1;
                NpcQuest.get_badge = 0;
            }
        }
        else if(NpcQuest.get_key == 1 && NpcQuest.Npc != null && NpcQuest.Npc.name == "Npc9")
        {
            
            if (Input.GetButtonDown("UseItem"))
            {
                NpcQuest.questnum = 11;
                NpcQuest.use_key = 1;   //�̰� �ʿ� ���µ�?
                NpcQuest.get_key = 0;
                
            }
        }
        else if(NpcQuest.get_basket == 1 && NpcQuest.Npc != null && NpcQuest.Npc.name == "Npc12")
        {
            if (Input.GetButtonDown("UseItem"))
            {
                NpcQuest.questnum = 16; // ���߸� ���ٱ��Ϸ� �ٲ��ֱ����ؼ�.
                NpcQuest.use_basket = 1;  //�̺κе� ���� �ʿ� ���µ�?
                NpcQuest.get_basket = 0;
                NpcQuest.get_water =1;
               
            }
        }
        else if (NpcQuest.get_water == 1 && NpcQuest.Npc != null && NpcQuest.Npc.name == "Burning1")
        {

            if (Input.GetButtonDown("UseItem"))
            {
                NpcQuest.Npc.SetActive(false);
                NpcQuest.questnum = 17;
                NpcQuest.use_water = 1;

            }
        }
        else if (NpcQuest.get_water == 1 && NpcQuest.use_water == 1 && NpcQuest.Npc != null && NpcQuest.Npc.name == "Burning2")
        {

            if (Input.GetButtonDown("UseItem"))
            {
                NpcQuest.Npc.SetActive(false);
                NpcQuest.questnum = 18;
                NpcQuest.use_water = 2;

            }
        }
        else if (NpcQuest.get_water == 1 && NpcQuest.use_water == 2 && NpcQuest.Npc != null && NpcQuest.Npc.name == "Burning3")
        {

            if (Input.GetButtonDown("UseItem"))
            {
                NpcQuest.Npc.SetActive(false);
                NpcQuest.questnum = 19;
                NpcQuest.use_water = 3;

            }
        }

        else if (NpcQuest.get_water == 1 && NpcQuest.use_water == 3 && NpcQuest.Npc != null && NpcQuest.Npc.name == "Burning4")
        {

            if (Input.GetButtonDown("UseItem"))
            {
                NpcQuest.Npc.SetActive(false);
                NpcQuest.questnum = 20;
                NpcQuest.use_water = 4;

            }
        }
        else if (NpcQuest.get_water == 1 && NpcQuest.use_water == 4 && NpcQuest.Npc != null && NpcQuest.Npc.name == "Burning5")
        {

            if (Input.GetButtonDown("UseItem"))
            {
                NpcQuest.Npc.SetActive(false);
                NpcQuest.questnum = 21;
                NpcQuest.use_water = 5;

            }
        }
        else if (NpcQuest.get_water == 1 && NpcQuest.use_water == 5 && NpcQuest.Npc != null && NpcQuest.Npc.name == "Burning6")
        {

            if (Input.GetButtonDown("UseItem"))
            {
                NpcQuest.Npc.SetActive(false);
                NpcQuest.questnum = 22;
                NpcQuest.use_water = 6;
                NpcQuest.get_water = 0;

            }
        }
        else if (NpcQuest.get_water == 1 && NpcQuest.use_water == 5 && NpcQuest.Npc != null && NpcQuest.Npc.name == "Burning6")
        {

            if (Input.GetButtonDown("UseItem"))
            {
                NpcQuest.Npc.SetActive(false);
                NpcQuest.questnum = 22;
                NpcQuest.use_water = 6;
                NpcQuest.get_water = 0;

            }
        }
        else if (NpcQuest.get_platina == 1 && NpcQuest.Npc != null && NpcQuest.Npc.name == "Spot1")
        {

            if (Input.GetButtonDown("UseItem"))
            {

                NpcQuest.Npc.SetActive(false);
                GameObject platina1 = GameObject.Find("Platina").transform.Find("Platina1").gameObject;
                platina1.SetActive(true);
                NpcQuest.use_platina++;

                if(NpcQuest.use_platina == 3)
                {
                    NpcQuest.get_platina = 0;
                    NpcQuest.questnum = 50;
                }
            }
        }
        else if (NpcQuest.get_platina == 1 && NpcQuest.Npc != null && NpcQuest.Npc.name == "Spot2")
        {

            if (Input.GetButtonDown("UseItem"))
            {

                NpcQuest.Npc.SetActive(false);
                GameObject platina2 = GameObject.Find("Platina").transform.Find("Platina2").gameObject;
                platina2.SetActive(true);
                NpcQuest.use_platina++;

                if (NpcQuest.use_platina == 3)
                {
                    NpcQuest.get_platina = 0;
                    NpcQuest.questnum = 50;
                }
            }
        }
        else if (NpcQuest.get_platina == 1 && NpcQuest.Npc != null && NpcQuest.Npc.name == "Spot3")
        {

            if (Input.GetButtonDown("UseItem"))
            {

                NpcQuest.Npc.SetActive(false);
                GameObject platina3 = GameObject.Find("Platina").transform.Find("Platina3").gameObject;
                platina3.SetActive(true);
                NpcQuest.use_platina++;

                if (NpcQuest.use_platina == 3)
                {
                    NpcQuest.get_platina = 0;
                    NpcQuest.questnum = 50;
                }
            }
        }

    }

    void monologue()  //����κ� ������ questnumó���� talk�� �ƴ� ���⼭ ���� ó��.
    {
            
        if (manager.isTalking == true && NpcQuest.Npc == null)
        {
            if (Input.GetButtonDown("Jump"))
            {
                manager.talk_num++;
                manager.Monologue_Action();
            }
        }
        else
        {   // ������ ���� ���� �ٷ� npc���� ��ȭâ�� �ٿ�����Ѻκ�
            if (SceneManager.GetActiveScene().buildIndex == 5 && NpcQuest.questnum == 6)
            {
                NpcQuest.questnum = 7;
                manager.isTalking = true;
                manager.Monologue_Action();
            }

            if (NpcQuest.Npc == null &&  NpcQuest.questnum == 26)
            {
                NpcQuest.questnum = 27;
                manager.isTalking = true;
                manager.Monologue_Action();
            }

            //stage2 �̷ξ�
            if (SceneManager.GetActiveScene().buildIndex == 14 && NpcQuest.questnum == 31)
            {
                NpcQuest.questnum = 32;
                manager.isTalking = true;
                manager.Monologue_Action();
            }

            if (SceneManager.GetActiveScene().buildIndex == 15 && NpcQuest.questnum == 32)
            {
                NpcQuest.questnum = 33;
                manager.isTalking = true;
                manager.Monologue_Action();
            }

            if (SceneManager.GetActiveScene().buildIndex == 18 && NpcQuest.questnum == 36)
            {
                NpcQuest.questnum = 37;
                manager.isTalking = true;
                manager.Monologue_Action();
            }

            if (SceneManager.GetActiveScene().buildIndex == 19 && NpcQuest.questnum == 38)
            {
                NpcQuest.questnum = 39;
                manager.isTalking = true;
                manager.Monologue_Action();
            }

            if (SceneManager.GetActiveScene().buildIndex == 21 && NpcQuest.questnum == 42)
            {
                NpcQuest.questnum = 43;
                manager.isTalking = true;
                manager.Monologue_Action();
            }





        }
    }



    void talk()
    {            
        if (Input.GetButtonDown("Jump") && NpcQuest.Npc != null) //npc���� ��ȭ
        {
            if(manager.isTalking == true)
            {
                manager.talk_num++;
                manager.Action(NpcQuest.Npc);
            }
            else
            {
                //npc1�̶� ��ȭ������ questnum 1, 2����ȭ�Ҷ� questnum2
                if(NpcQuest.Npc.name == "Npc1" && NpcQuest.questnum == 0)
                {
                    NpcQuest.questnum = 1;
                }
                else if(NpcQuest.Npc.name == "Npc2" && NpcQuest.questnum == 1)
                {
                    NpcQuest.questnum = 2;
                }
                else if (NpcQuest.Npc.name == "Npc3" && NpcQuest.questnum == 2)
                {
                    NpcQuest.questnum = 3;
                }
                else if (NpcQuest.Npc.name == "Npc4" && NpcQuest.questnum == 3)
                {
                    NpcQuest.questnum = 4;
                }
                else if (NpcQuest.Npc.name == "Npc3" && NpcQuest.questnum == 4.5f) // ��б����׽�Ʈ���� ������ ���̸� 4.5�� ��ȯ�س���.
                {
                    NpcQuest.questnum = 5;
                }
                else if (NpcQuest.Npc.name == "Npc5" && NpcQuest.questnum == 5) 
                {
                    NpcQuest.questnum = 6;
                }
     
                else if (NpcQuest.Npc.name == "Npc6" && NpcQuest.questnum == 7)
                {
                    NpcQuest.questnum = 8;
                }
                else if (NpcQuest.Npc.name == "Npc7" && NpcQuest.questnum == 8)
                {
                    NpcQuest.questnum = 9;
                }
                else if (NpcQuest.Npc.name == "Npc8" && NpcQuest.questnum == 9)
                {
                    NpcQuest.questnum = 10;
                }
                else if (NpcQuest.Npc.name == "Npc7" && NpcQuest.questnum == 11) // ���������� 10.5f, Ű�̼Ǽ����ϸ� 11f�κ�ȯ. Ű�̼��� ���� use item���� ��ȯ.
                {
                    NpcQuest.questnum = 12;
                }
                else if (NpcQuest.Npc.name == "Npc10" && NpcQuest.questnum == 12) 
                {
                    NpcQuest.questnum = 13;
                }
                else if (NpcQuest.Npc.name == "Npc3" && NpcQuest.questnum == 13.5f) //����������� 13.5�� ����.
                {
                    NpcQuest.questnum = 14;
                }
                else if (NpcQuest.Npc.name == "Npc11" && NpcQuest.questnum == 14)
                {
                    NpcQuest.questnum = 15;
                }
                else if (NpcQuest.Npc.name == "Npc11" && NpcQuest.questnum == 22)
                {
                    NpcQuest.questnum = 23;
                }
                else if (NpcQuest.Npc.name == "Npc13" && NpcQuest.questnum == 23)
                {
                    NpcQuest.questnum = 24;
                }
                else if (NpcQuest.Npc.name == "Npc14" && NpcQuest.questnum == 24)
                {
                    NpcQuest.questnum = 25;
                }
                else if (NpcQuest.Npc.name == "Npc15" && NpcQuest.questnum == 25)
                {
                    NpcQuest.questnum = 26;
                }
                else if (NpcQuest.Npc.name == "Npc16" && NpcQuest.questnum == 27)
                {
                    NpcQuest.questnum = 28;
                }
                else if (NpcQuest.Npc.name == "Npc17" && NpcQuest.questnum == 28)
                {
                    NpcQuest.questnum = 29;
                }
                else if (NpcQuest.Npc.name == "Npc18" && NpcQuest.questnum == 29)
                {
                    NpcQuest.questnum = 30;
                }
                else if (NpcQuest.Npc.name == "Npc20" && NpcQuest.questnum == 30.5)
                {
                    NpcQuest.questnum = 31;
                }
                else if (NpcQuest.Npc.name == "Npc22" && NpcQuest.questnum == 33.5)
                {
                    NpcQuest.questnum = 34;
                }
                else if (NpcQuest.Npc.name == "Npc13" && NpcQuest.questnum == 34)
                {
                    NpcQuest.questnum = 35;
                }
                else if (NpcQuest.Npc.name == "Npc22" && NpcQuest.questnum == 35)
                {
                    NpcQuest.questnum = 36;
                }
                else if (NpcQuest.Npc.name == "Npc23" && NpcQuest.questnum == 37)
                {
                    NpcQuest.questnum = 38;
                }
                else if (NpcQuest.Npc.name == "Npc24" && NpcQuest.questnum == 39)
                {
                    NpcQuest.questnum = 40;
                }
                else if (NpcQuest.Npc.name == "Npc25" && NpcQuest.questnum == 40)
                {
                    NpcQuest.questnum = 41;
                }
                else if (NpcQuest.Npc.name == "Npc26" && NpcQuest.questnum == 41)
                {
                    NpcQuest.questnum = 42;
                }
                //문어게임
                else if (NpcQuest.Npc.name.Contains("Octopus") && NpcQuest.questnum == 43)
                {
                    NpcQuest.questnum = 44;
                    SceneManager.LoadScene(20);
                }
                else if (NpcQuest.Npc.name == "Npc26" && NpcQuest.questnum == 44)
                {
                    NpcQuest.questnum = 45;
                }
                else if (NpcQuest.Npc.name == "Npc27" && NpcQuest.questnum == 45)
                {
                    NpcQuest.questnum = 46;
                }
                else if (NpcQuest.Npc.name == "Npc27" && NpcQuest.questnum == 48)
                {
                    NpcQuest.questnum = 49;
                }






                manager.Action(NpcQuest.Npc);
            }
        }

    }

    void scanNpc()
    {
        Debug.DrawRay(rigid.position, dirVec * 0.7f, new Color(0, 1, 0));
        RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, dirVec, 0.7f, LayerMask.GetMask("NPC"));
        if (rayHit.collider != null)
        {
            NpcQuest.Npc = rayHit.collider.gameObject;
        }
        else
        {
            NpcQuest.Npc = null;
        }
    }

 
}
