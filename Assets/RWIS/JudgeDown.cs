using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JudgeDown : MonoBehaviour
{
    public AudioClip sound_nigeru;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        if (audioSource == null){
            audioSource = GetComponent<AudioSource>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collision)
    {
        //Debug.Log("failed!");
        //Debug.Log(collision.gameObject.name); // ぶつかった相手の名前を取得
        string fishName = transform.parent.gameObject.name;
        // Debug.Log(fishName);
        GameObject targetFish = GameObject.Find(fishName);

        MoveRandom MoveRandomScript = targetFish.GetComponent<MoveRandom>();
        MoveRandomScript.spd = 1.0f;
        //audioSource.PlayOneShot(sound_nigeru);
    }

}
