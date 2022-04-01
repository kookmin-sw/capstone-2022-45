using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteGenerator : MonoBehaviour
{
    public static NoteGenerator instance;
    private NoteGenerator noteGen;
    public Transform spawnPointD;
    public Transform spawnPointF;
    public Transform spawnPointJ;
    public Transform spawnPointK;

    void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        noteGen = NoteGenerator.instance;

    }

    // Update is called once per frame
    void Update()
    {

    }

    void MoveNoteSpawn(int stagePoint)
    {
        this.transform.position = StageGenerator.instance.GetStagePoint(stagePoint);
    }
}
