using System;
using UnityEngine;

public abstract class EquipItem<T> : Item, IEquippable where T : Enum
{
    public EquipItemData EquipData { get; private set; }
   
    private int durability;
    public int Durability
    {
        get => durability;
        set => durability = Mathf.Clamp(value, 0, EquipData.MaxDurability);
    }
   
    public EquipItem(EquipItemData data) : base(data)
    {
        EquipData = data;
        Durability = data.MaxDurability;
    }

    public void EquipOrSwapItem(Item item)
    {
        InvokeEquipOrSwapItem(item);
    }

    public void UnEquipItem(Item item)
    {
        InvokeUnequipItem(item);
    }
    
    public abstract T GetItemTypeValue();//실제 아이템의 타입 ArmorType.Hat 
    
    Enum IEquippable.GetItemType() => GetItemTypeValue();//이것도 ArmorType.Hat 반환 //묶어서 IEquippable로 관리할때 편함
}