using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//カードの見た目
public class CardView : MonoBehaviour
{
    [SerializeField] Text m_CardNameText;
    [SerializeField] Text m_CardCostText;
    [SerializeField] Text m_CardText;
    [SerializeField] Image m_CardImage;
    [SerializeField] Text m_CardATKText;
    [SerializeField] Text m_CardMATText;

    //cardの見た目を変更する
    public void Show(CardModel cardModel)
    {
        //それぞれPrefabの中の要素をインスペクターにドラッグ＆ドロップ
        m_CardNameText.text = cardModel.m_CardName; 
        m_CardCostText.text = cardModel.m_CardCost.ToString();
        m_CardText.text = cardModel.m_CardText;
        m_CardImage.sprite = cardModel.m_CardImage;
        m_CardATKText.text = cardModel.m_CardATK.ToString();
        m_CardMATText.text = cardModel.m_CardMAT.ToString();
    }
}
