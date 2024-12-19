using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MonsterData", menuName = "SO/MonsterData", order = int.MaxValue)]
public class MonsterData : ScriptableObject
{
   public StatusData statusData;
   //public List<item> items; //todo:소유 아이템 목록. 인벤토리로 될라나?
   
   public GameObject battleMonsterPrefab;
   
   
   public List<MonsterData> monsterPartyData;
}
