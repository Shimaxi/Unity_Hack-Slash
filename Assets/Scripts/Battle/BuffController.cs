using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

//�o�t�Ɋւ���X�N���v�g
public class BuffController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Image m_BuffIcon;
    public GameObject m_BuffExplamation;
    public Text m_BuffExplanationText;

    void Start()
    {
        m_BuffExplamation.SetActive(false);
    }
    //�}�E�X�I�[�o�[���m
    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("�G���܂����I�I�I");
        m_BuffExplamation.SetActive(true);
    }
    //���ꂽ���m
    public void OnPointerExit(PointerEventData eventData)
    {
        m_BuffExplamation.SetActive(false);
    }
}
