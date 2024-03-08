using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ���� : üũ�ϴ� �κ��� �����ϰ� ��. �������� �� �� ���� üũ�ϰ� �Ǿ� �� �̺�Ʈ�� �����ϴ� ���
// ���࿡ �츮�� ���� Update�����ٰ� Ű���带 üũ�ϴ� �κ��� ����� �� ���ڰ� �������� ��𿡼� ����ü Ű���� �Է��� �޾Ҵ��� ã�Ⱑ �������

public class InputManager
{
    public Action KeyAction = null; // using System;�� �ۼ��ؾ��� ��� ���� // ������ delegate

    // Update������ InputManager�� ��ǥ�� �Է��� üũ�� ���� ������ �Է��� �־����� �̺�Ʈ�� �����ϴ� �������� ����
    // �̰��� �������� ������ ���� �� �ϳ��� ������ ����
    public void OnUpdate() // MonoBehaviour�� ������ �Ǵ� ���� �ƴ϶� �������� ���� �ҷ���� �ϱ� ������ On�ٿ��༭ ǥ������
    {
        if (Input.anyKey == false)
            return;

        
        if (KeyAction != null)
            KeyAction.Invoke();// �̷������� �̺�Ʈ ������� ó���ϸ� ����ٰ� break����Ʈ�� ��Ƽ� ���� ����ü �� �̺�Ʈ�� �޴��� Ű���带 ������ �� ���� ������ �ƴ��� ã�� �� ����
             // KeyAction�� �־��ٰ� ���ĸ� ��    
    }
}
