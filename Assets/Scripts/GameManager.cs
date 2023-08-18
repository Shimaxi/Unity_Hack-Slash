using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField , Header("�J�[�h�̃v���n�u")] private CardController m_CardPrefab; //�J�[�h�̌^�ƂȂ�v���n�u�̏��(�v���n�u�t�H���_����C���X�y�N�^�[�Ƀh���b�O)
    [SerializeField, Header("�v���C���[�̃n���h�ʒu")] private Transform m_PlayerHandTransform; //�v���C���[�̃n���h�̈ʒu�̏��(�q�G�����L�[����h���b�O&�h���b�v)

    [SerializeField, Header("�퓬�̌v�Z�������Ǘ�����X�N���v�g")] private BattleManager m_BattleManager; //BatteManager.cs�̊֐��������Ă��邽�߂ɐ錾
    [SerializeField, Header("�G���Ǘ�����X�N���v�g")] private EnemyManager m_EnemyManager; //�q�G�����L�[�ɃX�N���v�g���A�^�b�`����GameObject�����A�A�^�b�`����
    
    [SerializeField, Header("�^�[���I�����ɐ�������ꏊ")] private Transform[] m_RefreshArea;//�^�[���I�����ɑ|������G���A

    private bool m_TurnEndFlg = false;

    //�y���d�v�z�J�[�hID�̃��X�g��static�錾 ������DataBase�݂����Ȃ̂Ɉڂ�
    public static List<int> s_DeckCardList = new List<int>();//���݂̃f�b�L�ɂ���J�[�h
    public static List<int> s_CemeteryCardList = new List<int>();//���݂̕�n�ɂ���J�[�h
    [SerializeField, Header("(�m�F�p�ɕ\�����Ă邾��)")] private List<int> m_CemeteryPredCardList = new List<int>();//��D�ɗ����J�[�h�����̃^�[���ɕ�n�ɓ���邽�߂̃��X�g

    //DeckViewManager�ł��g���̂�static�錾
    public static bool s_DeckCheck = false; //�f�b�L���m�F�������ǂ������L�^���Ă���
    public static bool s_CemeteryCheck = false; //��n���m�F�������ǂ������L�^���Ă���

    //
    public static bool s_BattleEnd = false;

    //BattleManager�ł��g���̂�static�錾�@������DataBase�݂����Ȃ̂Ɉڂ�
    public static int s_PlayerHP = 50; //�v���C���[�̍ő�HP���
    public static int s_EnemyHP = 10; //�G�̍ő�HP���

    //BattleManager�ł��g���̂�static�錾�@������DataBase�݂����Ȃ̂Ɉڂ�
    public static int s_EnemyATK; //�G�̍U��
    public static int s_EnemyMAT; //�G�̖��@�U��

    


    //�^�[���G���h�{�^���������ꂽ��
    public void OnClickTurnEndButton()
    {
        m_TurnEndFlg = true;
    }

    //�ޏo�{�^���������ꂽ��
    public void OnClickExitButton()
    {
        SceneManager.LoadScene("Exploration");
    }

    void Start()
    {
        s_DeckCardList = Database.s_PlayerDeckCardList; //�f�[�^�x�[�X�ɂ��鏉���R�D���쐬

        StartCoroutine(GameLoop());
    }


    private IEnumerator GameLoop()
    {
        m_TurnEndFlg = false;

        yield return StartCoroutine(StartPlayerTurn());

        yield return StartCoroutine(SetStartHand());

        yield return new WaitWhile(() => !m_TurnEndFlg);

        yield return StartCoroutine(EndPlayerTurn());

        if (s_BattleEnd == true)
        {
            yield break;
        }
        else
        {
            StartCoroutine(GameLoop());
        }

    }

    private IEnumerator StartPlayerTurn()
    {
        m_EnemyManager.DecideEnemyBehavior();//EnemyManager���̓G�̍s�������߂�֐�
        m_BattleManager.StartTurn();//BattleManager�̋N��
        yield return null;
    }

    private IEnumerator SetStartHand()
    {
        ShuffleCards();//�J�[�h�V���b�t��
        //�J�[�h����
        for (int i = 0; i < 3; i++)
        {
            CreateCard(m_PlayerHandTransform); //�����X�N���v�g����CreateCard()�����s
        }
        yield return null;
    }

    private IEnumerator EndPlayerTurn()
    {
        m_BattleManager.CalcDamage();
        RefreshPhase();
        yield return null;
    }


    //�J�[�h�𐶐�����֐�
    void CreateCard(Transform hand)
    {
        CardController m_Card = Instantiate(m_CardPrefab, hand, false); //hand�ʒu�ɃJ�[�h�v���n�u����J�[�h�𐶐����ACardController�^�̕ϐ�m_card�Ƃ���

        if (s_DeckCardList.Count == 0)
        {
            //�R�D�������Ȃ������n���f�b�L�ɖ߂��ăV���b�t��
            s_DeckCardList.AddRange(s_CemeteryCardList); //�f�b�L�̒��g�ɕ�n�̃J�[�h�𑫂�
            s_CemeteryCardList.Clear(); //��n�̃J�[�h���N���A��
            ShuffleCards(); //�V���b�t�����s��
        }
        m_Card.Init(s_DeckCardList[0]); //CardController.cs����Init(����)�����s�@�J�[�h��ID���琶��
        m_CemeteryPredCardList.Add(s_DeckCardList[0]);//�����������J�[�h���n�\�胊�X�g�ɓ����
        s_DeckCardList.RemoveAt(0);//�����������J�[�h���f�b�L�̃��X�g���甲��
    }

    //�J�[�h���u����Ă���ꏊ���N���A����
    void RefreshPhase()
    {
        for (int i = 0; i < 5; i++)
        {
            foreach (Transform child in m_RefreshArea[i])
            {
                Destroy(child.gameObject);//Transform�̕�����ʂ̊T�O�Ȃ́I�H�H�I�H
            }
        }
        s_CemeteryCardList.AddRange(m_CemeteryPredCardList);
        m_CemeteryPredCardList.Clear();
        s_DeckCheck = false;
        s_CemeteryCheck = false;


    }


    //�f�b�L���V���b�t������
    void ShuffleCards() 
    {
        // ���� n �̏����l�̓f�b�L�̖���
        int n = s_DeckCardList.Count;

        // n��1��菬�����Ȃ�܂ŌJ��Ԃ�
        while (n > 1)
        {
            n--;

            // k�� 0 �` n+1 �̊Ԃ̃����_���Ȓl
            int k = UnityEngine.Random.Range(0, n + 1);

            // k�Ԗڂ̃J�[�h��temp�ɑ��
            int temp = s_DeckCardList[k];
            s_DeckCardList[k] = s_DeckCardList[n];
            s_DeckCardList[n] = temp;
        }
    }

}
