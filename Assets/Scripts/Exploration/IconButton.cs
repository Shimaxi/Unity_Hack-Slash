using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IconButton : MonoBehaviour
{
    public GameObject test;
    public void ChangeScene()
    {
        switch (this.name)
        {
            case "Battle":
                Debug.Log("�o�g��");
                SceneManager.LoadScene("Battle");
                StageManager.s_StageNum++;
                break;
            case "Tresure":
                Debug.Log("��");
                StageManager.s_StageNum++;
                break;
            case "Event":
                Debug.Log("�C�x���g");
                StageManager.s_StageNum++;
                break;
            case "Boss":
                Debug.Log("�{�X�o�g��");
                StageManager.s_StageNum++;
                break;
        }
        
    }
}
