using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    Animator animator; // Animator 속성 변수 생성
    public SpriteRenderer rend; // SpriteRenderer 속성 변수 생성


    public int health; //체력 
    public int numofHearts; //하트개수

    public Image[] hearts; //하트 이미지 배열
    public Sprite fullHeart; //채워진하트 이미지 넣을 것
    public Sprite emptyHeart; //빈하트 이미지 넣을 것

    public GameObject obj; // GameObject 속성 변수 생성
   
    public AudioSource beeaudio; //AudioSource 속성 변수 생성
    public AudioSource floweraudio; //AudioSource 속성 변수 생성
    public AudioSource drinkaudio; //AudioSource 속성 변수 생성

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>(); // animator 변수를 Player의 Animator 속성으로 초기화
        rend = GetComponent<SpriteRenderer>(); // rend 변수를 Player의 SpriteRenderer 속성으로 초기화
    }

    // Update is called once per frame
    void Update()
    {
        animator.speed = 0.0f; //애니메이션 실행안함

        if (Input.GetKey(KeyCode.UpArrow)) //위 화살표 누르면 
        {
            transform.Translate(0, 0.3f, 0); //위로 이동
            animator.SetTrigger("BackTrigger"); //back 애니메이션으로 전환 트리거 실행
            animator.speed = 1.0f; //walk 애니메이션 속도 2.0f로 실행
        }
        if (Input.GetKey(KeyCode.DownArrow)) //아래 화살표 누르면 
        {
            transform.Translate(0, -0.3f, 0); //아래로 이동
            animator.SetTrigger("BackTrigger"); //back 애니메이션으로 전환 트리거 실행
            animator.speed = 1.0f; //walk 애니메이션 속도 2.0f로 실행
        }
        if (Input.GetKey(KeyCode.RightArrow)) //오른쪽 화살표 누르면
        {
            transform.Translate(0.3f, 0, 0); //오른쪽으로 이동
            rend.flipX = false; //애니메이션 좌우 반전 안함
            animator.speed = 2.0f; //walk 애니메이션 속도 2.0f로 실행
        }
        if (Input.GetKey(KeyCode.LeftArrow)) //왼쪽 화살표 누르면 
        {
            transform.Translate(-0.3f, 0, 0); //왼쪽으로 이동
            rend.flipX = true; //애니메이션 좌우 반전함
            animator.speed = 2.0f; //walk 애니메이션 속도 2.0f로 실행
        }



        if (health > numofHearts)
        {
            health = numofHearts; //health 수가 numofHearts보다 많으면 numofHearts로 줄임
        }

        for (int i = 0; i < hearts.Length; i++) //체력 수 많큼 반복
        {
            if (i < health)
            {
                hearts[i].sprite = fullHeart; //채워진하트를 넣음
            }
            else
            {
                hearts[i].sprite = emptyHeart; //깎인 체력만큼 빈 하트를 넣음
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name.Contains("exit1") || collision.name.Contains("exit2")) //exit1, exit2와 충돌했다면
        {
            SceneManager.LoadScene("Scene3"); //Scene3로 이동
        }
        if (collision.name.Contains("exit3") || collision.name.Contains("exit4")) //exit3, exit4와 충돌했다면
        {
            SceneManager.LoadScene("Scene4"); //Scene4로 이동
        }
        if (collision.name.Contains("exit5") || collision.name.Contains("exit6")) //exit5, exit6와 충돌했다면
        {
            SceneManager.LoadScene("Clear"); //Clear로 이동
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bee") //Bee 태그를 가진것과 충돌했다면
        {
            Debug.Log("충돌"); //콘솔창에 "충돌" 출력
            health -= 1; //health 1감소
            beeaudio.Play(); //beeaudio 재생
            if (health < 0) //health가 0보다 작다면 
            {
                SceneManager.LoadScene("GameOver"); //GameOver씬으로 이동
            }
        }
        if (collision.gameObject.tag == "Drink") //Drink 태그를 가진것과 충돌했다면
        {
            Debug.Log("충돌"); //콘솔창에 "충돌" 출력
            health += 1; //health 1증가
            drinkaudio.Play(); //drinkaudio 재생
        }
        if (collision.gameObject.tag == "Flower") //Flower 태그를 가진것과 충돌했다면
        {
            Debug.Log("충돌"); //콘솔창에 "충돌" 출력
            health -= 1; //health 1감소
            floweraudio.Play(); //floweraudio 재생
            if (health < 0) //health가 0보다 작다면 
            {
                SceneManager.LoadScene("GameOver"); //GameOver씬으로 이동
            }
        }
    }
}
