using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeMove : MonoBehaviour
{
    public Rigidbody2D bee; //Rigidbody2D 속성 변수 생성
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(MoveObject()); //MoveObject() 코루틴 함수 이용
    }

    IEnumerator MoveObject()
    {
        bee = GetComponent<Rigidbody2D>(); // bee 변수를 Rigidbody2D 속성으로 초기화

        while (true)
        {
            float dir1 = Random.Range(-10.0f, 10.0f); //x축에 넣을 변수 범위 안에서 랜덤 생성
            float dir2 = Random.Range(-10.0f, 10.0f); //y축에 넣을 변수 범위 안에서 랜덤 생성
            float dir3 = Random.Range(-10.0f, 10.0f); //z축에 넣을 변수 범위 안에서 랜덤 생성

            yield return new WaitForSeconds(0.5f); //0.5초 간격으로 이동
            bee.velocity = new Vector3(dir1, dir2, dir3); //랜덤값을 bee의 속도에 대입
        }
    }
}
