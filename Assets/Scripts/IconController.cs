using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IconController : MonoBehaviour
{
    [SerializeField] Image m_IconImage;

    //card�̌����ڂ�ύX����
    public void Show(int spaceID)
    {
        switch (spaceID)
        {
            case 0:
                m_IconImage.sprite = Resources.Load<Sprite>("StageIcons/Battle");
                this.name = "Battle";
                break;
            case 1:
                m_IconImage.sprite = Resources.Load<Sprite>("StageIcons/Tresure");
                this.name = "Tresure";
                break;
            case 2:
                m_IconImage.sprite = Resources.Load<Sprite>("StageIcons/Event");
                this.name = "Event";
                break;
            case 3:
                m_IconImage.sprite = Resources.Load<Sprite>("StageIcons/Boss");
                this.name = "Boss";
                break;
        }
        
    }

    

}
