using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class NoteParse : MonoBehaviour
{
    public Note2 note;
    [ContextMenu("Save json data")]
    void SaveNoteData()
    {
        string jsonData = JsonUtility.ToJson(note, true);// true - pretty print - 플레이어데이ㅓ를 ToJson으로 저장
        Debug.Log(jsonData);
        string path = Path.Combine(Application.dataPath, "samplenote.json"); // 안애플 고려 - 경로지정

    }
    [ContextMenu("Get json data")]
    void LoadNoteData()
    {
        string path = Path.Combine(Application.dataPath, "Test.bmson"); // 안애플 고려 - 경로지정
        string jsonData = File.ReadAllText(path);
        note = JsonUtility.FromJson<Note2>(jsonData);
        Debug.Log("done");
    }
}
[Serializable]
public class Bga
{
    public string[] bga_events;
    public string[] bga_header;
    public string[] layer_events;
    public string[] poor_events;
}
[Serializable]
public class BpmEvents
{
    public string[] bpm_events;
}
[Serializable]
public class Info
{
    public string artist;
    public string back_image;
    public string banner_image;
    public string chart_name;
    public string eyecatch_image;
    public string genre;
    public int init_bpm;
    public int judge_rank;
    public int level;
    public string mode_hint;
    public int resolution;
    public string subartists;
    public string subtitle;
    public string title;
    public int total;
}
[Serializable]
public class Note<T>
{
    public List<T> jsonote;
    public List<T> ToList() { return jsonote; }
    public Note(List<T> jsonote)
    {
        this.jsonote = jsonote;
    }
}
[Serializable]
public class Note2
{
    public Bga bga;
    public BpmEvents bpmEvent;
    public Info info;
}