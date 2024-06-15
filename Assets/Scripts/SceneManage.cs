using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManage : MonoBehaviour
{
    public void SceneMange()
    {
        SceneManager.LoadScene("Scene2"); //버튼 클릭 시Scene2화면으로 이동
    }
}
