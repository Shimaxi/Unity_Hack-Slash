using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DropPlace : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        CardMovement m_Card = eventData.pointerDrag.GetComponent<CardMovement>();
        if(m_Card != null)
        {
            m_Card.m_DefaultParent = this.transform;
        }
    }
}
