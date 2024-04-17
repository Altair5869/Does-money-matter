using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    bool isPlayerContact = false;
    public float ObstacleSpeed = -3f;
    Vector3 dir;

    // Start is called before the first frame update
    void Start()
    {
        dir = Vector3.back;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= dir * ObstacleSpeed * Time.deltaTime;
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ObstacleGenerator2 obg = GameObject.Find("ObstacleGenerator").GetComponent<ObstacleGenerator2>();
            ScoreManager sm = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
            isPlayerContact = true;
            
            if (gameObject.CompareTag("Obstacle1"))
            {
                obg.obs1Pool.Add(gameObject);
                gameObject.SetActive(false);
                sm.bookSet--;
            }
            if (gameObject.CompareTag("Obstacle2"))
            {
                obg.obs2Pool.Add(gameObject);
                gameObject.SetActive(false);
                sm.moneySet--;
            }
            if (gameObject.CompareTag("Obstacle3"))
            {
                obg.obs3Pool.Add(gameObject);
                gameObject.SetActive(false);
                sm.peopleSet--;
            }
           
        }

        //ObstacleGenerator2 obg = GameObject.Find("ObstacleGenerator2").GetComponent<ObstacleGenerator2>();
        //if (obg != null)
        //{
        //    if (collision.gameObject.CompareTag("Obstacle1"))
        //    {
        //        collision.gameObject.SetActive(false);
        //        obg.obs1Pool.Add(collision.gameObject);
        //    }
        //    else if (collision.gameObject.CompareTag("Obstacle2"))
        //    {
        //        collision.gameObject.SetActive(false);
        //        obg.obs2Pool.Add(collision.gameObject);
        //    }
        //    else if (collision.gameObject.CompareTag("Obstacle3"))
        //    {
        //        collision.gameObject.SetActive(false);
        //        obg.obs3Pool.Add(collision.gameObject);
        //    }

        //    //gameObject.SetActive(false);

        //}

    }
}