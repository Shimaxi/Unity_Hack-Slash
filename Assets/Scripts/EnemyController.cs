using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    //•Ï”éŒ¾
    public EnemyModel m_EnemyModel; //CardModelŒ^‚Å‘‚©‚ê‚½ƒJ[ƒh‚Ìî•ñ
    public Image m_EnemyImage;
    public void Init(int enemyID)
    {
        m_EnemyModel = new EnemyModel(enemyID); //CardModelŒ^‚Ìî•ñ‚ğ•Ï”m_CardModel‚É“ü‚ê‚é
        m_EnemyImage.sprite = m_EnemyModel.m_EnemyImage;
    }
}
