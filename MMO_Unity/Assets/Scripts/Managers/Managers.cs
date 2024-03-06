using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : MonoBehaviour
{
    static Managers Instance; // ���ϼ� ����
    public static Managers GetInstance() { Init(); return Instance; } // ������ �Ŵ����� ���� ��
                                                                      // Init()�� �־ ��. init() �Լ����� null���� üũ���ֱ� ������
    void Start()
    {
        Init();
    }
    static void Init()
    {
        if (Instance == null)
        {
            // �ʱ�ȭ
            GameObject go = GameObject.Find("@Managers");
            // "@Managers"��� ��ü�� �ִ��� ���ӿ�����Ʈ�� �ִ��� Ȯ��
            if (go == null) // ������ ���� ������? �ڵ������ ����
            {
                go = new GameObject { name = "@Managers" }; // �� ������Ʈ�� �̸���
                go.AddComponent<Managers>(); // Managers��� ��ǰ�� �ٿ���
            }
            DontDestroyOnLoad(go); // �����ؼ� �������� �ʰ� �����
            Instance = go.GetComponent<Managers>();
        }
    }
}