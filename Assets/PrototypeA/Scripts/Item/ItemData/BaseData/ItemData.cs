using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemData : ScriptableObject
{
    [SerializeField] private int _id;
    [SerializeField] private string _name;
    [SerializeField] private string _description;
    [SerializeField] private Sprite _iconImage;
    [SerializeField] private GameObject _dropItem;


    public int Id => _id;
    public string Name => _name;
    public string Description => _description;
    public Sprite IconImage => _iconImage;
    public GameObject DropItem => _dropItem;
}
