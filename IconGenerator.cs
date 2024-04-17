using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconGenerator : MonoBehaviour
{
    public GameObject BookPrefab;
    public GameObject MoneyPrefab;
    public GameObject PeoplePrefab;

    float spawnTime = 2f; // 장애물 생성 간격
    float delta = 0;
    public float generatorSpeed = 4f;
    public int poolSize = 4;
    public List<GameObject> BookPool;
    public List<GameObject> MoneyPool;
    public List<GameObject> PeoplePool;

    GameObject target;


    // Start is called before the first frame update
    void Start()
    {
        BookPool = new List<GameObject>();
        MoneyPool = new List<GameObject>();
        PeoplePool = new List<GameObject>();
        InitializePool(BookPool, BookPrefab);
        InitializePool(MoneyPool, MoneyPrefab);
        InitializePool(PeoplePool, PeoplePrefab);
        target = GameObject.Find("Player");
    }


    void InitializePool(List<GameObject> pool, GameObject prefab)
    {
        for (int i = 0; i < poolSize; i++)
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
            if (BookPool.Count > 0)
            {
                GameObject book = BookPool[0];
                BookPool.Remove(book);

                book.transform.position = new Vector3(Random.Range(-3f, 3f), Random.Range(1.2f, 3.5f), target.transform.position.z + 10f);
                book.SetActive(true);
            }else if(MoneyPool.Count > 0)
            {
                GameObject money = MoneyPool[0];
                MoneyPool.Remove(money);

                money.transform.position = new Vector3(Random.Range(-3f, 3f), Random.Range(1.2f, 3.5f), target.transform.position.z + 10f);
                money.SetActive(true);
            }else if(PeoplePool.Count > 0)
            {
                GameObject people = PeoplePool[0];
                PeoplePool.Remove(people);

                people.transform.position = new Vector3(Random.Range(-3f, 3f), Random.Range(1.2f, 3.3f), target.transform.position.z + 10f);
                people.SetActive(true);
            }
            this.delta = 0;

        }
    }
}
