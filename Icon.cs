using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Icon : MonoBehaviour
{
   

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 30 * Time.deltaTime, 0));
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            IconGenerator ig = GameObject.Find("IconGenerator").GetComponent<IconGenerator>();
            

            if (gameObject.CompareTag("Book"))
            {
                ig.BookPool.Add(gameObject);
                gameObject.SetActive(false);

            }
            if (gameObject.CompareTag("Money"))
            {
                ig.MoneyPool.Add(gameObject);
                gameObject.SetActive(false);
            }
            if (gameObject.CompareTag("People"))
            {
                ig.PeoplePool.Add(gameObject);
                gameObject.SetActive(false);
            }

        }
    }
}
