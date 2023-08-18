using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PreparationManager : MonoBehaviour
{
    public GameObject m_StageInfo;
    //public GameObject m_Storage;


    [SerializeField, Header("�J�[�h�̃v���n�u")] private CardController m_CardPrefab; //�J�[�h�̌^�ƂȂ�v���n�u�̏��(�v���n�u�t�H���_����C���X�y�N�^�[�Ƀh���b�O)
    [SerializeField, Header("�v���C���[�̃f�b�L������ʒu")] private Transform m_DeckTrans; //

    public bool m_DeckEditting = false;
    public Text m_EditButtonName;
    public void Start()
    {
        m_StageInfo.SetActive(false);
        //m_Storage.SetActive(false);

        for (int i = 0; i < Database.s_DeckList[0].Count; i++)
        {
            CardController m_Card = Instantiate(m_CardPrefab, m_DeckTrans, false);
            m_Card.Init(Database.s_DeckList[0][i]);
        }

    }



    public void DeckCount()
    {
        Database.s_DeckList[0].Clear();
        foreach (Transform child in m_DeckTrans)
        {
            CardController m_TargetCard = child.GetComponent<CardController>();
            Database.s_DeckList[0].Add(m_TargetCard.m_CardModel.m_CardID);
        }
    }

    public void PushEntryButton()
    {
        if (Database.s_DeckList[0].Count < 3)
        {
            Debug.Log("3���ȏ�̃J�[�h�����Ă�������");
        } else
        {
            SceneManager.LoadScene("Battle");
        }
    }

    public void PushBackButton()
    {
        m_StageInfo.SetActive(false);

    }

    public void PushDeck1Button()
    {
        m_StageInfo.SetActive(false);

    }

    public void PushDeck2Button()
    {
        m_StageInfo.SetActive(false);

    }

    public void PushDeck3Button()
    {
        m_StageInfo.SetActive(false);

    }

    /* �f�b�L�\�z�Ɋւ��镔���͍���I�~�b�g
    public void PushEditButton()
    {
        if (m_DeckEditting == false)
        {
            m_DeckEditting = true;
            m_Storage.SetActive(true);
            m_EditButtonName.text = "����";

        } else if (m_DeckEditting == true)
        {
            m_DeckEditting = false;
            m_Storage.SetActive(false);
            m_EditButtonName.text = "�ҏW";
        }
    }
    
    public void PushRightButton()
    {
        m_Storage.transform.localPosition += new Vector3(200, 0, 0);
    }

    public void PushLeftButton()
    {
        m_Storage.transform.localPosition -= new Vector3(200, 0, 0);
    }
    */
}
