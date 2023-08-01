using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

//バフに関するスクリプト
public class BuffController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Image m_BuffIcon;
    public GameObject m_BuffExplamation;
    public Text m_BuffExplanationText;

    void Start()
    {
        m_BuffExplamation.SetActive(false);
    }
    //マウスオーバー検知
    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("触られました！！！");
        m_BuffExplamation.SetActive(true);
    }
    //離れた検知
    public void OnPointerExit(PointerEventData eventData)
    {
        m_BuffExplamation.SetActive(false);
    }
}
