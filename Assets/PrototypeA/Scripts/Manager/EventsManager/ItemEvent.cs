using System;
using UnityEngine;

public class ItemEvent
{
    /// <summary>
    /// 아이템이 이미 수중에 있는지 확인
    /// </summary>
    public event Func<int, int> onRequestItemCheck;
    public int ItemCheckRequested(int itemId)
    {
        return onRequestItemCheck?.Invoke(itemId) ?? 0;
    }
    
    /// <summary>
    /// 아이템 획득 => 인벤토리가 호출해줌
    /// </summary>
    public event Action<int, int> onGetItem;
    public void GetItem(int itemId, int amount)
    {
        onGetItem?.Invoke(itemId, amount);
    }

    /// <summary>
    /// 플레이어가 아이템 사용 -> 인벤토리가 호출
    /// </summary>
    public event Action<int, int> onConsumeItem;
    public void ConsumeItem(int itemId, int amount)//사용된 갯수
    {
        onConsumeItem?.Invoke(itemId, amount);
    }

    /// <summary>
    /// 플레이어가 아닌(NPC 배달 퀘스트 클리어시) 다른 곳에서 아이템 감소시킬때 호출 => 인벤토리 아이템이 amount만큼 감소
    /// </summary>
    public event Action<int, int> onReduceInventoryItem;
    public void ReduceInventoryItem(int itemId, int amount)//감소시킬 갯수(== 사용된 갯수)
    {
        onReduceInventoryItem?.Invoke(itemId, amount);
    }
}
