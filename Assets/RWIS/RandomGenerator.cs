﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomGenerator : MonoBehaviour
{
    public GameObject originObject;
    public int num = 10;
    // Start is called before the first frame update
    void Start()
    {
        int i;
        for (i = 0; i < num; i++)
        {
            GameObject fish = Instantiate(originObject, new Vector3(Random.Range(-10.0f, 10.0f), Random.Range(-3.0f, -1.5f), Random.Range(-10.0f, 10.0f)), Quaternion.Euler(0, 90, 90));
            // GameObject fish = Instantiate(originObject, new Vector3(Random.Range(-10.0f, 10.0f), -4, Random.Range(-10.0f, 10.0f)), Quaternion.Euler(0, 90, 90));
            fish.name = "fish" + i.ToString();
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
