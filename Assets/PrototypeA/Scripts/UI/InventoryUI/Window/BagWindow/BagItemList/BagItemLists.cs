using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BagItemLists : MonoBehaviour
{
    public GameObject[] itemLists;
    
    public void ActiveFalseAllWindow()
    {
       for(int i = 0; i<itemLists.Length; i++)
           itemLists[i].SetActive(false);
    }
}
