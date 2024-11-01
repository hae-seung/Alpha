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
    //�� �ڷ� �����͸� ���� List �߰�
    List<Skill> Heap;


    //�� �ڷ� ����
    public PriorityQueue()
    {
        Heap = new List<Skill>();

    }


    //Enqueue ��� �켱���� ť�� �����͸� ���ڰ����� ����
    public void Enqueue(Skill data)
    {
        // list�� ������ �߰�
        Heap.Add(data);

        // ���� ����Ʈ ũ�� Ȯ�� Ž��
        int index = Heap.Count() - 1;

        // MinHeap���� ����
        while (index > 0)
        {
            //���� ���� ������ ���ϵ� �˻�
            int child = index;

            //�θ� �ε��� ����
            int parant = (child - 1) / 2;

            //�� ���� �� ������ ����
            if (Heap[child].TP < Heap[parant].TP)
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

    public Skill Dequeue()
    {
        if (Heap.Count == 0)
        {
            throw new ApplicationException("�ڷᰡ �����ϴ�");
        }

        //������ ������ ����
        Skill data = Heap[0];

        //������ �����͸� 0���� ����
        Heap[0] = Heap[Heap.Count() - 1];
        //������ �ε��� ����
        Heap.RemoveAt(Heap.Count() - 1);

        //������ �����͸� ���� root�ε��� ����
        int parant = 0;
        //���� ä�����ִ� Count ����
        int index = Heap.Count() - 1;

        while (parant <= index)
        {
            // �ϴ� ���� child �ε��� ����
            int child = (parant * 2) + 1;

            // child�ε����� ���� ũ�⺸�� ũ�� �극��ũ
            if (child > index)
            {
                break;
            }

            // ������ child�� index���̶� ���ų� �۰� ���� child���� ������ ������ child�� ��� ����
            if (child + 1 <= index && Heap[child].TP > Heap[child + 1].TP)
            {
                child++;
            }

            // ���� child�� ����� ���� parant���� ���� �� ������ ���� �� ����� ���� �� child��� �ٽ� ���ϱ� ����
            // parant�� child ������ ����
            if (Heap[parant].TP > Heap[child].TP)
            {
                Swap(parant, child);
                parant = child;
            }
            // �� ������ ����
            else
            {
                break;
            }
        }

        // �켱���� �� ��ȯ
        return data;
    }

    public Skill Peek()
    {
        if (Heap.Count == 0)
        {
            throw new ApplicationException("�ڷᰡ �����ϴ�");
        }


        Skill peekData = Heap[0];

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
        Skill temp = Heap[parant];
        Heap[parant] = Heap[child];
        Heap[child] = temp;
    }
}