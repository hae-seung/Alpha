using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Character
{
   /*
    * 유동적으로 변하는 플레이어와 파티의 데이터 관리를 위함
    */
   
   public Dictionary<int, Skill> ownedSkill = new();
   public Dictionary<int, Skill> equippedSkill = new();
   public Status status;
   //public Inventory inventory = new Inventory();//개인 인벤토리 필요
   public GameObject battleCharacterPrefab; //3D에서 보여질 프리팹
   
   
   public Character(StatusData data)//생성자
   {
      status = new Status(data);
   }

   
   
}
