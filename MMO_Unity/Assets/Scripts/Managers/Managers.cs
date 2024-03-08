using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : MonoBehaviour
{
    static Managers Instance; // ���ϼ� ����
    static Managers GetInstance() { Init(); return Instance; } // ������ �Ŵ����� ���� ��
                                                                      // Init()�� �־ ��. init() �Լ����� null���� üũ���ֱ� ������
                                                                      // �ܺο��� Instance�� �����ϴ� ���� ������ �ʱ� ������ public X
    InputManager _input = new InputManager(); // InputManager �߰�
    public static InputManager Input { get { return GetInstance()._input ; } } //  ������ InputManager�� ����ϰ� ������ Managers.Input�� ����Ͽ� �ҷ�����


    void Start()
    {
        Init();
    }
    
    void Update()
    {
        _input.OnUpdate(); // ���콺�� Ű���带 üũ�ϴ� �κ��� Update���� �� Update���� ��ǥ�� �� �Ŵ�������� �ϴ� �ְ� ���ִ� ����
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