using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeGauge : MonoBehaviour
{
    public Slider slider;
    public float horizon = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        slider.value = 100;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < horizon)
        {
            slider.value--;
        }
    }
}
