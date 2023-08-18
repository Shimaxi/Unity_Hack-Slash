using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeckViewManager : MonoBehaviour
{
    
    //カードビューワー関連
    public CardController m_CardPrefab;
    public List<int> m_DeckCardList = new List<int>();
    public List<int> m_CemeteryCardList = new List<int>();

    public Transform m_DeckViewrTransform; //山札確認

    public GameObject m_CardsViwer;
    public GameObject m_DeckViwer;
    public GameObject m_CemeteryViwer;

    public void Start()
    {
        m_CardsViwer.SetActive(false);
    }


    //デッキを閲覧する関数
    public void DeckView(Transform viewr)
    {
        Debug.Log(GameManager.s_DeckCheck);
        m_CemeteryViwer.SetActive(false);//墓地のビューワー画面を消す
        m_DeckViwer.SetActive(true);//デッキのビューワー画面起動
        m_CardsViwer.SetActive(true);//ビューワー画面全体を起動
        if (GameManager.s_DeckCheck == false)
        {
            m_DeckCardList = GameManager.s_DeckCardList;
            m_DeckCardList.Sort();//ソートしてcardID順に並べる
            int i = 0;
            while (i < m_DeckCardList.Count)
            {
                CardController m_Card = Instantiate(m_CardPrefab, viewr, false);
                m_Card.Init(m_DeckCardList[i]);
                m_Card.GetComponent<CardMovement>().enabled = false;
                i++;
            }

            GameManager.s_DeckCheck = true; //ターンエンド時にfalseに戻すこと！！！！毎回呼び出すのと負荷がかかるので
        }
    }

    //墓地を閲覧する関数・大体デッキと同じ
    public void CemeteryView(Transform viewr)
    {
        m_DeckViwer.SetActive(false);
        m_CemeteryViwer.SetActive(true);
        m_CardsViwer.SetActive(true);
        if (GameManager.s_CemeteryCheck == false)
        {
            m_CemeteryCardList = new List<int>(GameManager.s_CemeteryCardList);
            m_CemeteryCardList.Sort();
            int i = 0;
            while (i < m_CemeteryCardList.Count)
            {
                CardController m_Card = Instantiate(m_CardPrefab, viewr, false);
                m_Card.Init(m_CemeteryCardList[i]);
                m_Card.GetComponent<CardMovement>().enabled = false;
                i++;
            }

            GameManager.s_CemeteryCheck = true; //ターンエンド時にfalseに戻すこと！！！！毎回呼び出すのと負荷がかかるので
        }


    }

    //ビューワー画面を閉じるボタン
    public void CloseViewer()
    {
        m_CardsViwer.SetActive(false);
    }
}
