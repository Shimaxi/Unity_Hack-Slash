using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{

    void Start()
    {
        
    }

    //GameManager‚©‚çŒÄ‚Ño‚³‚ê‚éE“G‚Ìs“®‚ğŒˆ‚ß‚éŠÖ”
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
