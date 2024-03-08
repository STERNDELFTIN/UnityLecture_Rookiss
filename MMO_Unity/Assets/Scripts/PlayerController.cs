using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Vector라는 것은 float을 3가지만 가지고 있는 간단한 구조체이다.
// 사용하는 것에 따라 위치 벡터, 방향 벡터로 나뉜다.
// 위치 벡터는 좌표를 넣어서 더하고 빼서 사용하면 되고
// 두 지점 사이의 뺄셈을 사용하여 방향 벡터를 추출할 수 있는데, 방향 벡터는 거리와 실제 방향을 갖고 있음.
// 각각 magnitude와 normalized라는 기능을 이용해 거리와 실제 방향의 정보를 추출할 수 있음
// normalized : 가리키는 방향은 똑같고 크기가 1인 벡터를 반환
// dir = to - from을 이용하면 _speed거나 다른 원하는 수치를 곱해서 그쪽 방향으로 이동하는 그런 행동들을 쉽게 구현 가능

// 1. 위치 벡터
// 2. 방향 벡터
struct MyVector
{
    public float x;
    public float y;
    public float z;

    // 피타고라스의 정리 이용 z^2 = x^2 + y^2
    //                         +
    //          +             +
    // +-------------+
    public float magnitude { get { return Mathf.Sqrt(x * x + y * y + z * z); } }
    // x * X + y * y를 하면 빗변의 제곱을 한 값이 나올 것이고, 여기다가 피타고라스를 한 번 더 해서 z*2까지 하면 두 점 사이의 거리가 나옴
    // 이 방향벡터의 크기가 나옴
    // 제곱을 하는 것이 아니라 자기 자신을 원하기 때문에 루트를 씌어줌

    public MyVector normalized { get { return new MyVector( x / magnitude, y / magnitude, z / magnitude ); } }
    // 자기 자신에 있는 모든 값을 magnitude로 나눠주면 됨
    // 이렇게 할 경우에는 방향은 같지만, 실제로 사이즈를 계산해보면 1이 튀어나오는 벡터가 됨

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
        // from이라는 점에서 원하는 방향으로 speed만큼 이동을 한 것을 만들 수 있음

        // 방향 벡터
            // 1. 거리(크기)        5       magnitude
            // 2. 실제 방향         ->      normalized
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
        //transform.position.magnitude // 벡터의 크기 반환
        // transform.position.normalized // 이 벡터인데 magnitude가 1인 벡터를 반환

        if (Input.GetKey(KeyCode.W))
            transform.Translate(Vector3.forward * Time.deltaTime * _speed);
        if (Input.GetKey(KeyCode.S))
            transform.Translate(Vector3.back * Time.deltaTime * _speed);
        if (Input.GetKey(KeyCode.D))
            transform.Translate(Vector3.right * Time.deltaTime * _speed);
        if (Input.GetKey(KeyCode.A))
            transform.Translate(Vector3.left * Time.deltaTime * _speed);
        // transform.TransformDirection() 대신에 transform.Translate() 사용 가능

        // forward, back, right, left 모두 단위벡터임 0, 0, 1임 normalize가 된 벡터를 단위벡터라고 함
        // 이렇게 크기가 1인 벡터는 그 방향의 크기는 무시한채 방향에 대한 정보만 추출 가능함
        //원하는 거리만큼 크기를 곱해주면 정확하게 그 방향으로 그 크기만큼 이동할 수 있음

    }
}