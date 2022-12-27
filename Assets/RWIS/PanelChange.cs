using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelChange : MonoBehaviour
{
    
    public int titleFlag = 0;
    public int gameFlag = 0;
    public int endFlag = 0;
    public GameObject menuPanel;
    public GameObject endPanel;
    public static GameObject ami;
    public static ColorChange colorchange;
    public static GameObject counter;
    public static CountScore cs;
    public GameObject originObject;
    public GameObject goldOriginObject;
    public int num = 20;
    public GameObject slider;
    public GameObject score;
    public GameObject joystick;
    //public GameObject poi;


    void Start()
    {
        menuPanel.SetActive(true);
        endPanel.SetActive(false);
        slider.SetActive(false);
        score.SetActive(false);
        joystick.SetActive(false);
        //poi.SetActive(false);
        GameObject.Find("poi").transform.position = new Vector3(20, 0, 0);
        titleFlag = 1;
        gameFlag = 0;
        endFlag = 0;

        ami = GameObject.Find("あみ");
        colorchange = ami.GetComponent<ColorChange>();

        counter = GameObject.Find("counter");
        cs = counter.GetComponent<CountScore>();
    }

    public void GameStart()
    {
        menuPanel.SetActive(false);
        endPanel.SetActive(false);
        score.SetActive(true);
        slider.SetActive(true);
        joystick.SetActive(true);
        //poi.SetActive(true);
        GameObject.Find("poi").transform.position = new Vector3(0, 0, 0);

        titleFlag = 0;
        gameFlag = 1;
        endFlag = 0;
    }

    public void ReturnToTitle()
    {
        endPanel.SetActive(false);
        menuPanel.SetActive(true);
        score.SetActive(false);
        slider.SetActive(false);
        joystick.SetActive(false);
        //poi.SetActive(false);

        titleFlag = 1;
        gameFlag = 0;
        endFlag = 0;
        Debug.Log("return");

        //ライフゲージの初期化
        colorchange.slider.value = 1000;
        //ライフが0になったことのフラグの初期化
        colorchange.lifeFlag = 0;
        //スコアの初期化
        cs.score = 0;

        //poi_brokenの位置の初期化
        GameObject.Find("poi_broken").transform.position = new Vector3(-20, 0, 0);
        GameObject.Find("poi").transform.position = new Vector3(20, 0, 0);

        for (int i = 0; i < num; i++)
        {
            string fishName = "fish" + i.ToString();
            GameObject targetFish = GameObject.Find(fishName);
            Destroy(targetFish);
        }

        for (int i = 0; i < num; i++)
        {
            if (i >= 2)
            {
                GameObject fish = Instantiate(originObject, new Vector3(Random.Range(-10.0f, 10.0f), Random.Range(-3.0f, -1.5f), Random.Range(-10.0f, 10.0f)), Quaternion.Euler(0, 90, 90));
                // GameObject fish = Instantiate(originObject, new Vector3(Random.Range(-10.0f, 10.0f), -4, Random.Range(-10.0f, 10.0f)), Quaternion.Euler(0, 90, 90));
                fish.name = "fish" + i.ToString();
            }
            else
            {
                GameObject fish = Instantiate(goldOriginObject, new Vector3(Random.Range(-10.0f, 10.0f), Random.Range(-3.0f, -1.5f), Random.Range(-10.0f, 10.0f)), Quaternion.Euler(0, 90, 90));
                // GameObject fish = Instantiate(originObject, new Vector3(Random.Range(-10.0f, 10.0f), -4, Random.Range(-10.0f, 10.0f)), Quaternion.Euler(0, 90, 90));
                fish.name = "fish" + i.ToString();

            }
        }

      
    }
}