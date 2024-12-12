using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TurnPreview : MonoBehaviour
{
    public GameObject TurnPreviewContiner;
    public GameObject TurnPreviewPrefab;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdatePreviewUI(List<Entity> Top6)
    {
        // 기존 UI 클리어
        foreach (Transform child in TurnPreviewContiner.transform)
            Destroy(child.gameObject);

        //Weapon currentWeapon = weapons[currentWeaponIndex];
        foreach (Entity _Entity in Top6)
        {
            GameObject _TurnPreviewPrefab = Instantiate(TurnPreviewPrefab, TurnPreviewContiner.transform);
            if(_Entity.TryGetComponent<DummyEntity>(out DummyEntity script))
            {
                _TurnPreviewPrefab.GetComponentInChildren<TextMeshProUGUI>().text = _Entity.nextSkill.name;
            }
            else
            {
                _TurnPreviewPrefab.GetComponentInChildren<TextMeshProUGUI>().text = _Entity.Name;
            }
        }
    }
}
