using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEntity : Entity
{
    public Weapon[] weapons; // ��� ������ ���� ���

    public override IEnumerator ActiveSkill()
    {
        Debug.Log("�� ��ų �ߵ�!");
        yield return OperateSkill();
        
    }

    public override IEnumerator GetTurn()
    {
        SelectNextSkill();
        yield return new WaitForSeconds(0.2f);
        Debug.Log("�� ��ų ���� �Ϸ�.");
    }

    private IEnumerator OperateSkill()
    {
        //�ִϸ��̼� �۵�
        //����Ʈ ����
        yield return new WaitForSeconds(0.2f);                                        // �ִϸ��̼� ��� �ڷ�ƾ�� �������� �۵�
                                                            // ���� ��ų ����
    }

    private void SelectNextSkill()
    {
        int weaponIndex = Random.Range(0, weapons.Length - 1);
        int skillIndex = Random.Range(0, weapons[weaponIndex].skills.Length);
        nextSkill = weapons[weaponIndex].skills[skillIndex];
    }

    void OnMouseDown()
    {
        // �� ������Ʈ�� Ÿ������ ���õ�
        if (!PlayerEntity.phase1Flag && PlayerEntity.phase2Flag)
        {
            Debug.Log("Ÿ�� ���õ�: " + gameObject.name);
            PlayerEntity.phase2Flag = false;
        }


        // Ÿ���� ǥ���ϰų� ���� ���¸� ������Ʈ�ϴ� ������ �߰�
    }
}
