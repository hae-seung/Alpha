using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CountableItem : Item
{
   protected CountableItemData CountableData { get; private set; }
   
   public int Amount { get; protected set; }
   public int MaxAmount => CountableData.MaxAmount;

   public bool IsMax => Amount >= CountableData.MaxAmount;

   public bool IsEmpty => Amount <= 0;
   
   public event Action<int> OnUpdateItemCount;
    
    public CountableItem(CountableItemData data, int amount = 1) : base(data)
    {
        CountableData = data;
        SetAmount(amount);
    }

    public void SetAmount(int amount)
    {
        Amount = Mathf.Clamp(amount, 0, MaxAmount);
    }

    public int AddAmountAndGetExcess(int amount)
    {
        int nextAmount = Amount + amount;
        SetAmount(nextAmount);

        return (nextAmount > MaxAmount) ? (nextAmount - MaxAmount) : 0;
    }

    public void UpdateItemCount()//아이템이 추가될때 사용
    {
        OnUpdateItemCount?.Invoke(Amount);
    }
    
    
    public CountableItem Clone(int amount)
    {
        return CloneItem(amount);
    }
    
    protected abstract CountableItem CloneItem(int amount);
}
