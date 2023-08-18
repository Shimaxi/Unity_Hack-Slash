using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventManager : MonoBehaviour
{
    [SerializeField] private Text m_EventTitle;
    [SerializeField] private Image m_EventImage;
    [SerializeField] private Text m_EventText;
    [SerializeField] private GameObject m_Event;
    [SerializeField] private GameObject m_EventOptionArea;
    [SerializeField] private Text m_EventOption1;
    [SerializeField] private Text m_EventOption2;
    [SerializeField] private GameObject m_EventRewardArea;

    [SerializeField] private CardController m_CardPrefab; //カードの型となるプレハブの情報(プレハブフォルダからインスペクターにドラッグ)

    // Start is called before the first frame update
    void Start()
    {
        EventStart();
    }

    public void OnclickOption1()
    {
        EventResult1();
    }

    public void OnclickOption2()
    {
        EventResult2();
    }

    void EventStart()
    {
        m_Event.SetActive(true);
        m_EventOptionArea.SetActive(true);
        m_EventRewardArea.SetActive(false);
        m_EventTitle.text = "怪しい老人";
        m_EventText.text = "怪しい老人が現れた";
        m_EventOption1.text = "殴る";
        m_EventOption2.text = "話を聞く";
    }
    
    void EventResult1()
    {
        m_Event.SetActive(true);
        m_EventOptionArea.SetActive(false);
        m_EventRewardArea.SetActive(true);
        m_EventText.text = "老人は驚いてカードを落とした\n報酬を選ぶ";
        for(int i = 0; i < 3; i++)
        {
            //CardController m_Card = Instantiate(m_CardPrefab, m_EventRewardArea.transform, false);
            //m_Card.Init(1);

        }
        
    }

    void EventResult2()
    {
        m_Event.SetActive(true);
        m_EventOptionArea.SetActive(false);
        m_EventRewardArea.SetActive(true);
        m_EventText.text = "老人は良い人で宝をくれるようだ";
    }

}
