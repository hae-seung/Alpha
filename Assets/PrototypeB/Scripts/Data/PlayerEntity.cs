using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerEntity : Entity
{
    public Weapon[] weapons; // ��� ������ ���� ���
    public Weapon nowWeapon;
    //public Transform skillContainer; // ��ų UI�� ��ġ�Ǵ� ScrollRect�� �����̳�
    public GameObject phase1UI;
    public GameObject skillContainer;
    public GameObject skillUIPrefab; // ��ų�� ǥ���� UI ������

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
        Debug.Log("�÷��̾� ��ų �ߵ�!");
    }

    private IEnumerator OperateSkill()
    {
        //�ִϸ��̼� �۵�
        //����Ʈ ����
        yield return new WaitForSeconds(0.2f);                                        // �ִϸ��̼� ��� �ڷ�ƾ�� �������� �۵�
                                                                                      // ���� ��ų ����
    }

    public override IEnumerator GetTurn()
    {
        yield return PlayerPhase();
        //Debug.Log("�÷��̾��� ����!");
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
        //Debug.Log("������ 2 ����");
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
        // ���� UI Ŭ����
        foreach (Transform child in skillContainer.transform)
            Destroy(child.gameObject);

        //Weapon currentWeapon = weapons[currentWeaponIndex];
        foreach (Skill skill in nowWeapon.skills)
        {
            GameObject skillUI = Instantiate(skillUIPrefab, skillContainer.transform);
            skillUI.GetComponentInChildren<TextMeshProUGUI>().text = skill.skillName;
            skillUI.GetComponentInChildren<Image>().sprite = skill.icon;
            // �߰� ������ �ʿ��ϸ� ���⼭ ����

            skillUI.GetComponent<ButtonEvent>().skill = skill;
        }
    }

    
}
