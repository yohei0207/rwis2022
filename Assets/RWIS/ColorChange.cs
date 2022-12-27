using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ColorChange : MonoBehaviour
{
    MeshRenderer mesh;
    public float horizon = 0;
    public float scale = 0.001f;
    public Slider slider;
    public static GameObject controlpanel;
    public PanelChange controlpanelscript;
    public GameObject endPanel;
    public int lifeFlag = 0;
    public GameObject poi;

    // public float time = 0;
    void Start()
    {
        slider.value = 1000;
        GameObject.Find("score").SetActive(false);
        GameObject.Find("Slider").SetActive(false);
        //mesh = GetComponent<MeshRenderer>();
        //mesh.material.color = mesh.material.color - new Color32(0, 0, 0, 25);
        //StartCoroutine("Transparent");
        controlpanel = GameObject.Find("ControlPanel");
        controlpanelscript = controlpanel.GetComponent<PanelChange>();
    }
    
    void Update()
    {
        if (slider.value <= 0 && lifeFlag == 0)
        {
            controlpanelscript.titleFlag = 0;
            controlpanelscript.gameFlag = 0;
            controlpanelscript.endFlag = 1;
            endPanel.SetActive(true);
            poi = GameObject.Find("poi");
            Vector3 tmp = poi.transform.position;
            GameObject.Find("poi_broken").transform.position = new Vector3(tmp.x, tmp.y, tmp.z);

            lifeFlag = 1;
        }
        else if (controlpanelscript.gameFlag == 0)
        {

        }
        else if (transform.position.y < horizon)
        {
            // time += Time.deltaTime;
            slider.value--;
            //mesh.material.color = mesh.material.color - new Color(0, 0, 0, scale);
        }
        //Debug.Log(mesh.material.color);
    }
    
    /*
    IEnumerator Transparent()
    {
        if (transform.position.y < horizon)
        {
            time += Time.deltaTime;
        }
        for (int i = 0; i < 255; i++)
        {
            mesh.material.color = mesh.material.color - new Color32(0, 0, 0, 1);
            yield return new WaitForSeconds(0.01f);
            Debug.Log(mesh.material.color);
        }
    }
    */
    
}
