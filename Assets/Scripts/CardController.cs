using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardController : MonoBehaviour
{
    //変数宣言
    public CardModel m_CardModel; //CardModel型で書かれたカードの情報
    public CardView m_CardView; //CardView型で書かれたカードの見た目

    public void Init(int cardID)
    {
        m_CardModel = new CardModel(cardID); //CardModel型の情報を変数m_CardModelに入れる
        m_CardView.Show(m_CardModel); //カードの見た目を上のm_CardModelの情報を元に表示する
    }
}
