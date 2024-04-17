using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ObstacleGenerator2 : MonoBehaviour
{
    public GameObject obstacles1Prefab;
    public GameObject obstacles2Prefab;
    public GameObject obstacles3Prefab;
    

    float spawnTime = 2f; // 장애물 생성 간격
    float delta = 0;
    public float obstacleSpeed = -3f; // 장애물 이동 속도
    public float generatorSpeed = 4f;

    public int poolSize = 10;

    public List<GameObject> obs1Pool;
    public List<GameObject> obs2Pool;
    public List<GameObject> obs3Pool;
    GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        obs1Pool = new List<GameObject>();
        obs2Pool = new List<GameObject>();
        obs3Pool = new List<GameObject>();
        InitializePool(obs1Pool, obstacles1Prefab);
        InitializePool(obs2Pool, obstacles2Prefab);
        InitializePool(obs3Pool, obstacles3Prefab);
        target = GameObject.Find("Player");

    }

    void InitializePool(List<GameObject> pool, GameObject prefab)
    {
        for(int i = 0; i <poolSize; i++)
        {
            GameObject obj = Instantiate(prefab);
            pool.Add(obj);
            obj.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        this.delta += Time.deltaTime;
        if(this.delta > this.spawnTime)
        {
            if(obs1Pool.Count > 0)
            {
                GameObject obs1 = obs1Pool[0];
                obs1Pool.Remove(obs1);
                
                obs1.transform.position = new Vector3(Random.Range(-3f,3f), 3f, target.transform.position.z + 10f);
                if(SceneManager.GetActiveScene().name == "OldScene")
                {
                    obs1.transform.position = new Vector3(Random.Range(-3f, 3f), 0.5f, target.transform.position.z + 10f);
                    obs1.GetComponent<Obstacle>().ObstacleSpeed = this.obstacleSpeed-1f;
                }
                obs1.GetComponent<Obstacle>().ObstacleSpeed = this.obstacleSpeed;
                obs1.SetActive(true);

            }else if(obs2Pool.Count > 0)
            {
                GameObject obs2 = obs2Pool[0];
                obs2Pool.Remove(obs2);
                obs2.transform.position = new Vector3(Random.Range(-3f, 3f), 4f, target.transform.position.z + 10f);
                if (SceneManager.GetActiveScene().name == "OldScene")
                {
                    obs2.transform.position = new Vector3(Random.Range(-3f, 3f), 1f, target.transform.position.z + 10f);
                    obs2.GetComponent<Obstacle>().ObstacleSpeed = this.obstacleSpeed-1f;
                }
                obs2.GetComponent<Obstacle>().ObstacleSpeed = this.obstacleSpeed;
                obs2.SetActive(true);

            }else if(obs3Pool.Count > 0)
            {
                GameObject obs3 = obs3Pool[0];
                obs3Pool.Remove(obs3);
                obs3.transform.position = new Vector3(Random.Range(-3f, 3f), 4f, target.transform.position.z + 10f);
                if (SceneManager.GetActiveScene().name == "OldScene")
                {
                    obs3.transform.position = new Vector3(Random.Range(-3f, 3f), 1f, target.transform.position.z + 10f);
                    obs3.GetComponent<Obstacle>().ObstacleSpeed = this.obstacleSpeed-1f;
                }
                obs3.GetComponent<Obstacle>().ObstacleSpeed = this.obstacleSpeed;
                obs3.SetActive(true);

            }
            this.delta = 0;
            
        }
        
    }
}
