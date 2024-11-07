using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEntity : Entity
{
    public Weapon[] weapons; // 사용 가능한 무기 목록

    public override IEnumerator ActiveSkill()
    {
        Debug.Log("적 스킬 발동!");
        yield return OperateSkill();
        
    }

    public override IEnumerator GetTurn()
    {
        SelectNextSkill();
        yield return new WaitForSeconds(0.2f);
        Debug.Log("적 스킬 선택 완료.");
    }

    private IEnumerator OperateSkill()
    {
        //애니메이션 작동
        //이펙트 생성
        yield return new WaitForSeconds(0.2f);                                        // 애니메이션 출력 코루틴을 기점으로 작동
                                                            // 다음 스킬 선택
    }

    private void SelectNextSkill()
    {
        int weaponIndex = Random.Range(0, weapons.Length - 1);
        int skillIndex = Random.Range(0, weapons[weaponIndex].skills.Length);
        nextSkill = weapons[weaponIndex].skills[skillIndex];
    }

    void OnMouseDown()
    {
        // 이 오브젝트가 타겟으로 선택됨
        if (!PlayerEntity.phase1Flag && PlayerEntity.phase2Flag)
        {
            Debug.Log("타겟 선택됨: " + gameObject.name);
            PlayerEntity.phase2Flag = false;
        }


        // 타겟을 표시하거나 선택 상태를 업데이트하는 로직을 추가
    }
}
