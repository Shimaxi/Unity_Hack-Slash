using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{

    void Start()
    {
        
    }

    //GameManagerから呼び出される・敵の行動を決める関数
    public void DecideEnemyBehavior()
    {
        GameManager.s_EnemyATK = Random.Range(1, 10);
        GameManager.s_EnemyMAT = Random.Range(1, 10);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
