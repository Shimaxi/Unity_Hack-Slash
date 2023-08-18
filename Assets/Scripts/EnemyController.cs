using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    //変数宣言
    public EnemyModel m_EnemyModel; //CardModel型で書かれたカードの情報
    public Image m_EnemyImage;
    public void Init(int enemyID)
    {
        m_EnemyModel = new EnemyModel(enemyID); //CardModel型の情報を変数m_CardModelに入れる
        m_EnemyImage.sprite = m_EnemyModel.m_EnemyImage;
    }
}
