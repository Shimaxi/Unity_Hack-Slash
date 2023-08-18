using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class DeckBuildManager : MonoBehaviour
{
    /*　今回はデッキ構築要素をオミット
    [SerializeField, Header("カードのプレハブ")] private CardController m_CardPrefab; //カードの型となるプレハブの情報(プレハブフォルダからインスペクターにドラッグ)
    [SerializeField, Header("プレイヤーのストレージがある位置")] private Transform m_StorageTrans; //
    [SerializeField, Header("プレイヤーのデッキがある位置")] private Transform m_DeckTrans; //

    public GameObject m_Panels;

    // Start is called before the first frame update
    void Start()
    {


    }

    public void PushBackToMainButton()
    {
        m_Panels.transform.localPosition = new Vector3(0, 0, -10);
    }

    public void PushDeckButton()
    {
        for (int i = 0; i < Database.s_AllCardList.Count; i++)
        {
            CardController m_Card = Instantiate(m_CardPrefab, m_StorageTrans, false);
            m_Card.Init(Database.s_AllCardList[i]);
        }
        for (int i = 0; i < Database.s_DeckList[0].Count; i++)
        {
            CardController m_Card = Instantiate(m_CardPrefab, m_DeckTrans, false);
            m_Card.Init(Database.s_DeckList[0][i]);
        }
    }

    // Update is called once per frame
    public void AddDeck()
    {
        foreach (Transform child in m_DeckTrans)
        {
            CardController m_TargetCard = child.GetComponent<CardController>();
            //m_PlayerATKSum += m_TargetCard.m_CardModel.m_CardATK;

        }
    }
    */
}
