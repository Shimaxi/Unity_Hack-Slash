using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Database : MonoBehaviour
{
    //�y���d�v�z�J�[�hID�̃��X�g��static�錾 ������DataBase�݂����Ȃ̂Ɉڂ�
    [SerializeField] public static List<int> s_AllCardList = new List<int>();//�������Ă���S�J�[�h
    [SerializeField] public static List<int> s_PlayerDeckCardList = new List<int>();//�v���C���[�̍ŏ��̃f�b�L

    public static List<List<int>> s_DeckList = new List<List<int>>();

    // Start is called before the first frame update
    void Awake()
    {   
        /*
        s_PlayerDeckCardList.Add(1);
        s_PlayerDeckCardList.Add(2);
        s_PlayerDeckCardList.Add(3);
        s_PlayerDeckCardList.Add(1);
        s_PlayerDeckCardList.Add(2);
        s_PlayerDeckCardList.Add(3);
        s_PlayerDeckCardList.Add(1);
        s_PlayerDeckCardList.Add(2);
        s_PlayerDeckCardList.Add(3);
        */

        s_AllCardList.Add(1);
        s_AllCardList.Add(2);
        s_AllCardList.Add(3);
        s_AllCardList.Add(1);
        s_AllCardList.Add(2);
        s_AllCardList.Add(3);
        s_AllCardList.Add(1);
        s_AllCardList.Add(2);
        s_AllCardList.Add(3);
        s_AllCardList.Add(1);
        s_AllCardList.Add(2);
        s_AllCardList.Add(3);
        s_AllCardList.Add(1);
        s_AllCardList.Add(2);
        s_AllCardList.Add(3);

        for (int i = 0; i < 20; i++) s_DeckList.Add(new List<int>()); //�ꎟ���ڂ��m��

        s_DeckList[0].Add(1);
        s_DeckList[0].Add(1);
        s_DeckList[0].Add(1);

        /*
        s_DeckList[1].Add(2);
        s_DeckList[1].Add(2);
        s_DeckList[1].Add(2);
        */
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
