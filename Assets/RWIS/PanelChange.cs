using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelChange : MonoBehaviour
{
    
    public int titleFlag = 0;
    public int gameFlag = 0;
    public int endFlag = 0;
    public float spd_set = 0.01f;
    public GameObject menuPanel;
    public GameObject endPanel;
    public GameObject levelPanel;
    public static GameObject ami;
    public static ColorChange colorchange;
    public static GameObject counter;
    public static CountScore cs;
    public GameObject originObject;
    public GameObject goldOriginObject;
    public GameObject slider;
    public GameObject score;
    public GameObject joystick;
    GameObject fishGenerator;
    RandomGenerator randomGeneratorScript;
    //public GameObject poi;


    void Start()
    {
        menuPanel.SetActive(true);
        endPanel.SetActive(false);
        levelPanel.SetActive(false);
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
        levelPanel.SetActive(false);
        score.SetActive(true);
        slider.SetActive(true);
        joystick.SetActive(true);
        //poi.SetActive(true);
        GameObject.Find("poi").transform.position = new Vector3(0, 0, 0);
        fishGenerator = GameObject.Find("FishGenerator");
        randomGeneratorScript = fishGenerator.GetComponent<RandomGenerator>();
        randomGeneratorScript.generateFlag = true;

        titleFlag = 0;
        gameFlag = 1;
        endFlag = 0;
    }

    public void ReturnToTitle()
    {
        endPanel.SetActive(false);
        menuPanel.SetActive(true);
        levelPanel.SetActive(false);
        score.SetActive(false);
        slider.SetActive(false);
        joystick.SetActive(false);
        //poi.SetActive(false);

        titleFlag = 1;
        gameFlag = 0;
        endFlag = 0;

        //ライフゲージの初期化
        colorchange.slider.value = 1000;
        //ライフが0になったことのフラグの初期化
        colorchange.lifeFlag = 0;
        //スコアの初期化
        cs.score = 0;

        //poi_brokenの位置の初期化
        GameObject.Find("poi_broken").transform.position = new Vector3(-20, 0, 0);
        GameObject.Find("poi").transform.position = new Vector3(20, 0, 0);

        GameObject[] goldfishes = GameObject.FindGameObjectsWithTag("GoldFish");
        foreach (GameObject goldfish in goldfishes)
        {
            Destroy(goldfish);
        }
        goldfishes = GameObject.FindGameObjectsWithTag("GoldGoldFish");
        foreach (GameObject goldfish in goldfishes)
        {
            Destroy(goldfish);
        }
    }

    public void SelectLevel()
    {
        endPanel.SetActive(false);
        menuPanel.SetActive(false);
        levelPanel.SetActive(true);
        score.SetActive(false);
        slider.SetActive(false);
        joystick.SetActive(false);
    }

    public void SelectEasyLevel()
    {
        endPanel.SetActive(false);
        menuPanel.SetActive(true);
        levelPanel.SetActive(false);
        score.SetActive(false);
        slider.SetActive(false);
        joystick.SetActive(false);
        spd_set = 0.01f;
    }

    public void SelectHardLevel()
    {
        endPanel.SetActive(false);
        menuPanel.SetActive(true);
        levelPanel.SetActive(false);
        score.SetActive(false);
        slider.SetActive(false);
        joystick.SetActive(false);
        spd_set = 0.05f;
    }
}