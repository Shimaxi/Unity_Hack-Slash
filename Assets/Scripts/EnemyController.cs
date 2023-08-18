using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    //変数宣言
    public EnemyModel m_EnemyModel; //CardModel型で書かれたカードの情報
    public void Init(int enemyID)
    {
        m_EnemyModel = new EnemyModel(enemyID); //CardModel型の情報を変数m_CardModelに入れる
    }
}
