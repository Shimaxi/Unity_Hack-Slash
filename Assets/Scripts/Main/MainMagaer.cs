using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    public GameObject m_Panels;
    public GameObject m_StageInfo;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void PushPreparationButton()
    {
        m_Panels.transform.localPosition = new Vector3(-1200, 0, -10);
    }

    public void PushStageDecideButton()
    {
        m_StageInfo.SetActive(true);
    }

    public void PushSelectBackButton()
    {

    }

    public void PushSelectFowardButton()
    {

    }

    public void PushBackToMainButton()
    {
        m_Panels.transform.localPosition = new Vector3(0, 0, -10);
    }



}
