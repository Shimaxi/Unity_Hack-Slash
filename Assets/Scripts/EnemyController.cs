using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    //�ϐ��錾
    public EnemyModel m_EnemyModel; //CardModel�^�ŏ����ꂽ�J�[�h�̏��
    public Image m_EnemyImage;
    public void Init(int enemyID)
    {
        m_EnemyModel = new EnemyModel(enemyID); //CardModel�^�̏���ϐ�m_CardModel�ɓ����
        m_EnemyImage.sprite = m_EnemyModel.m_EnemyImage;
    }
}
