using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Vector��� ���� float�� 3������ ������ �ִ� ������ ����ü�̴�.
// ����ϴ� �Ϳ� ���� ��ġ ����, ���� ���ͷ� ������.
// ��ġ ���ʹ� ��ǥ�� �־ ���ϰ� ���� ����ϸ� �ǰ�
// �� ���� ������ ������ ����Ͽ� ���� ���͸� ������ �� �ִµ�, ���� ���ʹ� �Ÿ��� ���� ������ ���� ����.
// ���� magnitude�� normalized��� ����� �̿��� �Ÿ��� ���� ������ ������ ������ �� ����
// normalized : ����Ű�� ������ �Ȱ��� ũ�Ⱑ 1�� ���͸� ��ȯ
// dir = to - from�� �̿��ϸ� _speed�ų� �ٸ� ���ϴ� ��ġ�� ���ؼ� ���� �������� �̵��ϴ� �׷� �ൿ���� ���� ���� ����

// 1. ��ġ ����
// 2. ���� ����
struct MyVector
{
    public float x;
    public float y;
    public float z;

    // ��Ÿ����� ���� �̿� z^2 = x^2 + y^2
    //                         +
    //          +             +
    // +-------------+
    public float magnitude { get { return Mathf.Sqrt(x * x + y * y + z * z); } }
    // x * X + y * y�� �ϸ� ������ ������ �� ���� ���� ���̰�, ����ٰ� ��Ÿ��󽺸� �� �� �� �ؼ� z*2���� �ϸ� �� �� ������ �Ÿ��� ����
    // �� ���⺤���� ũ�Ⱑ ����
    // ������ �ϴ� ���� �ƴ϶� �ڱ� �ڽ��� ���ϱ� ������ ��Ʈ�� ������

    public MyVector normalized { get { return new MyVector( x / magnitude, y / magnitude, z / magnitude ); } }
    // �ڱ� �ڽſ� �ִ� ��� ���� magnitude�� �����ָ� ��
    // �̷��� �� ��쿡�� ������ ������, ������ ����� ����غ��� 1�� Ƣ����� ���Ͱ� ��

    public MyVector(float x, float y, float z) {  this.x = x; this.y = y; this.z = z; }

    public static MyVector operator +(MyVector a, MyVector b)
    {
        return new MyVector ( a.x + b.x, a.y + b.y, a.z + b.z );
    }
    public static MyVector operator -(MyVector a, MyVector b)
    {
        return new MyVector(a.x - b.x, a.y - b.y, a.z - b.z);
    }

    public static MyVector operator *(MyVector a, float d)
    {
        return new MyVector(a.x * d, a.y * d, a.z * d);
    }
}

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float _speed = 10.0f;
    void Start()
    {
        // MyVector pos = new MyVector(0.0f, 10.0f, 0.0f);
        // pos += new MyVector(0.0f, 2.0f, 0.0f);
        MyVector to = new MyVector(10.0f, 0.0f, 0.0f);
        MyVector from = new MyVector(5.0f, 0.0f, 0.0f);
        MyVector dir = to - from; // (5.0f, 0.0f, 0.0f)

        dir = dir.normalized; // (1.0f, 0.0f, 0.0f)

        MyVector newPos = from + dir * _speed;
        // from�̶�� ������ ���ϴ� �������� speed��ŭ �̵��� �� ���� ���� �� ����

        // ���� ����
            // 1. �Ÿ�(ũ��)        5       magnitude
            // 2. ���� ����         ->      normalized
    }

    // GameObject (Player)
        // Transform
        // PlayerController (*)
    void Update()
    {
        // Local -> World
        // TransformDirection

        // World -> Local
        // InverseTransformDirection
        // transform.position += new Vector3(1.0f, 1.0f, 1.0f);
        //transform.position.magnitude // ������ ũ�� ��ȯ
        // transform.position.normalized // �� �����ε� magnitude�� 1�� ���͸� ��ȯ

        if (Input.GetKey(KeyCode.W))
            transform.Translate(Vector3.forward * Time.deltaTime * _speed);
        if (Input.GetKey(KeyCode.S))
            transform.Translate(Vector3.back * Time.deltaTime * _speed);
        if (Input.GetKey(KeyCode.D))
            transform.Translate(Vector3.right * Time.deltaTime * _speed);
        if (Input.GetKey(KeyCode.A))
            transform.Translate(Vector3.left * Time.deltaTime * _speed);
        // transform.TransformDirection() ��ſ� transform.Translate() ��� ����

        // forward, back, right, left ��� ���������� 0, 0, 1�� normalize�� �� ���͸� �������Ͷ�� ��
        // �̷��� ũ�Ⱑ 1�� ���ʹ� �� ������ ũ��� ������ä ���⿡ ���� ������ ���� ������
        //���ϴ� �Ÿ���ŭ ũ�⸦ �����ָ� ��Ȯ�ϰ� �� �������� �� ũ�⸸ŭ �̵��� �� ����

    }
}