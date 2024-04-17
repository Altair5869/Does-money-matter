using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerMove : MonoBehaviour
{
    

    Rigidbody playerRigidbody;
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    int jumpCount;
    bool isGround;
    float maxXPosition = 6.5f;
    float minXPosition = -3.5f;
    GameObject player;
    public AudioClip bookSE;
    public AudioClip moneySE;
    public AudioClip peopleSE;
    public AudioClip obstacleSE;
    AudioSource audioSource;



    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        playerRigidbody = GetComponent<Rigidbody>();
        jumpCount = 0;
        isGround = true;
        this.audioSource = GetComponent<AudioSource>();
       
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        if(SceneManager.GetActiveScene().name == "OldScene")
        {
            this.moveSpeed = 4f;
        } 
        Vector3 movement = new Vector3(horizontalInput*moveSpeed, playerRigidbody.velocity.y, moveSpeed);
        Vector3 newPosition = transform.position + movement * Time.fixedDeltaTime;
        newPosition.x = Mathf.Clamp(newPosition.x, minXPosition, maxXPosition);


        playerRigidbody.MovePosition(newPosition);
       

        // 점프 처리
        if (isGround)
        {
            jumpCount = 0;
            if (Input.GetKey(KeyCode.UpArrow))
            {
                if(jumpCount < 2)
                {
                    playerRigidbody.AddForce(Vector3.up*jumpForce, ForceMode.Impulse);
                    isGround = false;
                    jumpCount++;
                }
   
            }
            


        }

        if (SceneManager.GetActiveScene().name == "YouthScene" && transform.position.y < -20f)
        {
            SceneManager.LoadScene("AdultScene");
        }

        if (SceneManager.GetActiveScene().name == "AdultScene" && transform.position.y < -20f)
        {
            SceneManager.LoadScene("OldScene");
        }
        if(SceneManager.GetActiveScene().name == "OldScene" && transform.position.y < -15f)
        {
            ScoreManager sm = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
            if (sm.bookSet >= 25 && sm.moneySet >= 25 && sm.peopleSet >= 20)
            {
                SceneManager.LoadScene("TrueEnd");
            }else if(sm.bookSet >= 13 && sm.moneySet >= 15 && sm.peopleSet >= 13)
            {
                SceneManager.LoadScene("NormalEnd");
            }
            else
            {
                SceneManager.LoadScene("BadEnd");
            }
        }
        


    }



    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            isGround = true;
            
        }

        ObstacleGenerator2 obg = GameObject.Find("ObstacleGenerator").GetComponent<ObstacleGenerator2>();
        IconGenerator ig = GameObject.Find("IconGenerator").GetComponent<IconGenerator>();
        ScoreManager sm = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
        if (obg != null)
        {
            if (collision.gameObject.CompareTag("Obstacle1"))
            {
                this.audioSource.PlayOneShot(this.obstacleSE);
                collision.gameObject.SetActive(false);
                obg.obs1Pool.Add(collision.gameObject);
                sm.bookSet--;
            }
            else if (collision.gameObject.CompareTag("Obstacle2"))
            {
                this.audioSource.PlayOneShot(this.obstacleSE);
                collision.gameObject.SetActive(false);
                obg.obs2Pool.Add(collision.gameObject);
                sm.moneySet--;
            }
            else if (collision.gameObject.CompareTag("Obstacle3"))
            {
                this.audioSource.PlayOneShot(this.obstacleSE);
                collision.gameObject.SetActive(false);
                obg.obs3Pool.Add(collision.gameObject);
                sm.peopleSet--;
            }
            
        }

        if(ig != null)
        {
            if (collision.gameObject.CompareTag("Book"))
            {
                this.audioSource.PlayOneShot(this.bookSE);
                collision.gameObject.SetActive(false);
                ig.BookPool.Add(collision.gameObject);
                sm.bookSet++;
                
            }
            else if (collision.gameObject.CompareTag("Money"))
            {
                this.audioSource.PlayOneShot(this.moneySE);
                collision.gameObject.SetActive(false);
                ig.MoneyPool.Add(collision.gameObject);
                sm.moneySet++;
            }
            else if (collision.gameObject.CompareTag("People"))
            {
                this.audioSource.PlayOneShot(this.peopleSE);
                collision.gameObject.SetActive(false);
                ig.PeoplePool.Add(collision.gameObject);
                sm.peopleSet++;
            }
        }


    }
}
