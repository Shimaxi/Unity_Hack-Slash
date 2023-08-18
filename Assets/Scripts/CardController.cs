using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CardController : MonoBehaviour
{
    //�ϐ��錾
    public CardModel m_CardModel; //CardModel�^�ŏ����ꂽ�J�[�h�̏��
    public CardView m_CardView; //CardView�^�ŏ����ꂽ�J�[�h�̌�����


    public void Awake()
    {
        //�I�u�W�F�N�g���������ꂽ��A�܂��������͉��̃V�[�����c������
        if (SceneManager.GetActiveScene().name == "Battle")
        {
            this.GetComponent<CardMovement>().enabled = true;
            this.GetComponent<CardMovement_Main>().enabled = false;
        } 
        /*else if (SceneManager.GetActiveScene().name == "Main")
        {
            this.GetComponent<CardMovement>().enabled = false;
            this.GetComponent<CardMovement_Main>().enabled = true;
        }
        */

    }

    public void Init(int cardID)
    {
        m_CardModel = new CardModel(cardID); //CardModel�^�̏���ϐ�m_CardModel�ɓ����
        m_CardView.Show(m_CardModel); //�J�[�h�̌����ڂ����m_CardModel�̏������ɕ\������
    }
}
