using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ScoreManager : MonoBehaviour
{
    bool isPlayerContact = false;
    public Text BookScoreUI;
    public Text MoneyScoreUI;
    public Text PeopleScoreUI;
    public int bookSet = 0;
    public int moneySet = 0;
    public int peopleSet = 0;



    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "YouthScene")
        {
            PlayerPrefs.SetInt("BookSet", 0);
            PlayerPrefs.SetInt("MoneySet", 0);
            PlayerPrefs.SetInt("PeopleSet", 0);
        }
        bookSet = PlayerPrefs.GetInt("BookSet");
        moneySet = PlayerPrefs.GetInt("MoneySet");
        peopleSet = PlayerPrefs.GetInt("PeopleSet");
        
    }

    // Update is called once per frame
    void Update()
    {
       

        PlayerPrefs.SetInt("BookSet", bookSet);
        PlayerPrefs.SetInt("MoneySet", moneySet);
        PlayerPrefs.SetInt("PeopleSet", peopleSet);

        BookScoreUI.text = "Book : " + bookSet;
        MoneyScoreUI.text = "Money : " + moneySet;
        PeopleScoreUI.text = "People : " + peopleSet;
    }

   
        
}
