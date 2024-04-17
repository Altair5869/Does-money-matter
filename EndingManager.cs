using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EndingManager : MonoBehaviour
{
    public Text[] EndingUI;
    private float currentTime = 0f;
    private int currentIndex = 0;
    private bool isEndingShown = false;


    // Start is called before the first frame update
    void Start()
    {
        ShowEndingText(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (isEndingShown)
        {
            return;
        }

        currentTime += Time.deltaTime;

        if (currentTime >= 5f)
        {
            HideEndingText(currentIndex);

            // 다음 인덱스로 이동하고, 범위를 벗어나면 모든 텍스트가 표시된 것으로 처리
            currentIndex++;
            if (currentIndex >= EndingUI.Length)
            {
                isEndingShown = true; // 모든 엔딩 텍스트가 표시됨을 나타냄
                return;
            }

            ShowEndingText(currentIndex);

            // 경과 시간 초기화
            currentTime = 0f;
        }
    }

    void ShowEndingText(int index)
    {
        EndingUI[index].gameObject.SetActive(true);
    }

    void HideEndingText(int index)
    {
        EndingUI[index].gameObject.SetActive(false);
    }

}
