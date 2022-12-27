using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Poi : MonoBehaviour
{
    public float SnapRange = 1.0f;
    public float center = -2.0f;
    public float scale = 10.0f;
    public FixedJoystick joystick;
    public float virtualControllerScale = 0.01f;

    GameObject[] snapPointList;
    Vector3 ofsPos;
    void Awake()
    {
        Application.targetFrameRate = 120; //60FPSに設定
    }

    // Start is called before the first frame update
    void Start()
    {
        snapPointList = GameObject.FindGameObjectsWithTag("SnapPoint");
        // 入力にジャイロをONにする
        Input.gyro.enabled = true;
        // 入力にコンパスをONにする
        Input.compass.enabled = true;
    }
    
    /*
    void OnMouseDown()
    {
        var mPos = Input.mousePosition;
        mPos.z = 10.0f;
        var wPos = Camera.main.ScreenToWorldPoint(mPos);
        ofsPos = transform.position - wPos;
    }


    
    void OnMouseDrag()
    {
        var mPos = Input.mousePosition;
        mPos.z = 10.0f;
        var wPos = Camera.main.ScreenToWorldPoint(mPos);
        var pos = new Vector3(
            wPos.x + ofsPos.x,
            wPos.y + ofsPos.y,
            wPos.z + ofsPos.z
        );
        //transform.position = CalcSnapPosition(pos);
        Vector3 currentGyro = Input.gyro.gravity.normalized;

        
        //pos.y = currentGyro.z;
        transform.position = pos;
    }
*/
    

    // スナップ位置を計算
    Vector3 CalcSnapPosition(Vector3 srcPos)
    {
        if (snapPointList.Length <= 0)
        {
            // SnapPoint がないとき
            return srcPos;
        }

        // 近くのSnapPointを探す
        GameObject spoint = snapPointList[0];
        float miniDistance = 1000.0f;
        foreach (var item in snapPointList)
        {
            // SnapPoint 毎に距離を測定して判定
            float distance = Vector3.Distance(
                srcPos, item.transform.position);
            if (miniDistance > distance)
            {
                miniDistance = distance;
                spoint = item; //<- 近いSnapPoint
            }
        }
        // Snap Range内か？
        return srcPos;

        if (miniDistance > SnapRange)
        {
            // Snap Range 以上のとき
            return srcPos;
        }


        // SnapPoint へ移動
        return spoint.transform.position;

    }
    


    void Update()
    {
        //スナップの動きの反映
        Vector3 currentGyro = Input.gyro.gravity;
        //transform.position = currentGyro;

        float xPos = transform.position.x + joystick.Horizontal * virtualControllerScale;
        xPos = Math.Min(Math.Max(xPos, -3.0f), 3.0f);

        float zPos = transform.position.z + joystick.Vertical * virtualControllerScale;
        zPos = Math.Min(Math.Max(zPos, -7.0f), 7.0f);
        transform.position = new Vector3(xPos, -1 * currentGyro.y * scale + center, zPos);
        //Debug.Log(currentGyro);
        //print(transform.position);
       
    }
    
}
