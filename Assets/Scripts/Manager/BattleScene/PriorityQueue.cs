using System;
using System.Collections;
using System.Collections.Generic;

public class SkillComparer : IComparer<SkillCast>
{
    public int Compare(SkillCast x, SkillCast y)
    {
        // ExecuteTp를 기준으로 정렬 (낮은 TP가 우선)
        int tpComparison = x.ExecuteTp.CompareTo(y.ExecuteTp);
        if (tpComparison != 0)
            return tpComparison;

        return y.Caster.Status.Dex.CompareTo(x.Caster.Status.Dex);
        
    }
}
public class PriorityQueue<T>
{
    private List<T> data;
    private IComparer<T> comparer;

    public PriorityQueue(IComparer<T> comparer)//생성자
    {
        this.data = new List<T>();
        this.comparer = comparer;
    }

    public void Enqueue(T item)
    {
        // BinarySearch로 적절한 삽입 위치를 찾음
        int index = data.BinarySearch(item, comparer);
        
        // BinarySearch는 음수 인덱스를 반환할 수 있으므로 반전하여 삽입 위치를 계산
        if (index < 0) index = ~index;
        
        // 정렬된 위치에 삽입
        data.Insert(index, item);
    }

    public T Dequeue()
    {
        if (data.Count == 0)
            throw new InvalidOperationException("Queue is empty");

        T item = data[0];
        data.RemoveAt(0);  // 최우선순위 항목을 제거
        return item;
    }

    public bool IsEmpty()
    {
        return data.Count == 0;
    }
}
