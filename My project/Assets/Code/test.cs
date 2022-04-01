using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{

    private int index = 16; // 16 to 0

    Material stageMaterial;
    void Start()
    {
        //Fetch the Material from the Renderer of the GameObject
        stageMaterial = GetComponent<Renderer>().material;
    }
    void Move()
    {
        transform.position = transform.position + new Vector3(0, 0, -2.5f);
    }

    void Update()
    {

        if (NoteManager.instance.onTempo(4)) //게임 샘플 
        {
            AudioManager.instance.PlaySFX("HandClap");
            Move();
            index--;
            // Debug.Log(index);
        }

        if (index == 1) // 판정 STAGE
        {
            stageMaterial.color = Color.red;
        }
        if (index == 0) // 지나간 STAGE
        {
            stageMaterial.color = Color.black;
        }
        if (index == -2) // 시야에서 사라짐
        {

        }
    }
}
