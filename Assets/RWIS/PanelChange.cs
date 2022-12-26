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
  
    void Start()
    {
        menuPanel.SetActive(true);
        endPanel.SetActive(false);
        titleFlag = 1;
        gameFlag = 0;
        endFlag = 0;
    }

    public void GameStart()
    {
        menuPanel.SetActive(false);
        endPanel.SetActive(false);
        titleFlag = 0;
        gameFlag = 1;
        endFlag = 0;
    }

    public void ReturnToTitle()
    {
        endPanel.SetActive(false);
        menuPanel.SetActive(true);
        titleFlag = 1;
        gameFlag = 0;
        endFlag = 0;
    }
}