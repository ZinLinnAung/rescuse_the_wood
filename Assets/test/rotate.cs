using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class rotate : MonoBehaviour
{
    GameObject[] aP = new GameObject[9];
    void Start()
    {
        for (int i = 0; i < 9; i++)
        {
            aP[i] = GameObject.
             CreatePrimitive(PrimitiveType.Cube);
            aP[i].transform.position = new Vector3(0, i + 1, 0);
        }
    }
    void Update()
    {
        for (int i = 0; i < 9; i++)
        {
            aP[i].GetComponent<Renderer>().material.color = new
            Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f),
            Random.Range(0.0f, 1.0f));
        }
    }

}
