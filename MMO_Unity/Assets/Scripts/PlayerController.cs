using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float _speed = 10.0f;
    float _yAngle = 0.0f;
    float _rotateSpd = 100.0f;
    void Start()
    {
        // Ȥ�ö� �Ǽ��� �ٸ� �κп��� KeyAction���ٰ� OnKeyboard �� �� ȣ��Ǳ� ������ �̸� �����ϱ� ���ؼ� -�� ����
        Managers.Input.KeyAction -= OnKeyboard;
        Managers.Input.KeyAction += OnKeyboard;
        // Input Manager���� Ȥ�ö� � Ű�� ������ OnKeyboard �Լ��� ȣ���ϰ� �������
    }
  
    void Update()
    {
        
    }
    
    void OnKeyboard()
    {
        _yAngle += Time.deltaTime * _rotateSpd;

        if (Input.GetKey(KeyCode.W))
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.forward), 0.3f);
            transform.position += Vector3.forward * Time.deltaTime * _speed;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.left), 0.3f);
            transform.position += Vector3.left * Time.deltaTime * _speed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.back), 0.3f);
            transform.position += Vector3.back * Time.deltaTime * _speed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.right), 0.3f);
            transform.position += Vector3.right * Time.deltaTime * _speed;
        }
    }
}