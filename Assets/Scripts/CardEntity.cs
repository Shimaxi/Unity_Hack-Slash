using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CardEntity", menuName = "Create CardEntity")]
public class CardEntity : ScriptableObject
{
    public int cardID;
    public string cardName;
    public int cardCost;
    public Sprite cardImage;
    public string cardText;
    public int cardAttackDamage;
    public int cardMagicAttackDamage;
}
