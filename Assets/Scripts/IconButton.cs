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
                //SceneManager.LoadScene("Battle");
                break;
            case "Tresure":
                Debug.Log("��");
                break;
            case "Event":
                Debug.Log("�C�x���g");
                break;
            case "Boss":
                Debug.Log("�{�X�o�g��");
                break;
        }
        
    }
}
