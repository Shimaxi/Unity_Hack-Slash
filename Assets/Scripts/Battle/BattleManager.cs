using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleManager : MonoBehaviour
{
    //�U���̂����֘A
    //�X���C�_�[ �܂Ƃ߂ĊǗ����������A���O�����₷�������ǂ����H
    [SerializeField] private Slider m_PlayerATKSlider;
    [SerializeField] private Slider m_PlayerMATSlider;
    [SerializeField] private Slider m_EnemyATKSlider;
    [SerializeField] private Slider m_EnemyMATSlider;

    //�X���C�_�[�ɕt���Ă鐔�l
    [SerializeField] private Text m_PlayerATKDamageSumText;
    [SerializeField] private Text m_PlayerMATDamageSumText;
    [SerializeField] private Text m_EnemyATKDamageSumText;
    [SerializeField] private Text m_EnemyMATDamageSumText;


    //�_���[�W�v�Z�֘A
    //�J�[�h�̒u���ꏊ
    [SerializeField] private Transform m_PlayerATKTransform;
    [SerializeField] private Transform m_PlayerMATTransform;

    //�v���C���[�̍U��
    private int m_PlayerATKSum = 0;
    private int m_PlayerMATSum = 0;

    //�G�̍U��
    private int m_EnemyATK;
    private int m_EnemyMAT;

    //���݂��̗̑�
    private int m_PlayerHP;
    private int m_EnemyMaxHP = 10;
    private int m_EnemyHP;

    //�̗̓X���C�_�[
    [SerializeField] private Slider m_PlayerHPSlider;
    [SerializeField] private Slider m_EnemyHPSlider;

    //�̗͕���
    [SerializeField] private Text m_PlayerHPText;
    [SerializeField] private Text m_EnemyHPText;

    //�o�t�֘A
    [SerializeField] private BuffController m_BuffPrefab;
    [SerializeField] private Transform m_PlayerBuffArea;

    //�o�g�����U���g�֘A
    [SerializeField] private GameObject m_BattleResult;
    [SerializeField] private Text m_BattleResultText;
    [SerializeField] private GameObject m_NextButton;
    [SerializeField] private GameObject m_ExitButton;

    //�����̗͂̔��f

    void Start()
    {
        m_BattleResult.SetActive(false);
        m_PlayerHP = Database.s_PlayerHP;
        m_EnemyHP = m_EnemyMaxHP;
        m_PlayerHPText.text = m_PlayerHP.ToString() + " / " + Database.s_PlayerMaxHP.ToString();
        m_EnemyHPText.text = m_EnemyHP.ToString() + " / " + m_EnemyMaxHP.ToString();
        m_PlayerHPSlider.value = (float)m_PlayerHP / Database.s_PlayerMaxHP;
        m_EnemyHPSlider.value = (float)m_EnemyHP / m_EnemyMaxHP;
    }

    //GameManager����Ăяo���E�G�̍s���𔽉f���A�X���C�_�[�����Z�b�g
    public void StartTurn()
    {
        m_EnemyATK = GameManager.s_EnemyATK;
        m_EnemyMAT = GameManager.s_EnemyMAT;
        //Instantiate(m_BuffPrefab, m_PlayerBuffArea, false);
        ATKSlide(0);
        MATSlide(0);
        m_EnemyATKDamageSumText.text = m_EnemyATK.ToString();
        m_EnemyMATDamageSumText.text = m_EnemyMAT.ToString();
    }

    //CardMovement����Ăяo���E�_���[�W�v�Z�E�X���C�_�[���f
    public void UpdateDamage()
    {
        m_PlayerATKSum = 0;
        m_PlayerMATSum = 0;

        foreach (Transform child in m_PlayerATKTransform)
        {
            CardController m_TargetCard = child.GetComponent<CardController>();
            m_PlayerATKSum += m_TargetCard.m_CardModel.m_CardATK;

        }
        foreach (Transform child in m_PlayerMATTransform)
        {
            CardController m_TargetCard = child.GetComponent<CardController>();
            m_PlayerMATSum += m_TargetCard.m_CardModel.m_CardMAT;
        }

        ATKSlide(m_PlayerATKSum);
        MATSlide(m_PlayerMATSum);

    }


    //ATK���̃X���C�_�[�𓮂����֐�
    void ATKSlide(int power)
    {
        //int m_PlayerATK = power;
        m_PlayerATKDamageSumText.text = power.ToString();
        //���������߂�
        m_PlayerATKSlider.value = (float)m_PlayerATKSum / (m_PlayerATKSum + m_EnemyATK);
        m_EnemyATKSlider.value = (float)m_EnemyATK / (m_PlayerATKSum + m_EnemyATK);
    }
    //MAT���̃X���C�_�[�𓮂����֐�
    void MATSlide(int power)
    {
        //int m_PlayerMAT = power;
        m_PlayerMATDamageSumText.text = power.ToString();
        //���������߂�
        m_PlayerMATSlider.value = (float)m_PlayerMATSum / (m_PlayerMATSum + m_EnemyMAT);
        m_EnemyMATSlider.value = (float)m_EnemyMAT / (m_PlayerMATSum + m_EnemyMAT);
    }


    //GameManager����Ăяo�����E�_���[�W���m�肵�����HP�����炷
    public void CalcDamage()
    {
        if (m_PlayerATKSum - m_EnemyATK >= 0)
        {
            m_EnemyHP -= (m_PlayerATKSum - m_EnemyATK);
        }
        else if (m_PlayerATKSum - m_EnemyATK < 0)
        {
            m_PlayerHP -= (m_EnemyATK - m_PlayerATKSum);
        }

        if (m_PlayerMATSum - m_EnemyMAT >= 0)
        {
            m_EnemyHP -= (m_PlayerMATSum - m_EnemyMAT);
        }
        else if (m_PlayerMATSum - m_EnemyMAT < 0)
        {
            m_PlayerHP -= (m_EnemyMAT - m_PlayerMATSum);
        }

        if(m_PlayerHP <= 0)
        {
            m_PlayerHP = 0;
            m_BattleResult.SetActive(true);
            m_NextButton.SetActive(false);
            m_ExitButton.SetActive(true);
            m_BattleResultText.text = "YOU LOSE";
            GameManager.s_BattleEnd = true;
        }

        if (m_EnemyHP <= 0 && m_PlayerHP >= 0)
        {
            m_EnemyHP = 0;
            m_BattleResult.SetActive(true);
            m_NextButton.SetActive(true);
            m_ExitButton.SetActive(false);
            m_BattleResultText.text = "YOU WIN";
            GameManager.s_BattleEnd = true;
        }

        Database.s_PlayerHP = m_PlayerHP;

        m_PlayerHPSlider.value = (float)m_PlayerHP / Database.s_PlayerMaxHP;
        m_EnemyHPSlider.value = (float)m_EnemyHP / m_EnemyMaxHP;


        m_PlayerHPText.text = m_PlayerHP.ToString() + " / " + Database.s_PlayerMaxHP.ToString();
        m_EnemyHPText.text = m_EnemyHP.ToString() + " / " + m_EnemyMaxHP.ToString();
        m_PlayerATKSum = 0;
        m_PlayerMATSum = 0;
    }
}
