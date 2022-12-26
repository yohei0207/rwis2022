using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeGauge : MonoBehaviour
{
    public Slider slider;
    public float horizon = 0.0f;
    public static GameObject controlpanel = GameObject.Find("ControlPanel");
    public PanelChange controlpanelscript = controlpanel.GetComponent<PanelChange>();
    public GameObject endPanel;

    // Start is called before the first frame update
    void Start()
    {
        slider.value = 100;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(slider.value);
        
        if (transform.position.y < horizon)
        {
            slider.value--;
        }
    
        if(slider.value <= 0)
        {
            controlpanelscript.titleFlag = 0;
            controlpanelscript.gameFlag = 0;
            controlpanelscript.endFlag = 1;
            endPanel.SetActive(true);
        }
    }
}
