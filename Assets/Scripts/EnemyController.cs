using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    //�ϐ��錾
    public EnemyModel m_EnemyModel; //CardModel�^�ŏ����ꂽ�J�[�h�̏��
    public void Init(int enemyID)
    {
        m_EnemyModel = new EnemyModel(enemyID); //CardModel�^�̏���ϐ�m_CardModel�ɓ����
    }
}
