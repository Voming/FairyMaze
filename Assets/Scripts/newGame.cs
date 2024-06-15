using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class newGame : MonoBehaviour //게임 재시작 
{
    public void NewGame()
    {
        SceneManager.LoadScene("Scene1"); //버튼 클릭 시Scene1화면으로 이동
    }
}
