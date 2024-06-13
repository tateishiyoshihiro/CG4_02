using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public Rigidbody rb;
    public GameObject bombParticle;
    public Animator animator;
    int moveSpeed = 10;
    private bool isBlock = true;
    private bool isJumping = false;
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        float stick = Input.GetAxis("Horizontal");
        if (GoalScript.isGameOver == false)
        {
            Vector3 v = rb.velocity;
            if (Input.GetKey(KeyCode.RightArrow)|| stick > 0)
            {
                transform.rotation = Quaternion.Euler(0, 90, 0);
                v.x = moveSpeed;
                animator.SetBool("mode", true);
            }
            else if (Input.GetKey(KeyCode.LeftArrow)|| stick < 0)
            {
                transform.rotation = Quaternion.Euler(0, -90, 0);
                v.x = -moveSpeed;
                animator.SetBool("mode", true);
            }
            else if (Input.GetKeyDown(KeyCode.Space)&&!isJumping)
            {
                v.y = moveSpeed * 1.25f;
                isJumping = true;
            }
            else if (Input.GetButtonDown("Jump") && !isJumping)
            {
                v.y = moveSpeed * 1.25f;
                isJumping = true;
            }
            else
            {
                v.x = 0;
                animator.SetBool("mode", false);
            }
            rb.velocity = v;
            //プレイヤーの下方向へレイを出す
            Vector3 rayPosition = transform.position + new Vector3(0.0f, 0.8f, 0.0f);
            Ray ray = new Ray(rayPosition, Vector3.down);
            float distance = 1;
            Debug.DrawRay(rayPosition, Vector3.down * distance, Color.red);
            isBlock = Physics.Raycast(ray, distance);
            if (isBlock == true)
            {
                Debug.DrawRay(rayPosition, Vector3.down * distance, Color.red);
                isJumping = false;
                animator.SetBool("Jump", true);
            }
            else
            {
                Debug.DrawRay(rayPosition, Vector3.down * distance, Color.yellow);
                animator.SetBool("Jump", false);
            }
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Coin")
        {
            other.gameObject.SetActive(false);
            audioSource.Play();
            GameManagerScript.score += 1;
        }
        //爆発パーティクル発生
        Instantiate(bombParticle, transform.position, Quaternion.identity);
    }
}
