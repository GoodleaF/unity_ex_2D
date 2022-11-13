using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigid2D;
    Animator animator;
    float jumpForce = 680.0f;
    float walkForce = 30.0f;
    float maxWalkSpeed = 1.8f;
    //스마트폰의 기울기로 조작 변경
    float threshold = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        this.rigid2D = GetComponent<Rigidbody2D>();
        this.animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //점프
        //if (Input.GetKeyDown(KeyCode.Space) && this.rigid2D.velocity.y == 0)//컴퓨터버전
        if (Input.GetMouseButtonDown(0) && this.rigid2D.velocity.y == 0)
        {
            this.rigid2D.AddForce(transform.up * this.jumpForce);
            //점프 애니메이션 추가
            this.animator.SetTrigger("JumpTrigger");
        }

        //좌우 이동
        int key = 0;
        //if (Input.GetKey(KeyCode.RightArrow)) key = 1;
        //if (Input.GetKey(KeyCode.LeftArrow)) key = -1;
        if (Input.acceleration.x > this.threshold + 0.1f) key = 1;
        if (Input.acceleration.x < this.threshold - 0.1f) key = -1;

        //플레이어 속도
        float speedx = Mathf.Abs(this.rigid2D.velocity.x);

        //스피드 제한
        if (speedx < this.maxWalkSpeed)
        {
            this.rigid2D.AddForce(transform.right * key * this.walkForce);
        }

        //캐릭터 방향 전환
        if (key != 0)
        {
            transform.localScale = new Vector3(key, 1, 1);
        }

        //플레이어 속도에 맞춰서 애니메이션 속도 조절
        if(this.rigid2D.velocity.y == 0)
        {
            this.animator.speed = speedx / 2.0f;
        }
        else
        {
            this.animator.speed = 1.0f;
        }
        

        //추락시 게임 재시작
        if(transform.position.y < -10)
        {
            SceneManager.LoadScene("GameScene");
        }
    }

    //깃발에 닿아 트리거 발생 시
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Goal!");
        SceneManager.LoadScene("ClearScene");
    }
}
