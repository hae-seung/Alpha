using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyEntity : Entity
{
    public override IEnumerator ActiveSkill()
    {
        yield return OperateSkill();
        Debug.Log("���� ��ų �ߵ�!");
    }

    private IEnumerator OperateSkill()
    {
        //�ִϸ��̼� �۵�
        //����Ʈ ����
        yield return new WaitForSeconds(0.2f);                                        // �ִϸ��̼� ��� �ڷ�ƾ�� �������� �۵�
                                                                                      // ���� ��ų ����
    }
}
