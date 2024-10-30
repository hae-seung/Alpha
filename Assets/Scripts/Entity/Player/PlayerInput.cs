using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
   public Vector2 MoveDirection { get; private set; }

   void Update()
   {
      // 수평(horizontal) 및 수직(vertical) 입력을 받아 Vector2로 저장
      float horizontal = Input.GetAxisRaw("Horizontal"); // 왼쪽(-1)과 오른쪽(1)
      float vertical = Input.GetAxisRaw("Vertical");     // 아래(-1)와 위(1)
        
      MoveDirection = new Vector2(horizontal, vertical).normalized;
   }
}
