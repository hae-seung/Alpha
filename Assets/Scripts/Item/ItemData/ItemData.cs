using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemData : ScriptableObject
{
    [SerializeField] private int id;
    [SerializeField] private string name;
    [SerializeField] private string description;
    [SerializeField] private Sprite iconImage;
    [SerializeField] private GameObject dropItem;


    public int Id => id;
    public string Name => name;
    public string Description => description;
    public Sprite IconImage => iconImage;
    public GameObject DropItem => dropItem;
}
