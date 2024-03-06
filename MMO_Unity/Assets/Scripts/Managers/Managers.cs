using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : MonoBehaviour
{
    static Managers Instance; // 유일성 보장
    public static Managers GetInstance() { Init(); return Instance; } // 유일한 매니저를 갖고 옴
                                                                      // Init()만 넣어도 됨. init() 함수에서 null인지 체크해주기 때문에
    void Start()
    {
        Init();
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