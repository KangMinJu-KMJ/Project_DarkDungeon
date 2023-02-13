using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    public AudioClip spiderHit;
    //public AudioClip playerAttack;
    public AudioClip buyItem;

    void Start()
    {
        if (instance != null)
        {
            Destroy(this);
            return;
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    void OnLevelWasLoaded(int level)
    {
        if (level == 0) // 로드된 씬이 0일경우
        {
            Destroy(gameObject);
        }
    }
}
