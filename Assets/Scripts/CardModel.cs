using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ƒJ[ƒh‚Ìî•ñ
public class CardModel
{
    public int m_CardID;
    public string m_CardName;
    public int m_CardCost;
    public Sprite m_CardImage;
    public string m_CardText;
    public int m_CardATK;
    public int m_CardMAT;

    public CardModel(int cardID)
    {
        CardEntity m_CardEntity = Resources.Load<CardEntity>("CardEntityList/CardEntity" + cardID);

        m_CardID = m_CardEntity.cardID;
        m_CardName = m_CardEntity.cardName;
        m_CardCost = m_CardEntity.cardCost;
        m_CardImage = m_CardEntity.cardImage;
        m_CardText = m_CardEntity.cardText;
        m_CardATK = m_CardEntity.cardAttackDamage;
        m_CardMAT = m_CardEntity.cardMagicAttackDamage;

    }

}
