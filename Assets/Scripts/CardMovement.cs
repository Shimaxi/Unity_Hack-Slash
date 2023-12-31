using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardMovement : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public BattleManager m_BattleManager;
    public Transform m_DefaultParent;

    public void Start()
    {
        m_BattleManager = GameObject.Find("BattleManager").GetComponent<BattleManager>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        m_DefaultParent = transform.parent;
        transform.SetParent(m_DefaultParent.parent, false);
        GetComponent<CanvasGroup>().blocksRaycasts = false;
        m_BattleManager.UpdateDamage();
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(m_DefaultParent, false);
        GetComponent<CanvasGroup>().blocksRaycasts = true;
        m_BattleManager.UpdateDamage();
        if(transform.parent.name == "ATKCardArea")
        {
            Debug.Log("�U��");
        }
    }
}
