using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PriorityQueue
{
    //�� �ڷ� �����͸� ���� List �߰�
    List<Entity> Heap;


    //�� �ڷ� ����
    public PriorityQueue()
    {
        Heap = new List<Entity>();
    }


    //Enqueue ��� �켱���� ť�� �����͸� ���ڰ����� ����
    public void Enqueue(Entity data)
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
            throw new ApplicationException("�ڷᰡ �����ϴ�");
        }

        //������ ������ ����
        Entity data = Heap[0];

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
            if (child + 1 <= index && Heap[child].TPCount > Heap[child + 1].TPCount)
            {
                child++;
            }

            // ���� child�� ����� ���� parant���� ���� �� ������ ���� �� ����� ���� �� child��� �ٽ� ���ϱ� ����
            // parant�� child ������ ����
            if (Heap[parant].TPCount > Heap[child].TPCount)
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

    public Entity Peek()
    {
        if (Heap.Count == 0)
        {
            throw new ApplicationException("�ڷᰡ �����ϴ�");
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

    public List<Entity> PeekTopN(int n)
    {
        // ���� ����ִ� ��� ���� ó��
        if (Heap.Count == 0)
        {
            throw new ApplicationException("�ڷᰡ �����ϴ�.");
        }

        // ���纻 �� ���� (������ �������� �ʱ� ����)
        List<Entity> tempHeap = new List<Entity>(Heap);

        // ���� N���� ������ ����Ʈ
        List<Entity> topEntities = new List<Entity>();

        // ����� ������ N�� pop ����
        for (int i = 0; i < n && tempHeap.Count > 0; i++)
        {
            // ��Ʈ �����͸� ������
            Entity top = tempHeap[0];
            topEntities.Add(top);

            // ���� ������ �����͸� ��Ʈ�� ����
            tempHeap[0] = tempHeap[tempHeap.Count - 1];
            tempHeap.RemoveAt(tempHeap.Count - 1);

            // �� ���� (MinHeap ����)
            int parent = 0;
            int count = tempHeap.Count;

            while (true)
            {
                int leftChild = (parent * 2) + 1;
                int rightChild = (parent * 2) + 2;
                int smallest = parent;

                // ���� �ڽİ� ��
                if (leftChild < count && tempHeap[leftChild].TPCount < tempHeap[smallest].TPCount)
                {
                    smallest = leftChild;
                }

                // ������ �ڽİ� ��
                if (rightChild < count && tempHeap[rightChild].TPCount < tempHeap[smallest].TPCount)
                {
                    smallest = rightChild;
                }

                // �� �̻� ������ �ʿ� ������ ����
                if (smallest == parent)
                {
                    break;
                }

                // ���� ����
                Entity temp = tempHeap[parent];
                tempHeap[parent] = tempHeap[smallest];
                tempHeap[smallest] = temp;
                parent = smallest;
            }
        }

        return topEntities;
    }

    public void Swap(int parant, int child)
    {
        Entity temp = Heap[parant];
        Heap[parant] = Heap[child];
        Heap[child] = temp;
    }
}