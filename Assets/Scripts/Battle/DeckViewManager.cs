using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeckViewManager : MonoBehaviour
{
    
    //�J�[�h�r���[���[�֘A
    public CardController m_CardPrefab;
    public List<int> m_DeckCardList = new List<int>();
    public List<int> m_CemeteryCardList = new List<int>();

    public Transform m_DeckViewrTransform; //�R�D�m�F

    public GameObject m_CardsViwer;
    public GameObject m_DeckViwer;
    public GameObject m_CemeteryViwer;

    public void Start()
    {
        m_CardsViwer.SetActive(false);
    }


    //�f�b�L���{������֐�
    public void DeckView(Transform viewr)
    {
        Debug.Log(GameManager.s_DeckCheck);
        m_CemeteryViwer.SetActive(false);//��n�̃r���[���[��ʂ�����
        m_DeckViwer.SetActive(true);//�f�b�L�̃r���[���[��ʋN��
        m_CardsViwer.SetActive(true);//�r���[���[��ʑS�̂��N��
        if (GameManager.s_DeckCheck == false)
        {
            m_DeckCardList = GameManager.s_DeckCardList;
            m_DeckCardList.Sort();//�\�[�g����cardID���ɕ��ׂ�
            int i = 0;
            while (i < m_DeckCardList.Count)
            {
                CardController m_Card = Instantiate(m_CardPrefab, viewr, false);
                m_Card.Init(m_DeckCardList[i]);
                m_Card.GetComponent<CardMovement>().enabled = false;
                i++;
            }

            GameManager.s_DeckCheck = true; //�^�[���G���h����false�ɖ߂����ƁI�I�I�I����Ăяo���̂ƕ��ׂ�������̂�
        }
    }

    //��n���{������֐��E��̃f�b�L�Ɠ���
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

            GameManager.s_CemeteryCheck = true; //�^�[���G���h����false�ɖ߂����ƁI�I�I�I����Ăяo���̂ƕ��ׂ�������̂�
        }


    }

    //�r���[���[��ʂ����{�^��
    public void CloseViewer()
    {
        m_CardsViwer.SetActive(false);
    }
}
