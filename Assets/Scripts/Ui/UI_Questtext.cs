using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Questtext : MonoBehaviour
{
    public Text quest_title;
    public Text quest_text;

    public GameObject gameManager;
    public bool check; //��ȭ������ ����Ʈ���� ��������.

    string[] quest1= new string[2];
    string[] quest2 = new string[2];
    string[] quest3 = new string[2];
    string[] quest4 = new string[2];
    string[] quest4_5 = new string[2];
    string[] quest5 = new string[2];
    string[] quest6 = new string[2];
    string[] quest7 = new string[2];
    string[] quest8 = new string[2];
    string[] quest9 = new string[2];
    string[] quest10 = new string[2];
    string[] quest10_5 = new string[2];
    string[] quest11 = new string[2];
    string[] quest12 = new string[2];
    string[] quest13 = new string[2];
    string[] quest13_5 = new string[2];
    string[] quest14 = new string[2];
    string[] quest15 = new string[2];
    string[] quest16 = new string[2];
    string[] quest23 = new string[2];
    string[] quest24 = new string[2];
    string[] quest25 = new string[2];
    string[] quest26 = new string[2];
    string[] quest27 = new string[2];
    string[] quest28 = new string[2];
    string[] quest29 = new string[2];
    string[] quest30 = new string[2];
    string[] quest30_5 = new string[2];
    string[] quest31 = new string[2];
    string[] quest32 = new string[2];
    string[] quest33 = new string[2];
    string[] quest33_5 = new string[2];
    string[] quest34 = new string[2];
    string[] quest35 = new string[2];
    string[] quest36 = new string[2];
    string[] quest37 = new string[2];
    string[] quest39 = new string[2];
    string[] quest40 = new string[2];
    string[] quest41 = new string[2];
    string[] quest43 = new string[2];
    string[] quest45 = new string[2];
    string[] quest46 = new string[2];
    string[] quest47 = new string[2];
    string[] quest48 = new string[2];
    string[] quest49 = new string[2];

    void Start()
    {
        gameManager = GameObject.Find("GameManager").gameObject;
        quest1[0] = "�ҳ��� ��Ź ����ֱ�";
        quest1[1] = "�� �߾� ȣ���� ���ʱ��� ���� ��� ���� ã�ư���.";

        quest2[0] = "�ǹ��� �ʴ�";
        quest2[1] = "��� �� ������ ����.";

        quest3[0] = "���� �׽�Ʈ �ޱ�";
        quest3[1] = "�������� �Ʒñ������� ã�ư���.";

        quest4[0] = "�Ʒñ����� �׽�Ʈ";
        quest4[1] = "�Ʒñ����� �����.";

        quest4_5[0] = "��б������忡�� ���ư���";
        quest4_5[1] = "��б������� �������� ���� �ɾ��.";

        quest5[0] = "�����ӹ�";
        quest5[1] = "������ �� ��� �����ϰ� ������������ ã�ư���.";

        quest6[0] = "���̾ƿ� �����ϱ�";
        quest6[1] = "���̾Ʒ� ���±濡�� ����ϰ� ������ ������ ������ �����ؼ� ���� ã�� ������.";

        quest7[0] = "������ �Ҿƹ��� �����ֱ�";
        quest7[1] = "�տ� ������ �Ҿƹ����� �����ϴ� ������ ����.";

        quest8[0] = "�Ҿƹ��� �����ϱ�";
        quest8[1] = "�Ҿƹ����� ���͵帮�� ���� �ɾ��.";

        quest9[0] = "�Ҿƹ����� ��Ź";
        quest9[1] = "�������� ������ �ִ� �繫�Ƿ� ������.";

        quest10[0] = "������ ����ġ�� ������";
        quest10[1] = "�繫�� ���η� �� ������ ����ġ�� ���踦 ȹ������.";

        quest10_5[0] = "���� �۵� ���߱�";
        quest10_5[1] = "���� ����� ������ Ʈ���Ϸ��� ���纸��. ���� �ȴµ��� �����̰��� EŰ�� ������ ���踦 ���� �� �ִ�.";

        quest11[0] = "�Ҿƹ����� ���ư���";
        quest11[1] = "�Ҿƹ����� �����ߴٴ� �ҽ��� ����ַ� ����.";

        quest12[0] = "�Ʒ��Ʒ� ���ư���";
        quest12[1] = "�Ҿƹ��� ������� �ϴ� �Ʒ��Ʒ� ���ư���.";

        quest13[0] = "�������� ����";
        quest13[1] = "���̺�� �¼� �ο� �̱���.";

        quest13_5[0] = "�������� ���ư���.";
        quest13_5[1] = "��б����� ���ư��� �������� ���ݱ��� �־��� ���� �˷�����.";

        quest14[0] = "��ó ������ �̵�����.";
        quest14[1] = "���� ����� ��������2�� ������. �߾�ȣ�� ������ ���� ���� ������ �ȴ�.";

        quest15[0] = "�칰���� ���� ������ ����.";
        quest15[1] = "������ ������ ���� �칰�� �ִ�. �ٱ��Ͽ� EŰ�� ����� ���� ������.";

        quest16[0] = "�Ҳ���.";
        quest16[1] = "������ ���� ���� EŰ�� ����� ����.";

        quest23[0] = "������ ���� ������� ��������.";
        quest23[1] = "�� ������ ���ư� �絿�̸� �����帮�� ����԰� ��ȭ�� ��������.";

        quest24[0] = "�칰 �� �������� ����.";
        quest24[1] = "�������� ���� �ռ�ǳ�⵵ ��鼭 �������ΰ� ��ȭ�� ��������.";

        quest25[0] = "���� ������� ��ȭ.";
        quest25[1] = "���� �̿� ����� ��ȭ�� ��������. ���� ������ ���濡 ���ָӴϿ��� ��ȭ�� �ɾ��.";

        quest26[0] = "�� ������ �ǽ�";
        quest26[1] = "Ȯ���� ������ �̻��� ���� �ִ� �� ����.";

        quest27[0] = "���� ��ȣ�� ����";
        quest27[1] = "������� �˷��ֽ� ���� ���� �ö���. ������ �ִ� ���� ���� ���� ���󰡸� �ȴ�.";

        quest28[0] = "���̿� ���� ��ҷ� ������";
        quest28[1] = "������ ���ư� �ϵ������� ��� ������.";

        quest29[0] = "�ڰ��� �Ѿư���";
        quest29[1] = "�ڰ��� �Ѿư�����. ";

        quest30[0] = "�ڰ��� ����ġ��";
        quest30[1] = "���� ������ ������ ����. ";

        quest30_5[0] = "�ڰ����� ������ �˾Ƴ���";
        quest30_5[1] = "���� ��ġ�� �˾Ƴ���. ";

        quest31[0] = "���� ��ġ�� ã�ư���";
        quest31[1] = "�ڰ��� ����� ������ ���ư� ������ ��� ���غ���.";

        quest32[0] = "����";
        quest32[1] = "��� ��ó�� ������ �ٰ����� ������ �Ǵ� ��������. ";

        quest33[0] = "ī�̸����� ����";
        quest33[1] = "ī�̸��� �����. ";

        quest33_5[0] = "ī�̸����� ��ȭ";
        quest33_5[1] = "ī�̸����� ������ ������ �˾Ƴ���.";

        quest34[0] = "������ �˸���";
        quest34[1] = "���� ����Բ� ���� �������� �����帮�� ������ �˷�����.";

        quest35[0] = "���� ��Ƽ��";
        quest35[1] = "���� �Ʒ��ʿ� ���� ��Ƽ�� ���ϴ� ���� �ִٰ� �Ѵ�. �� ���� ���� �����̿��� ������.";

        quest36[0] = "�� �Լ�����";
        quest36[1] = "�� ������ ����.";

        quest37[0] = "��� ���� �����ϱ�(1)";
        quest37[1] = "���ε鿡�� ��� ���ؼ� �����.";

        //questnum 38�� monologue�� ����. ���� ���ص��ɵ�.
        quest39[0] = "��� ���� �����ϱ�(2)";
        quest39[1] = "���ε鿡�� ��� ���ؼ� �����.";

        quest40[0] = "��� ���� �����ϱ�(3)";
        quest40[1] = "�ź� �Ҿƹ����� ������. ���� �߾� 9�� �������� ���� �ȴ�.";

        quest41[0] = "���� ������";
        quest41[1] = "���� �߾� 7�ù��� ���� ��� ��ٰ� �Ѵ�. �� ������ ������.";

        quest43[0] = "���� ���� ã��";
        quest43[1] = "���� ���ƴٴϸ� �繰�� ������ ��� ã�ƺ���. Spacebar�� ���� ã�� �� �ִ�. ��Ʈ: �����̰��� �� ����� ���� ���̴�.";

        quest45[0] = "���� �������� ������.";
        quest45[1] = "���� 12�� ���� �ǹ��� �ִٰ��Ѵ�. �ű�� ������.";

        quest46[0] = "����ž ó���ϱ�(1). ";
        quest46[1] = "���� �߾� 1�� �������� ������. \n ���� ������ ����ž�� �������� ���� ��������.\n" +
            "�ٰ����� ���콺 Ŭ���� ���� ����ž�� ������ �� �ִ�.\n ������ ������ ������ �� �����ؼ� ��������. \n" +
            "��Ʈ: �ٴ�";
        
        quest47[0] = "����ž ó���ϱ�(2). ";
        quest47[1] = "���� ������ ��Ż�� �̵��Ͽ� ����ž ������ ���콺Ŭ���� ���� ��踦 �۵��ϰ� ó������.\n ������ ó�� �� �� �ֵ��� ������ �����ִ� ���ڸ� ġ���� �Ѵ�.";

        quest48[0] = "�ɰ԰Ż󿡰� ���ư���.";
        quest48[1] = "������ ����ž�� ó�������� ���ư��� ���ϴ� ������ ����.";

        quest49[0] = "�÷�Ƽ�� ��ġ";
        quest49[1] = "���� �߾� 5�� �������� ������. \n" + "������ �������� ���� �÷���Ÿ�� ��ġ����. EŰ�� ��ġ�� �����ϴ�.";

    }

    // Update is called once per frame
    void Update()
    {
        check = gameManager.GetComponent<GameManager>().isTalking;
        if (!check)
        {
            Show_quest();
        }
    }

    void Show_quest()
    {
        if(NpcQuest.questnum == 1)
        {
            quest_title.text = quest1[0];
            quest_text.text = quest1[1];
        }
        else if (NpcQuest.questnum == 2)
        {
            quest_title.text = quest2[0];
            quest_text.text = quest2[1];
        }
        else if (NpcQuest.questnum == 3)
        {
            quest_title.text = quest3[0];
            quest_text.text = quest3[1];
        }
        else if (NpcQuest.questnum == 4)
        {
            quest_title.text = quest4[0];
            quest_text.text = quest4[1];
        }
        else if (NpcQuest.questnum == 4.5f)
        {
            quest_title.text = quest4_5[0];
            quest_text.text = quest4_5[1];
        }
        else if (NpcQuest.questnum == 5)
        {
            quest_title.text = quest5[0];
            quest_text.text = quest5[1];
        }
        else if ( NpcQuest.questnum == 6 && NpcQuest.clear_badge_mission == 1)
        {
            quest_title.text = quest6[0];
            quest_text.text = quest6[1];
        }
        else if (NpcQuest.questnum == 7)
        {
            quest_title.text = quest7[0];
            quest_text.text = quest7[1];
        }
        else if (NpcQuest.questnum == 8)
        {
            quest_title.text = quest8[0];
            quest_text.text = quest8[1];
        }
        else if(NpcQuest.questnum == 9)
        {
            quest_title.text = quest9[0];
            quest_text.text = quest9[1];
        }
        else if (NpcQuest.questnum == 10)
        {
            quest_title.text = quest10[0];
            quest_text.text = quest10[1];
        }
        else if(NpcQuest.questnum == 10.5f)
        {
            quest_title.text = quest10_5[0];
            quest_text.text = quest10_5[1];
        }
        else if (NpcQuest.questnum == 11f)
        {
            quest_title.text = quest11[0];
            quest_text.text = quest11[1];
        }
        else if (NpcQuest.questnum == 12f)
        {
            quest_title.text = quest12[0];
            quest_text.text = quest12[1];
        }
        else if (NpcQuest.questnum == 13f)
        {
            quest_title.text = quest13[0];
            quest_text.text = quest13[1];
        }
        else if (NpcQuest.questnum == 13.5f)
        {
            quest_title.text = quest13_5[0];
            quest_text.text = quest13_5[1];
        }
        else if (NpcQuest.questnum == 14f)
        {
            quest_title.text = quest14[0];
            quest_text.text = quest14[1];
        }
        else if (NpcQuest.questnum == 15f)
        {
            quest_title.text = quest15[0];
            quest_text.text = quest15[1];
        }
        else if (NpcQuest.questnum == 16f)
        {
            quest_title.text = quest16[0];
            quest_text.text = quest16[1];
        }
        else if (NpcQuest.questnum == 23f)
        {
            quest_title.text = quest23[0];
            quest_text.text = quest23[1];
        }
        else if (NpcQuest.questnum == 24f)
        {
            quest_title.text = quest24[0];
            quest_text.text = quest24[1];
        }
        else if (NpcQuest.questnum == 25f)
        {
            quest_title.text = quest25[0];
            quest_text.text = quest25[1];
        }
        else if (NpcQuest.questnum == 26f)
        {
            quest_title.text = quest26[0];
            quest_text.text = quest26[1];
        }
        else if (NpcQuest.questnum == 27f)
        {
            quest_title.text = quest27[0];
            quest_text.text = quest27[1];
        }
        else if (NpcQuest.questnum == 28f)
        {
            quest_title.text = quest28[0];
            quest_text.text = quest28[1];
        }
        else if (NpcQuest.questnum == 29f)
        {
            quest_title.text = quest29[0];
            quest_text.text = quest29[1];
        }
        else if (NpcQuest.questnum == 30f)
        {
            quest_title.text = quest30[0];
            quest_text.text = quest30[1];
        }
        else if (NpcQuest.questnum == 30.5f)
        {
            quest_title.text = quest30_5[0];
            quest_text.text = quest30_5[1];
        }

        else if (NpcQuest.questnum == 31f)
        {
            quest_title.text = quest31[0];
            quest_text.text = quest31[1];
        }

        else if (NpcQuest.questnum == 32f)
        {
            quest_title.text = quest32[0];
            quest_text.text = quest32[1];
        }

        else if (NpcQuest.questnum == 33f)
        {
            quest_title.text = quest33[0];
            quest_text.text = quest33[1];
        }
        else if (NpcQuest.questnum == 33.5f)
        {
            quest_title.text = quest33_5[0];
            quest_text.text = quest33_5[1];
        }
        else if (NpcQuest.questnum == 34f)
        {
            quest_title.text = quest34[0];
            quest_text.text = quest34[1];
        }

        else if (NpcQuest.questnum == 35f)
        {
            quest_title.text = quest35[0];
            quest_text.text = quest35[1];
        }

        else if (NpcQuest.questnum == 36f)
        {
            quest_title.text = quest36[0];
            quest_text.text = quest36[1];
        }

        else if (NpcQuest.questnum == 37f)
        {
            quest_title.text = quest37[0];
            quest_text.text = quest37[1];
        }

        else if (NpcQuest.questnum == 39f)
        {
            quest_title.text = quest39[0];
            quest_text.text = quest39[1];
        }

        else if (NpcQuest.questnum == 40f)
        {
            quest_title.text = quest40[0];
            quest_text.text = quest40[1];
        }

        else if (NpcQuest.questnum == 41f)
        {
            quest_title.text = quest41[0];
            quest_text.text = quest41[1];
        }

        else if (NpcQuest.questnum == 43f)
        {
            quest_title.text = quest43[0];
            quest_text.text = quest43[1];
        }

        else if (NpcQuest.questnum == 45f)
        {
            quest_title.text = quest45[0];
            quest_text.text = quest45[1];
        }

        else if (NpcQuest.questnum == 46f)
        {
            quest_title.text = quest46[0];
            quest_text.text = quest46[1];
        }

        else if (NpcQuest.questnum == 47f)
        {
            quest_title.text = quest47[0];
            quest_text.text = quest47[1];
        }

        else if (NpcQuest.questnum == 48f)
        {
            quest_title.text = quest48[0];
            quest_text.text = quest48[1];
        }

        else if (NpcQuest.questnum == 49f)
        {
            quest_title.text = quest49[0];
            quest_text.text = quest49[1];
        }

    }
}
