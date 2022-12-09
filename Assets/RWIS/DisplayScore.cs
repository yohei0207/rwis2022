using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayScore : MonoBehaviour
{
    public GameObject counter;
    public CountScore cs;
    public Text ScoreText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        counter = GameObject.Find("counter");
        cs = counter.GetComponent<CountScore>();
        ScoreText.text = cs.score.ToString();


    }
}
