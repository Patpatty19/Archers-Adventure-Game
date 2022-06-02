using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerBehaviour : MonoBehaviour
{
    Vector2 playerPosition;

    int buffCount = 0;


    public float Speed = 5;
    float currentSpeed;
    public float speedPUTimer = 0f;
    Rigidbody2D playerRigidbody;


    public float jumpHeight = 5;
    float currentJumpHeight;
    public float jumpPUTimer = 0f;

    public bool isGrounded = false;

    public Transform bulletSpawnLocation;
    public GameObject bulletPrefab;

    SpriteRenderer renderer;
    Animator playerAnimator;

    public void playFootstep() {

        SoundManagerScript.PlaySound("finalwalk");
    }

    // Start is called before the first frame update
    void Start()
    {
        playerPosition = transform.position;
        playerRigidbody = GetComponent<Rigidbody2D>();

        currentJumpHeight = jumpHeight;
        currentSpeed = Speed;

        renderer = GetComponent<SpriteRenderer>();
        playerAnimator = GetComponent<Animator>();

        TimerController.instance.BeginTimer();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        

        if (buffCount == 8)
        {
            SceneManager.LoadScene(3);
        }

      /*
        playerPosition.x += currentSpeed * Time.deltaTime * Input.GetAxis("Horizontal");
        playerPosition.y = transform.position.y;

        transform.position = playerPosition; */

        float dirx = currentSpeed * Time.deltaTime * horizontalInput;

        transform.Translate(dirx, 0, 0);

        
        if (horizontalInput > 0)
        {
            renderer.flipX = false;

        } else if (horizontalInput < 0)
        {
            renderer.flipX = true;
        }

         if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            
            playerAnimator.SetBool("isRunning", true);
        } else 
        {
            playerAnimator.SetBool("isRunning", false);

        }

        if (Input.GetKey(KeyCode.Space))
        {
            SoundManagerScript.PlaySound("finaljump2");
            playerAnimator.SetBool("isJumping", true);
        } else
        {
            playerAnimator.SetBool("isJumping", false);

        }

        if (Input.GetMouseButtonDown(0))
        {
            SoundManagerScript.PlaySound("attack");
            playerAnimator.SetBool("isAttacking", true);
        } else
        {
            playerAnimator.SetBool("isAttacking", false);

        }

        


        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            playerRigidbody.AddForce(Vector2.up * currentJumpHeight, ForceMode2D.Impulse);
  
        }

        if (jumpPUTimer > 0) 
        {
            jumpPUTimer -= Time.deltaTime;

            if(jumpPUTimer <= 0)
            {
                jumpPUTimer = 0;
                currentJumpHeight = jumpHeight;
            }
        }

        if (speedPUTimer > 0)
        {
            speedPUTimer -= Time.deltaTime;

            if (speedPUTimer <= 0)
            {
                speedPUTimer = 0;
                currentSpeed = Speed;
            }
        }

        ShootBullets();

    }

    void ShootBullets()
    {

        float direction = 0;
        if (Input.GetAxis("Horizontal") >= 0)
        {
            bulletSpawnLocation.position = transform.position + new Vector3(1, 0, 0);
            direction = 1;

        } else if (Input.GetAxis("Horizontal") <= 0)
        {
            bulletSpawnLocation.position = transform.position - new Vector3(1, 0, 0);
            direction = -1;
        }


        if (Input.GetMouseButtonDown(0))
        {
            GameObject g = Instantiate(bulletPrefab, bulletSpawnLocation.position, Quaternion.identity);
            g.GetComponent<Bullet>().Speed *= direction;
            Destroy(g, 3);
        }
    }


    private void OnCollisionEnter2D(Collision2D c)
    {
        if (c.gameObject.tag == "Ground")

        {
            SoundManagerScript.PlaySound("land");
            isGrounded = true;
            playerAnimator.SetBool("isFalling", false);
        }

        if (c.gameObject.tag == "NoJumpZone")
        {
         
            SoundManagerScript.PlaySound("land");
            playerAnimator.SetBool("isFalling", false);
        }



        if (c.gameObject.tag == "Spike")
        
        {
           
            SceneManager.LoadScene(2);
            gameObject.SetActive(false); 

        }



        if (c.gameObject.tag == "JumpandSpeedPowerUp")

        {
            SoundManagerScript.PlaySound("buff");
            currentJumpHeight = jumpHeight * 2;
            currentSpeed = Speed * 2;
            speedPUTimer = 10;
            jumpPUTimer = 10;
            Buff buff = c.gameObject.GetComponent<Buff>();
            buff.HidePowerUp();
            buffCount += 1;
            


        }


        if (c.gameObject.tag == "SpeedPowerUp")

        {
            SoundManagerScript.PlaySound("buff");
            currentSpeed = Speed * 2;
            speedPUTimer = 10;
            Buff buff = c.gameObject.GetComponent<Buff>();
            buff.HidePowerUp();
            buffCount += 1;
        }

        if (c.gameObject.tag == "JumpandSpeedDebuff")

        {
            SoundManagerScript.PlaySound("debuff");
            currentJumpHeight = jumpHeight / 2;
            currentSpeed = Speed / 2;
            speedPUTimer = 10;
            jumpPUTimer = 10;
            Buff buff = c.gameObject.GetComponent<Buff>();
            buff.HidePowerUp();
            buffCount += 1;
        }


    }

    private void OnCollisionExit2D(Collision2D c)
    {

        if (c.gameObject.tag == "Ground")
        {
            isGrounded = false;
            playerAnimator.SetBool("isFalling", true);
        }

        if (c.gameObject.tag == "NoJumpZone")
        {
            playerAnimator.SetBool("isFalling", true);
        }



    }
}
