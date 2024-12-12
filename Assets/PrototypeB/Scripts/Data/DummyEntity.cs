using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyEntity : Entity
{
    public override IEnumerator ActiveSkill()
    {
        yield return OperateSkill();
        Debug.Log("지속 스킬 발동!");
    }

    private IEnumerator OperateSkill()
    {
        //애니메이션 작동
        //이펙트 생성
        yield return new WaitForSeconds(0.2f);                                        // 애니메이션 출력 코루틴을 기점으로 작동
                                                                                      // 다음 스킬 선택
    }
}
