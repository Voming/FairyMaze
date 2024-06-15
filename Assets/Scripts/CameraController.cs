using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    GameObject player; // GameObject 속성 변수 생성

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player"); //Player를 찾아서 player로 초기화
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPos = player.transform.position; //player의 위치 받아오는 변수 생성

        transform.position = new Vector3( playerPos.x, playerPos.y, transform.position.z); //player의 x,y값에 따라 카메라 이동


    }
}
