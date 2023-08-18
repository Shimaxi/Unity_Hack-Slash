using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    //•Ï”éŒ¾
    public EnemyModel m_EnemyModel; //CardModelŒ^‚Å‘‚©‚ê‚½ƒJ[ƒh‚Ìî•ñ
    public void Init(int enemyID)
    {
        m_EnemyModel = new EnemyModel(enemyID); //CardModelŒ^‚Ìî•ñ‚ğ•Ï”m_CardModel‚É“ü‚ê‚é
    }
}
