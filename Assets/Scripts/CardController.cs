using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardController : MonoBehaviour
{
    //�ϐ��錾
    public CardModel m_CardModel; //CardModel�^�ŏ����ꂽ�J�[�h�̏��
    public CardView m_CardView; //CardView�^�ŏ����ꂽ�J�[�h�̌�����

    public void Init(int cardID)
    {
        m_CardModel = new CardModel(cardID); //CardModel�^�̏���ϐ�m_CardModel�ɓ����
        m_CardView.Show(m_CardModel); //�J�[�h�̌����ڂ����m_CardModel�̏������ɕ\������
    }
}
