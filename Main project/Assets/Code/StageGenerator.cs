using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 스테이지 생성에 관한 것들

public class StageGenerator : MonoBehaviour
{
    // Start is called before the first frame update
    public static StageGenerator instance;
    public Transform spawnPoint1;
    public Transform spawnPoint2;
    public Transform spawnPoint3;
    public Transform spawnPoint4C;
    public Transform spawnPoint5;
    public Transform spawnPoint6;
    public Transform spawnPoint7;
    public Object N;

    private Notes[] notes;
    private NoteGenerator noteGen;
    void Awake()
    {
        instance = this;
    }
    void Start()
    {
        noteGen = NoteGenerator.instance;
        this.notes = NoteManager.instance.notes;
    }


    // Update is called once per frame
    void Update()
    {
        if (NoteManager.instance.onTempo(4))
        {
            Instantiate(StageManager.instance.normal_Stage, spawnPoint4C);
        }
    }

    public Vector3 GetStagePoint(int spawnPoint)
    {
        switch (spawnPoint)
        {
            case 1:
                return spawnPoint1.position;
            case 2:
                return spawnPoint2.position;
            case 3:
                return spawnPoint3.position;
            case 4:
                return spawnPoint4C.position;
            case 5:
                return spawnPoint5.position;
            case 6:
                return spawnPoint6.position;
            case 7:
                return spawnPoint7.position;

            default:
                break;
        }
        Debug.Log("Error - GetStagePoint");
        return Vector3.zero;
    }
}
