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
    public float spd_org = 0.01f;
    Vector3 target;
    public float moveTime = 2.0f;

    void Start()
    {
        time = 0;
        vecX = Random.Range(-10, 10);
        vecZ = Random.Range(-10, 10);
        target = new Vector3(vecX, transform.position.y, vecZ);
        // target = new Vector3(vecX, -2, vecZ);
        moveTime = Random.Range(2.0f, 5.0f);
        GameObject controlPanel = GameObject.Find("ControlPanel");
        PanelChange panelChangeScript = controlPanel.GetComponent<PanelChange>();
        spd_org = panelChangeScript.spd_set;
        spd = spd_org;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        float dis = Vector3.Distance(transform.position, target);
        if (time >= moveTime || dis < 0.01f)
        {
            vecX = Random.Range(-10, 10);
            vecZ = Random.Range(-10, 10);
            target = new Vector3(vecX, transform.position.y, vecZ);
            time = 0.0f;
            spd = spd_org;
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, target, spd);
        }
    }
}
