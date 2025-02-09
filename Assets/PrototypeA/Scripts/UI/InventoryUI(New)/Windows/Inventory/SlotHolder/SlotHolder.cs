using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SlotHolder : MonoBehaviour
{
    public List<Slot> slots = new List<Slot>();
    public GameObject slotPrefab;
    public RectTransform rect;
    
    private int usingSlotCnt = 0;
    private int totalSlotCnt = 0;

    
    private GraphicRaycaster _gr;
    private PointerEventData _ped;
    private List<RaycastResult> _rrList;

    private Slot _raySlot;
    private Slot _currentSlot;  // 현재 마우스가 올라간 슬롯 추적
    
    private float lastClickTime = 0f;
    private float doubleClickThreshold = 0.3f;  // 더블클릭 간격
    
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
        _raySlot = RaycastAndGetFirstComponent<Slot>();

        if (_raySlot != null && _raySlot.IsUsing)
        {
            Debug.Log("있다!");
            EquipOrUseItem(_raySlot);
        }
        
    }

    private void HandleDoubleClick()
    {
        _raySlot = RaycastAndGetFirstComponent<Slot>();

        if (_raySlot != null && _raySlot.IsUsing)
        {
            float timeSinceLastClick = Time.time - lastClickTime;
            if (timeSinceLastClick <= doubleClickThreshold)
            {
                EquipOrUseItem(_raySlot); // 더블클릭 시 아이템 사용/장착
            }

            lastClickTime = Time.time; // 클릭 시간 업데이트
        }
    }

    private void HandlePointerEnterExit()
    {
        _raySlot = RaycastAndGetFirstComponent<Slot>();

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
    
    

    public void CreateNewItem(Item newItem)
    {
        if (totalSlotCnt == 0)
            totalSlotCnt = slots.Count;

        if (usingSlotCnt == totalSlotCnt)
        {
            Slot newSlot = Instantiate(slotPrefab, rect).GetComponent<Slot>();
            newSlot.SetUp(newItem);
            slots.Add(newSlot);
            totalSlotCnt++;
        }
        else
        {
            foreach (Slot slot in slots)
            {
                if (!slot.IsUsing)
                {
                    slot.SetUp(newItem);
                    break;
                }
            }
        }
        
        usingSlotCnt++;
    }

    public void RemoveItem(Item item)
    {
        foreach (var slot in slots)
        {
            if (slot.IsUsing && slot.GetItem().Equals(item))
            {
                EndSlotUsage(slot);
                break;
            }
        }
    }

    private void EndSlotUsage(Slot slot)
    {
        slot.EndSlotUsage();
        usingSlotCnt--;
    }
    
    private void EquipOrUseItem(Slot slot)
    {
        Item item = slot.GetItem();
        
        if (item == null)
        {
            Debug.LogError("Item is null in ItemUI.EquipOrUseItem.");
            return;
        }

        if (item is IUseable useableItem)//포션 아이템만 걸러짐
        {
            int amount = useableItem.Use();
            if (amount <= 0)
                item.RemoveItemFromInventory(item); //인벤토리 딕셔너리에서 아이템, UI 끄기
            else
                slot.UpdateCountText(amount);//text 수정(감소)
        }
        else if (item is IEquippable equipItem)
        {
            equipItem.EquipOrSwapItem(item);//딕셔너리 제거 + UI 끄기
        }
    }
}
