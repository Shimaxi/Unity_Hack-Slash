using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StageManager : MonoBehaviour
{
    public IconController m_SpacePrefab;
    public Transform[] m_Stage;
    IconController m_Space;

    //���݂̃X�e�[�W
    public static int m_StageNum = 2;

    void Start()
    {
        UnityEngine.Random.InitState(10);//�V�[�h�l�Œ�

        m_Space = Instantiate(m_SpacePrefab, m_Stage[0], false);
        m_Space.Show(0);

        //���݂̃X�e�[�W�̐i�s�󋵂��m�F���āA�{�^���������Ă悢��ԂłȂ���΃I�t�ɂ���
        if (m_StageNum != 1)
        {
            Button btn = m_Space.GetComponent<Button>();
            btn.interactable = false;
        }

        for (int i = 0; i < 3; i++)
        {
            m_Space = Instantiate(m_SpacePrefab, m_Stage[1], false);
            int rnd = Random.Range(0, 3);
            m_Space.Show(rnd);
            if (m_StageNum != 2)
            {
                Button btn = m_Space.GetComponent<Button>();
                btn.interactable = false;
            }

        }
        for (int i = 0; i < 3; i++)
        {
            int rnd = Random.Range(0, 3);
            m_Space = Instantiate(m_SpacePrefab, m_Stage[2], false);
            m_Space.Show(rnd);
            if (m_StageNum != 3)
            {
                Button btn = m_Space.GetComponent<Button>();
                btn.interactable = false;
            }
        }

        m_Space = Instantiate(m_SpacePrefab, m_Stage[3], false);
        m_Space.Show(3);
        if (m_StageNum != 4)
        {
            Button btn = m_Space.GetComponent<Button>();
            btn.interactable = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
