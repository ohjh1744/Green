using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Questtext : MonoBehaviour
{
    public Text quest_title;
    public Text quest_text;

    public GameObject gameManager;
    public bool check; //대화끝나고 퀘스트내용 띄우기위함.

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
        quest1[0] = "소녀의 부탁 들어주기";
        quest1[1] = "맵 중앙 호수의 왼쪽길을 따라 노란 집에 찾아가기.";

        quest2[0] = "의문의 초대";
        quest2[1] = "노란 집 안으로 들어가기.";

        quest3[0] = "전투 테스트 받기";
        quest3[1] = "오른쪽의 훈련교관에게 찾아가기.";

        quest4[0] = "훈련교관의 테스트";
        quest4[1] = "훈련교관을 무찌르기.";

        quest4_5[0] = "비밀기지대장에게 돌아가기";
        quest4_5[1] = "비밀기지대장 지나에게 말을 걸어보자.";

        quest5[0] = "위장임무";
        quest5[1] = "지나가 준 배찌를 착용하고 주차장쪽으로 찾아가기.";

        quest6[0] = "가이아에 잠입하기";
        quest6[1] = "가이아로 가는길에는 삼엄하고 위험한 함정이 있으니 조심해서 길을 찾아 가보자.";

        quest7[0] = "쓰러진 할아버지 구해주기";
        quest7[1] = "앞에 쓰러진 할아버지를 공격하는 경비원을 막자.";

        quest8[0] = "할아버지 부축하기";
        quest8[1] = "할아버지를 도와드리고 말을 걸어보자.";

        quest9[0] = "할아버지의 부탁";
        quest9[1] = "먼저위에 경비들이 있는 사무실로 가보자.";

        quest10[0] = "경비원들 물리치고 열쇠얻기";
        quest10[1] = "사무실 내부로 들어가 경비원을 물리치고 열쇠를 획득하자.";

        quest10_5[0] = "공장 작동 멈추기";
        quest10_5[1] = "얻은 열쇠로 공장의 트레일러를 멈춰보자. 열쇠 꽂는데에 가까이가서 E키를 누르면 열쇠를 꽂을 수 있다.";

        quest11[0] = "할아버지께 돌아가기";
        quest11[1] = "할아버지께 성공했다는 소식을 들려주러 가자.";

        quest12[0] = "아레아로 돌아가기";
        quest12[1] = "할아버지 말씀대로 일단 아레아로 돌아가자.";

        quest13[0] = "보스와의 전투";
        quest13[1] = "레이보어에 맞서 싸워 이기자.";

        quest13_5[0] = "지나에게 돌아가자.";
        quest13_5[1] = "비밀기지에 돌아가서 지나에게 지금까지 있었던 일을 알려주자.";

        quest14[0] = "근처 마을로 이동하자.";
        quest14[1] = "지나 말대로 스테이지2로 가보자. 중앙호수 오른쪽 길을 따라 나가면 된다.";

        quest15[0] = "우물에서 물을 가지고 오자.";
        quest15[1] = "오른쪽 마을에 들어가면 우물이 있다. 바구니에 E키를 사용해 물을 떠오자.";

        quest16[0] = "불끄기.";
        quest16[1] = "나무에 붙은 불을 E키를 사용해 끄자.";

        quest23[0] = "마을에 가서 이장님을 만나보자.";
        quest23[1] = "옆 마을로 돌아가 양동이를 돌려드리고 이장님과 대화를 나눠보자.";

        quest24[0] = "우물 앞 시장으로 가자.";
        quest24[1] = "시장으로 가서 손선풍기도 사면서 가게주인과 대화를 나눠보자.";

        quest25[0] = "마을 사람과의 대화.";
        quest25[1] = "마을 이웃 사람과 대화를 나눠보자. 시장 오른쪽 윗길에 아주머니에게 대화를 걸어보자.";

        quest26[0] = "이 마을의 의심";
        quest26[1] = "확실히 마을에 이상한 점이 있는 것 같다.";

        quest27[0] = "끊긴 신호를 따라서";
        quest27[1] = "이장님이 알려주신 길을 따라 올라가자. 이장이 있는 곳의 위에 길을 따라가면 된다.";

        quest28[0] = "종이에 적힌 장소로 가보자";
        quest28[1] = "마을로 돌아가 북동방향의 길로 가보자.";

        quest29[0] = "자객을 쫓아가자";
        quest29[1] = "자객을 쫓아가보자. ";

        quest30[0] = "자객을 물리치자";
        quest30[1] = "지나 동료의 복수를 하자. ";

        quest30_5[0] = "자객에게 정보를 알아내자";
        quest30_5[1] = "실험 위치를 알아내자. ";

        quest31[0] = "실험 위치를 찾아가자";
        quest31[1] = "자객의 말대로 마을로 돌아가 오른쪽 길로 향해보자.";

        quest32[0] = "잠입";
        quest32[1] = "경비 근처에 가까이 다가가면 잡히게 되니 조심하자. ";

        quest33[0] = "카이만과의 전투";
        quest33[1] = "카이만을 무찌르자. ";

        quest33_5[0] = "카이만과의 대화";
        quest33_5[1] = "카이만에게 실험의 진실을 알아내자.";

        quest34[0] = "진실을 알리자";
        quest34[1] = "마을 이장님께 가서 실험기록을 보여드리고 진실을 알려주자.";

        quest35[0] = "오션 시티로";
        quest35[1] = "마을 아래쪽에 오션 시티로 향하는 길이 있다고 한다. 그 길을 따라가 길잡이에게 가보자.";

        quest36[0] = "고래 입속으로";
        quest36[1] = "고래 입으로 들어가자.";

        quest37[0] = "문어에 대해 조사하기(1)";
        quest37[1] = "어인들에게 문어에 대해서 물어보자.";

        //questnum 38은 monologue로 생략. 딱히 안해도될듯.
        quest39[0] = "문어에 대해 조사하기(2)";
        quest39[1] = "어인들에게 문어에 대해서 물어보자.";

        quest40[0] = "문어에 대해 조사하기(3)";
        quest40[1] = "거북 할아버지께 가보자. 마을 중앙 9시 방향으로 가면 된다.";

        quest41[0] = "문어 집으로";
        quest41[1] = "마을 중앙 7시방향 집에 문어가 산다고 한다. 그 집으로 가보자.";

        quest43[0] = "숨은 문어 찾기";
        quest43[1] = "집을 돌아다니며 사물로 변장한 문어를 찾아보자. Spacebar를 통해 찾을 수 있다. 힌트: 가까이가면 내 모습이 보일 것이다.";

        quest45[0] = "문어 보스한테 가보자.";
        quest45[1] = "마을 12시 방향 건물에 있다고한다. 거기로 가보자.";

        quest46[0] = "유정탑 처리하기(1). ";
        quest46[1] = "마을 중앙 1시 방향으로 가보자. \n 가서 버려진 유정탑을 조각내서 기계로 가져가자.\n" +
            "다가가서 마우스 클릭을 통해 유정탑을 조각낼 수 있다.\n 순서가 정해져 있으니 잘 생각해서 조각내자. \n" +
            "힌트: 바닥";
        
        quest47[0] = "유정탑 처리하기(2). ";
        quest47[1] = "열린 오른쪽 포탈로 이동하여 유정탑 조각을 마우스클릭을 통해 기계를 작동하고 처리하자.\n 조각이 처리 될 수 있도록 동선을 막고있는 상자를 치워야 한다.";

        quest48[0] = "꽃게거상에게 돌아가자.";
        quest48[1] = "버려진 유정탑도 처리했으니 돌아가서 원하는 정보을 얻자.";

        quest49[0] = "플레티나 설치";
        quest49[1] = "마을 중앙 5시 방향으로 가보자. \n" + "오염된 지역으로 가서 플레니타를 설치하자. E키로 설치가 가능하다.";

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
