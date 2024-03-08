using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 장점 : 체크하는 부분이 유일하게 됨. 루프마다 한 번 씩만 체크하게 되어 그 이벤트를 전파하는 방식
// 만약에 우리가 직접 Update문에다가 키보드를 체크하는 부분을 만들면 그 숫자가 많아지면 어디에서 도대체 키보드 입력을 받았는지 찾기가 힘들어짐

public class InputManager
{
    public Action KeyAction = null; // using System;을 작성해야지 사용 가능 // 일종의 delegate

    // Update문에서 InputManager가 대표로 입력을 체크한 다음 실제로 입력이 있었으면 이벤트로 전파하는 형식으로 구현
    // 이것이 전형적인 디자인 패턴 중 하나인 리스너 패턴
    public void OnUpdate() // MonoBehaviour로 실행이 되는 것이 아니라 누군가가 직접 불러줘야 하기 때문에 On붙여줘서 표시했음
    {
        if (Input.anyKey == false)
            return;

        
        if (KeyAction != null)
            KeyAction.Invoke();// 이런식으로 이벤트 방식으로 처리하면 여기다가 break포인트를 잡아서 누가 도대체 이 이벤트를 받는지 키보드를 눌렀을 때 누가 실행이 됐는지 찾을 수 있음
             // KeyAction이 있었다고 전파를 함    
    }
}
