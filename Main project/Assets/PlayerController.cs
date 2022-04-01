using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PlayerController : MonoBehaviour
{
    public playerData playerData;

    [ContextMenu("To Json Data")]// context 메뉴에 기능추가
    void SavePlayerDataToJson()
    {
        string jsonData = JsonUtility.ToJson(playerData, true);// true - pretty print - 플레이어데이ㅓ를 ToJson으로 저장
        string path = Path.Combine(Application.dataPath, "playerData.json"); // 안애플 고려 - 경로지정
        File.WriteAllText(path, jsonData); // 파일쓰기
    }
    [ContextMenu("From Json Data")]// context 메뉴에 기능추가
    void LoadPlayerDataToJson()
    {
        string path = Path.Combine(Application.dataPath, "playerData.json"); // 안애플 고려 - 경로지정
        string jsonData = File.ReadAllText(path);
        playerData = JsonUtility.FromJson<playerData>(jsonData); // 파일읽기
    }

}

[System.Serializable]
public class playerData
{
    public string name;
    public int age;
    public int level;
    public bool isDead;
    public string[] items;
}