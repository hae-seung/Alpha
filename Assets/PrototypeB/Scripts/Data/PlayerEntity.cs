using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerEntity : Entity
{
    public Weapon[] weapons; // 사용 가능한 무기 목록
    public Weapon nowWeapon;
    //public Transform skillContainer; // 스킬 UI가 배치되는 ScrollRect의 컨테이너
    public GameObject phase1UI;
    public GameObject skillContainer;
    public GameObject skillUIPrefab; // 스킬을 표현할 UI 프리팹

    public static Skill selectedPhase1Skill;

    private int currentWeaponIndex = 0;

    public bool endTurn = false;

    void Start()
    {
        nowWeapon = weapons[0];
        Name = "Player";
        //UpdateSkillUI();
    }

    public override IEnumerator ActiveSkill()
    {
        yield return OperateSkill();
        Debug.Log("플레이어 스킬 발동!");
    }

    private IEnumerator OperateSkill()
    {
        //애니메이션 작동
        //이펙트 생성
        yield return new WaitForSeconds(0.2f);                                        // 애니메이션 출력 코루틴을 기점으로 작동
                                                                                      // 다음 스킬 선택
    }

    public override IEnumerator GetTurn()
    {
        yield return PlayerPhase();
        //Debug.Log("플레이어턴 받음!");
    }

    public IEnumerator PlayerPhase()
    {
        yield return StartCoroutine(PlayerPhase1());
        yield return StartCoroutine(PlayerPhase2());
    }

    public static bool phase1Flag = true;

    public IEnumerator PlayerPhase1()
    {
        phase1UI.SetActive(true);
        //skillContainer.SetActive(true);
        UpdateSkillUI();
        
        while (phase1Flag)
        {
            yield return new WaitForSeconds(0.1f);
        }
        
        phase1UI.SetActive(false);

        yield return new WaitForSeconds(0.1f);
    }

    public static bool phase2Flag = true;

    public IEnumerator PlayerPhase2()
    {
        //Debug.Log("페이즈 2 시작");
        while (phase2Flag)
        {
            yield return new WaitForSeconds(0.1f);
        }

        nextSkill = selectedPhase1Skill;

        phase1Flag = true;
        phase2Flag = true;

        yield return new WaitForSeconds(0.1f);
    }

    public void SwapWeapon()
    {
        currentWeaponIndex = (currentWeaponIndex + 1) % weapons.Length;
        nowWeapon = weapons[currentWeaponIndex];
        UpdateSkillUI();
    }

    
    private void UpdateSkillUI()
    {
        // 기존 UI 클리어
        foreach (Transform child in skillContainer.transform)
            Destroy(child.gameObject);

        //Weapon currentWeapon = weapons[currentWeaponIndex];
        foreach (Skill skill in nowWeapon.skills)
        {
            GameObject skillUI = Instantiate(skillUIPrefab, skillContainer.transform);
            skillUI.GetComponentInChildren<TextMeshProUGUI>().text = skill.skillName;
            skillUI.GetComponentInChildren<Image>().sprite = skill.icon;
            // 추가 설정이 필요하면 여기서 설정

            skillUI.GetComponent<ButtonEvent>().skill = skill;
        }
    }

    
}
