using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Database : MonoBehaviour
{
    //�y���d�v�z�J�[�hID�̃��X�g��static�錾 ������DataBase�݂����Ȃ̂Ɉڂ�
    //[SerializeField] public static List<int> s_AllCardList = new List<int>();//�������Ă���S�J�[�h
    //[SerializeField] public static List<int> s_PlayerDeckCardList = new List<int>();//�v���C���[�̍ŏ��̃f�b�L
    public static List<List<int>> s_DeckList = new List<List<int>>();

    public static int s_DeckSelectionNum;

    public static int s_PlayerMaxHP = 50;
    public static int s_PlayerHP = s_PlayerMaxHP;

    void Awake()
    {
        s_DeckList.Clear();
        for (int i = 0; i < 20; i++) s_DeckList.Add(new List<int>()); //�ꎟ���ڂ��m��
        s_DeckList[0] = new List<int>() { 1, 1, 1, 2, 2 };
        s_DeckList[1] = new List<int>() { 2, 2, 2, 3, 3 };
        s_DeckList[2] = new List<int>() { 3, 3, 3, 3, 3 };
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
