using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JudgeUp : MonoBehaviour
{
    private float displayTime = 1.0f;
    private bool isDisplay = false;
    private float ellapsedTime = 0.0f;
    private Vector3 displayPos;

// #if UNITY_ANDROID && !UNITY_EDITOR
//     public static AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
//     public static AndroidJavaObject currentActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
//     public static AndroidJavaObject vibrator = currentActivity.Call<AndroidJavaObject>("getSystemService", "vibrator");
// #else
//     public static AndroidJavaClass unityPlayer;
//     public static AndroidJavaObject currentActivity;
//     public static AndroidJavaObject vibrator;
// #endif

    public AudioClip sound1;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        Input.gyro.enabled = true;
        // Input.acceleration.enabled = true;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 acc = Input.gyro.userAcceleration;
        //Debug.Log(acc);
        if (isDisplay == true)
        {
            string fishName = transform.parent.gameObject.name;
            GameObject targetFish = GameObject.Find(fishName);
            targetFish.transform.position = displayPos;

            ellapsedTime += Time.deltaTime;
            if (ellapsedTime > displayTime)
            {
                targetFish.SetActive(false);
                isDisplay = false;
            }
        }
    }


    void OnTriggerEnter(Collider collision)
    {
        Vector3 acc = Input.gyro.userAcceleration;
        // Debug.Log(acc);
        if (collision.gameObject.name == "poi" && acc.y >= 0)
        {
            GameObject counter = GameObject.Find("counter");
            CountScore cs = counter.GetComponent<CountScore>();
            cs.score += 10;
//            transform.position = new Vector3(transform.position.x, 5, transform.position.z);
            //kesu
            string fishName = transform.parent.gameObject.name;
            GameObject targetFish = GameObject.Find(fishName);
            displayPos = new Vector3(Random.Range(-0.5f, 0.5f), 5, Random.Range(-0.5f, 0.5f));
            targetFish.transform.position = displayPos;
            isDisplay = true;

            audioSource.PlayOneShot(sound1);
            // Vibrate(1000);
        }
    }

//     public static void Vibrate(long milliseconds)
//     {
//         if (isAndroid()) {
//             vibrator.Call("vibrate", milliseconds);
//         }
//         else {
//             Handheld.Vibrate();
//         }
//     }
//     private static bool isAndroid()
//     {
// #if UNITY_ANDROID && !UNITY_EDITOR
//         return true;
// #else
//         return false;
// #endif
//     }
}
