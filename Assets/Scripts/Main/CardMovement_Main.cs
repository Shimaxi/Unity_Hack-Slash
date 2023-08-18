using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardMovement_Main : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public Transform m_DefaultParent;

    public PreparationManager m_PreparationManager;

    private RectTransform rectTransform;

    Vector2 rootPos = new Vector2(520f, 960f); //‰æ–Ê‚Ì”¼•ª

    public void Start()
    {
        m_PreparationManager = GameObject.Find("PreparationManager").GetComponent<PreparationManager>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        m_DefaultParent = transform.parent;
        transform.SetParent(m_DefaultParent.parent, false);
        GetComponent<CanvasGroup>().blocksRaycasts = false;
        m_PreparationManager.DeckCount();
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.localPosition = eventData.position - rootPos;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(m_DefaultParent, false);
        GetComponent<CanvasGroup>().blocksRaycasts = true;
        m_PreparationManager.DeckCount();
    }
}

