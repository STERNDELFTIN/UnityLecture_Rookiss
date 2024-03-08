using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : MonoBehaviour
{
    static Managers Instance; // 유일성 보장
    static Managers GetInstance() { Init(); return Instance; } // 유일한 매니저를 갖고 옴
                                                                      // Init()만 넣어도 됨. init() 함수에서 null인지 체크해주기 때문에
                                                                      // 외부에서 Instance를 접근하는 것을 원하지 않기 때문에 public X
    InputManager _input = new InputManager(); // InputManager 추가
    public static InputManager Input { get { return GetInstance()._input ; } } //  실제로 InputManager을 사용하고 싶으면 Managers.Input을 사용하여 불러오기


    void Start()
    {
        Init();
    }
    
    void Update()
    {
        _input.OnUpdate(); // 마우스나 키보드를 체크하던 부분을 Update문을 이 Update문이 대표로 이 매니저스라고 하는 애가 해주는 셈임
    }

    static void Init()
    {
        if (Instance == null)
        {
            // 초기화
            GameObject go = GameObject.Find("@Managers");
            // "@Managers"라는 객체가 있는지 게임오브젝트가 있는지 확인
            if (go == null) // 생성한 적이 없으면? 코드상으로 생성
            {
                go = new GameObject { name = "@Managers" }; // 빈 오브젝트에 이름만
                go.AddComponent<Managers>(); // Managers라는 부품을 붙여줌
            }
            DontDestroyOnLoad(go); // 웬만해선 삭제되지 않게 변경됨
            Instance = go.GetComponent<Managers>();
        }
    }
}