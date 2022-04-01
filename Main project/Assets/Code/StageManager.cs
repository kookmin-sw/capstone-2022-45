using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//스테이지 상에 생성되는 오브젝트 관리
public class StageManager : MonoBehaviour
{
    public Object note4_1; // 4beat 1time
    public Object note4_4; // 4beat 4time
    public Object note8_4; // 8beat 4time
    public Object note16_4; // 16beat 4time
    public Object note8_D; // 8beat Delay
    public Object noteT_D; // triplet Delay
    public Object normal_Stage; // normal Stage
    private Object[] stageQueue;
    private Object[] noteQueue;

    public static StageManager instance;

    private void Awake()
    {
        instance = this;
    }


    // public static StageManager instance = null;
    // public Transform[] spawnPoint;
    // private void Awake()
    // {
    //     instance = this; //인스턴스 초기화
    // }

    // bool isnote = false;
    // public GameObject obj;
    // public float moveSpeed = 60 / (NoteManager.instance.GetBpm() * 32); //32비트 음에 대응 될 수 있도록 속도조절 
    // public float spawnTiming = 60 / (NoteManager.instance.GetBpm() * 4); // 4비트 움직임


    // // 이동 애니메이션 관련 코드 작성 - 코루틴?
    // void Start()
    // {

    // }

    // // Update is called once per frame
    // void Update()
    // {

    //     if (!isnote) // 활성화된 노트 확인후 없을 때 이동
    //     {
    //         if (Input.GetKeyDown("d") || Input.GetKeyDown("f") || Input.GetKeyDown("j") || Input.GetKeyDown("k"))//노트없을 경우 이동
    //         {
    //             transform.position = transform.position + new Vector3(0, 0, -2.5f);
    //             if (Input.GetKeyDown("k"))//K R방향 이동
    //             {
    //                 transform.position = transform.position + new Vector3(-2.5f, 0, 0);
    //             }
    //             if (Input.GetKeyDown("d"))//d L방향 이동
    //             {
    //                 transform.position = transform.position + new Vector3(2.5f, 0, 0);
    //             }
    //         }

    //     }
    // }

}
