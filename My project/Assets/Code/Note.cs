using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    private int index;
    private float sample;
    private bool isActive = false;

    void Update()
    {
        if (index == 0) // 스테이지의 첫번째 자리에 올 경우
        {
            isActive = true;
            NoteManager.instance.setCurrentNote(sample);

            if ((Input.anyKey))
            {
                //getjudge
            }
        }

        if (index < 0)
        {
            //오브젝트 반환

            //miss judge
        }
    }
}
