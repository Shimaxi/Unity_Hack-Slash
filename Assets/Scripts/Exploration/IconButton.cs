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
                Debug.Log("バトル");
                SceneManager.LoadScene("Battle");
                StageManager.s_StageNum++;
                break;
            case "Tresure":
                Debug.Log("宝物");
                StageManager.s_StageNum++;
                break;
            case "Event":
                Debug.Log("イベント");
                StageManager.s_StageNum++;
                break;
            case "Boss":
                Debug.Log("ボスバトル");
                StageManager.s_StageNum++;
                break;
        }
        
    }
}
