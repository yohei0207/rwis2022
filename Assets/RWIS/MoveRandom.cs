using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRandom : MonoBehaviour
{
    // Start is called before the first frame update
    float time = 0.0f;
    int vecX;
    int vecZ;
    public float spd = 0.01f;
    Vector3 target;
    public float moveTime = 2.0f;

    void Start()
    {
        time = 0;
        vecX = Random.Range(-10, 10);
        vecZ = Random.Range(-10, 10);
        target = new Vector3(vecX, -2, vecZ);
        //vecX = Random.Range(-10, 10);
        //vecZ = Random.Range(-10, 10);
        //transform.position = new Vector3(vecX, -2, vecZ);
        moveTime = Random.Range(2.0f, 5.0f);
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time >= moveTime)
        {
            vecX = Random.Range(-10, 10);
            vecZ = Random.Range(-10, 10);
            target = new Vector3(vecX, -2, vecZ);
            time = 0.0f;
            spd = 0.01f;
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, target, spd);
        }
    }
}
