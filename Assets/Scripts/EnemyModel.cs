using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyModel
{
    public int m_EnemyID;
    public string m_EnemyName;
    public Sprite m_EnemyImage;
    public int m_EnemyATK;
    public int m_EnemyMAT;

    public EnemyModel(int enemyID)
    {
        EnemyEntity m_EnemyEntity = Resources.Load<EnemyEntity>("EnemyEntityList/EnemyEntity" + enemyID);

        m_EnemyID = m_EnemyEntity.enemyID;
        m_EnemyName = m_EnemyEntity.enemyName;
        m_EnemyImage = m_EnemyEntity.enemyImage;
        m_EnemyATK = m_EnemyEntity.enemyAttackDamage;
        m_EnemyMAT = m_EnemyEntity.enemyMagicAttackDamage;

    }
}
