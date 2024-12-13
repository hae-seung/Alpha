using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class MenuBtn : MonoBehaviour, IPointerEnterHandler
{
    public string btnName;
    public string btnDescription;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI descriptionText;
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        EventSystem.current.SetSelectedGameObject(gameObject);
        SetUIText();
    }

    public void SetUIText()
    {
        nameText.text = btnName;
        descriptionText.text = btnDescription;
    }
    
}
