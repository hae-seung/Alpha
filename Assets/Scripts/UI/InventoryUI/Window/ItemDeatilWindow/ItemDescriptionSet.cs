using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemDescriptionSet : MonoBehaviour
{
    public TextMeshProUGUI itemDescription;


    public void UpdateDescription(Item item)
    {
        itemDescription.text = item.Data.Description;
    }
}
