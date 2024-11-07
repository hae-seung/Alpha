using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/*
public class PriorityQueue : MonoBehaviour
{
    
}
*/
public class PriorityQueue
{
    //힙 자료 데이터를 담을 List 추가
    List<Entity> Heap;


    //힙 자료 생성
    public PriorityQueue()
    {
        Heap = new List<Entity>();

    }


    //Enqueue 기능 우선순위 큐에 데이터를 인자값으로 넣음
    public void Enqueue(Entity data)
    {
        // list에 데이터 추가
        Heap.Add(data);

        // 현재 리스트 크기 확인 탐색
        int index = Heap.Count() - 1;

        // MinHeap으로 정렬
        while (index > 0)
        {
            //현재 넣은 데이터 차일드 검색
            int child = index;

            //부모 인덱스 저장
            int parant = (child - 1) / 2;

            //값 비교후 더 낮으면 스왑
            if (Heap[child].TPCount < Heap[parant].TPCount)
            {
                Swap(parant, child);
                index = parant;
            }
            else
            {
                break;
            }
        }
    }

    public Entity Dequeue()
    {
        if (Heap.Count == 0)
        {
            throw new ApplicationException("자료가 없습니다");
        }

        //리턴할 데이터 저장
        Entity data = Heap[0];

        //마지막 데이터를 0에다 저장
        Heap[0] = Heap[Heap.Count() - 1];
        //마지막 인덱스 삭제
        Heap.RemoveAt(Heap.Count() - 1);

        //마지막 데이터를 넣은 root인덱스 저장
        int parant = 0;
        //현재 채워져있는 Count 저장
        int index = Heap.Count() - 1;

        while (parant <= index)
        {
            // 일단 왼쪽 child 인데스 저장
            int child = (parant * 2) + 1;

            // child인덱스가 원래 크기보다 크면 브레이크
            if (child > index)
            {
                break;
            }

            // 오른쪽 child가 index값이랑 같거나 작고 왼쪽 child보다 작으면 오른쪽 child로 경로 변경
            if (child + 1 <= index && Heap[child].TPCount > Heap[child + 1].TPCount)
            {
                child++;
            }

            // 현재 child에 저장된 값과 parant값을 비교후 더 작으면 스왑 후 변경된 값과 그 child들과 다시 비교하기 위해
            // parant를 child 값으로 변경
            if (Heap[parant].TPCount > Heap[child].TPCount)
            {
                Swap(parant, child);
                parant = child;
            }
            // 더 작으면 종료
            else
            {
                break;
            }
        }

        // 우선순위 값 반환
        return data;
    }

    public Entity Peek()
    {
        if (Heap.Count == 0)
        {
            throw new ApplicationException("자료가 없습니다");
        }


        Entity peekData = Heap[0];

        return peekData;
    }

    public void DebugHeap()
    {
        /*
        foreach (int i in Heap)
        {
            Console.Write($"{i} ");
        }
        */
    }

    public void Swap(int parant, int child)
    {
        Entity temp = Heap[parant];
        Heap[parant] = Heap[child];
        Heap[child] = temp;
    }
}