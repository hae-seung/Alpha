using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUseable//비전투 인벤토리에서 사용가능
{ 
   public int Use();
}

public interface IConsumable
{
   public ConsumeType GetConsumeType();
   public CountableItem GetItem();
}

public interface IBattleUseable//전투에서 사용되는 소모 아이템
{
   
}


public interface IEquippable
{
   void EquipOrSwapItem(Item item);
   void UnEquipItem(Item item);
   Enum GetItemType();
}

