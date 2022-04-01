using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

// 노트 생성및 게임 데이터

public class NoteManager : MonoBehaviour
{
    public Notedata notedata;

    [ContextMenu("To Json")] // 데이터 쓰기 - test용
    void SaveDataToJson()
    {
        string jsonData = JsonUtility.ToJson(notedata, true);
        string path = Path.Combine(Application.dataPath, "noteData.json");
        File.WriteAllText(path, jsonData);
    }

    [ContextMenu("From Json")] // 데이터 읽기
    void LoadDataToJson() // string 파일 이름으로 불러오기 <- 고쳐야함
    {
        string path = Path.Combine(Application.dataPath, "noteData.json"); // 안애플 고려 - 경로지정
        string jsonData = File.ReadAllText(path);
        notedata = JsonUtility.FromJson<Notedata>(jsonData);
    }

    private int bpm;
    private string songName;
    private int songSample;
    public float currentSample = 0;
    private float step_4; // 4beat 체크 (sample)
    private float step_8; // 8beat 체크
    private float step_16; // 16beat 체크
    private float step_32; // 32beat 체크
    private float step_3; // 3 beat 체크
    private float step_6; // 6 beat 체크
    private float step_12; // 12 beat 체크
    private float step_24; // 24 beat 체크
    public int startTime;
    public Notes[] notes;

    public int test;
    public void getNoteData() // 해당 스테이지의 노트 데이터 불러오기
    {
        LoadDataToJson();
        Debug.Log("Load data done");
        bpm = notedata.bpm;
        songName = notedata.name;
        notes = notedata.notes;
        songSample = notedata.songSample;
        startTime = notedata.startTime;
    }
    private float currentNote = 0; //현재 판정할 노트의 종류

    public static NoteManager instance = null;
    public int GetBpm()
    {
        return bpm;
    }
    public int GetSamples() // 노래의 샘플
    {
        return songSample;
    }

    public Notes[] GetNotes() //E: 적 T: 함정 S:스테이지
    {
        return notes;
    }

    public float BeatToSample(int beat) // 4의 배수 비트일때 Sample 수 계산
    {
        float result = 240f / beat / bpm * songSample;

        return result;
    }
    public bool onTempo(int beat) // 해당 박자일때
    {
        if (AudioManager.instance.getSamples() > Step(beat)) // 4비트 확인 step 증가는 LateUpdate() 에서!
            return true;
        else
            return false;
    }
    public void setCurrentNote(float sample)
    {
        this.currentNote = sample;
    }
    private float Step(int beat) // 해당 비트 단계 불러오기
    {
        switch (beat)
        {
            case 4:
                return this.step_4;
            case 8:
                return this.step_8;
            case 16:
                return this.step_16;
            case 32:
                return this.step_32;
            case 3:
                return this.step_3;
            case 6:
                return this.step_6;
            case 12:
                return this.step_12;
            case 24:
                return this.step_24;

            default:
                throw new System.Exception("-- Input wrong beat -- Available[4,8,16,32,3,6,12,24]");
        }
    }
    void Awake()
    {
        instance = this; //인스턴스 초기화
        getNoteData();
        step_4 = startTime; // 각 박자의 단계 시작시간으로 초기화(sample)
        step_8 = startTime;
        step_16 = startTime;
        step_32 = startTime;
        step_3 = startTime;
        step_6 = startTime;
        step_12 = startTime;
        step_24 = startTime;
        currentSample = 0f;
    }
    void LateUpdate()
    {
        // step 증가 함수 3박 4박 8박 16박 6박 12박 24박 나중에 성능 이슈 발생시 계산하지 않고 미리 배열로 올려두기
        if (onTempo(4))
        {
            step_4 += BeatToSample(4);
        }
        if (onTempo(8))
        {
            step_8 += BeatToSample(8);
        }
        if (onTempo(16))
        {
            step_16 += BeatToSample(16);
        }
        if (onTempo(32))
        {
            step_32 += BeatToSample(32);
        }
        if (onTempo(3))
        {
            step_3 += BeatToSample(3);
        }
        if (onTempo(6))
        {
            step_6 += BeatToSample(6);
        }
        if (onTempo(12))
        {
            step_12 += BeatToSample(12);
        }
        if (onTempo(24))
        {
            step_24 += BeatToSample(24);
        }

    }

}

// [System.Serializable]
// public class Notedata
// {
//     public int bpm = 60;
//     public string name = "test";

//     public Notes[] note;

// }
// [System.Serializable]
// public class Notes
// {
//     public int E;
//     public int T;
//     public int S;
// }


// 임의 데이터 
[System.Serializable]
public class Notedata
{
    // 음악 파일 이름 string

    public int songSample = 44100; // sample단위
    public int bpm = 60; // bpm
    public int startTime = 0; // sample 곡이 시작되는 타이밍
    public string name = "test"; // 곡이름


    public Notes[] notes;

}
[System.Serializable]
public class Notes
{
    public int E; // Enemy 1~4
    public int T; // Trap  1~4
    public int S; // stage 1~7
}