using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character
{
   public Dictionary<int, Skill> ownedSkill = new();//보유한 모든 스킬 목록
   //public Dictionary<WeaponType, List<Skill>> quickSkill = new();
   public Status status;
   //public Inventory inventory = new Inventory();//개인 인벤토리 필요
   public GameObject battleCharacterPrefab; //3D에서 보여질 프리팹
   
   
   public Character(StatusData data, GameObject prefab)//생성자
   {
      status = new Status(data);
      battleCharacterPrefab = prefab;
   }
}
