using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class DeckBuildManager : MonoBehaviour
{
    /*�@����̓f�b�L�\�z�v�f���I�~�b�g
    [SerializeField, Header("�J�[�h�̃v���n�u")] private CardController m_CardPrefab; //�J�[�h�̌^�ƂȂ�v���n�u�̏��(�v���n�u�t�H���_����C���X�y�N�^�[�Ƀh���b�O)
    [SerializeField, Header("�v���C���[�̃X�g���[�W������ʒu")] private Transform m_StorageTrans; //
    [SerializeField, Header("�v���C���[�̃f�b�L������ʒu")] private Transform m_DeckTrans; //

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
