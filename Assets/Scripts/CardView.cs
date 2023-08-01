using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//�J�[�h�̌�����
public class CardView : MonoBehaviour
{
    [SerializeField] Text m_CardNameText;
    [SerializeField] Text m_CardCostText;
    [SerializeField] Text m_CardText;
    [SerializeField] Image m_CardImage;
    [SerializeField] Text m_CardATKText;
    [SerializeField] Text m_CardMATText;

    //card�̌����ڂ�ύX����
    public void Show(CardModel cardModel)
    {
        //���ꂼ��Prefab�̒��̗v�f���C���X�y�N�^�[�Ƀh���b�O���h���b�v
        m_CardNameText.text = cardModel.m_CardName; 
        m_CardCostText.text = cardModel.m_CardCost.ToString();
        m_CardText.text = cardModel.m_CardText;
        m_CardImage.sprite = cardModel.m_CardImage;
        m_CardATKText.text = cardModel.m_CardATK.ToString();
        m_CardMATText.text = cardModel.m_CardMAT.ToString();
    }
}
