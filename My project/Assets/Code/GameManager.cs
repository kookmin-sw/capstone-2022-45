using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Sample rate 는 44100 고정 Vorbis 압축사용
// 게임실행과 관련된 기능 관리

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("StartGame", 4f);
    }
    void StartGame()
    {
        AudioManager.instance.PlayBgm("testbgm");
        Debug.Log("start");
        Debug.Log(NoteManager.instance.GetBpm());

    }

    // Update is called once per frame
    void Update()
    {

    }
}
