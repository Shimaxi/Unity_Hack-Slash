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
                //SceneManager.LoadScene("Battle");
                break;
            case "Tresure":
                Debug.Log("宝物");
                break;
            case "Event":
                Debug.Log("イベント");
                break;
            case "Boss":
                Debug.Log("ボスバトル");
                break;
        }
        
    }
}
