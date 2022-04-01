using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;

public class GameCountdown : MonoBehaviour
{
    private float timer = 0.0f;
    public GameObject num1;
    public GameObject num2;
    public GameObject num3;
    public GameObject numGo;
    Stopwatch stopwatch = new Stopwatch();

    void Start()
    {
        timer = 0; // 초기화
        num1.SetActive(false);
        num2.SetActive(false);
        num3.SetActive(false);
        numGo.SetActive(false);

    }
    void Update()
    {

        if (timer <= 5)
        {
            timer += Time.deltaTime;

            if (timer > 1)
            {
                num3.SetActive(true);
            }
            if (timer > 2)
            {
                num3.SetActive(false);
                num2.SetActive(true);
            }
            if (timer > 3)
            {
                num2.SetActive(false);
                num1.SetActive(true);
            }
            if (timer > 4)
            {
                num1.SetActive(false);
                numGo.SetActive(true);
            }
            if (timer > 5)
            {
                numGo.SetActive(false);
            }
        }

    }

}


