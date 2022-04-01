using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Judger : MonoBehaviour
{
    public float accuracy = 0.04f; //정확도 ms
    private float exc;
    private float good;
    private float bad;
    private float miss; // miss 는 현재 노트 처리가 가능한지 불가능한지 판단 하는 데에도 사용.

    private Object ef;

    // Start is called before the first frame update

    private void SetJudgeAccuracy() // 정확도 설정
    {
        exc = NoteManager.instance.GetSamples() * accuracy;
        good = NoteManager.instance.GetSamples() * accuracy * 1.5f; //exc의 1.5배
        bad = NoteManager.instance.GetSamples() * accuracy * 2f; // exc의 2배
        miss = NoteManager.instance.GetSamples() * accuracy * 3f; // exc의 3배 나머지는 처리안함.
    }

    void Awake()
    {

    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.anyKey)&& isActive
    }
}
