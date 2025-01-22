using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public abstract class EquipSlotHolder : MonoBehaviour
{
    private GraphicRaycaster _gr;
    private PointerEventData _ped;
    private List<RaycastResult> _rrList;

    private EquipSlot _raySlot;
    private EquipSlot _currentSlot;  // 현재 마우스가 올라간 슬롯 추적
    
    private float lastClickTime = 0f;
    private float doubleClickThreshold = 0.3f;  // 더블클릭 간격
    
    
    public abstract void WearItem(Item item, string weaponSlot = null);
    public abstract void UnWearItem(Item item, string weaponSlot = null); //마우스 우클릭으로 해제될때
    
    private void Start()
    {
        _gr = GetComponent<GraphicRaycaster>();
        _ped = new PointerEventData(EventSystem.current);
        _rrList = new List<RaycastResult>();

        _raySlot = null;
        _currentSlot = null;
    }
    
    private void Update()
    {
        _ped.position = Input.mousePosition;

        HandlePointerEnterExit();
        HandleMouseInput();
    }
    
    private T RaycastAndGetFirstComponent<T>() where T : Component
    {
        _rrList.Clear();

        _gr.Raycast(_ped, _rrList);
        
        if(_rrList.Count == 0)
            return null;

        return _rrList[0].gameObject.GetComponent<T>();
    }

    private void HandleMouseInput()
    {
        if (Input.GetMouseButtonDown(0))
            HandleDoubleClick();

        if (Input.GetMouseButtonDown(1))
            HandleRightClick();
    }

    private void HandleRightClick()
    {
        Debug.Log("우클릭!");
        _raySlot = RaycastAndGetFirstComponent<EquipSlot>();

        if (_raySlot != null)
        {
            Debug.Log("있다!");
            UnEquipItem(_raySlot);
        }
        
    }

    private void HandleDoubleClick()
    {
        _raySlot = RaycastAndGetFirstComponent<EquipSlot>();

        if (_raySlot != null)
        {
            float timeSinceLastClick = Time.time - lastClickTime;
            if (timeSinceLastClick <= doubleClickThreshold)
            {
                UnEquipItem(_raySlot); // 더블클릭 시 아이템 사용/장착
            }

            lastClickTime = Time.time; // 클릭 시간 업데이트
        }
    }

    private void HandlePointerEnterExit()
    {
        _raySlot = RaycastAndGetFirstComponent<EquipSlot>();

        if (_raySlot != _currentSlot)
        {
            // 이전 슬롯에서 나갈 때 원래 색상 복원
            if (_currentSlot != null)
            {
                _currentSlot.Highlight(false);
            }

            // 새 슬롯에 들어갔을 때 색상 변경
            if (_raySlot != null)
            {
                _raySlot.Highlight(true);
            }

            _currentSlot = _raySlot;  // 현재 슬롯 업데이트
        }
    }
    protected void EndSlotUsage(EquipSlot slot)
    {
        slot.EndSlotUsage();
    }
    
    private void UnEquipItem(EquipSlot slot)
    {
        Item item = slot.GetItem();
        
        if (item == null)
            return;

        if (item is IEquippable equipItem)
        {
            equipItem.UnEquipItem(item);//딕셔너리 제거 + UI 제거
        }
    }
    
}

