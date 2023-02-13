using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
 
    private Animator anim;
    private float h = 0f;
    private float v = 0f;
    private float r = 0f;
    private Transform tr;
    public float moveSpeed = 10f;
    public float rotSpeed = 120f;
    private bool isMove = false;
    private WaitForSeconds ws;
    private float animSpeed = 1.0f;
    [SerializeField]
    private BoxCollider swordColl;
    [SerializeField]
    private BoxCollider shildColl;
    public static bool isAttack = false;
    public bool isGuard = false;

    //public AudioSource source;
    //private AudioClip attackSound;
    //private SoundManager soundManager;

    void Start()
    {
        tr = GetComponent<Transform>();
        anim = GetComponent<Animator>();
        DontDestroyOnLoad(gameObject);
        ws = new WaitForSeconds(0.78f);
        anim.SetFloat("GuardSpeed", animSpeed);
        swordColl = GameObject.FindGameObjectWithTag("PlayerSword").GetComponent<BoxCollider>();
        shildColl = GameObject.FindGameObjectWithTag("PlayerShild").GetComponent<BoxCollider>();
        shildColl.enabled = false;
        swordColl.enabled = false;
        //source = GetComponent<AudioSource>();
        //soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
        //attackSound = soundManager.playerAttack;
    }

    void OnLevelWasLoaded(int level)
    {
        if (level == 0) // 로드된 씬이 0일경우
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        PlayerMove();
        PlayerAttack();
        PlayerGuard();
        PlayerMoveAni();
    }

    void PlayerMove()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
        r = Input.GetAxis("Mouse X");
        Vector3 movedir = (h * Vector3.right) + (v * Vector3.forward);
        tr.Translate(movedir.normalized * moveSpeed * Time.deltaTime, Space.Self);
        tr.Rotate(Vector3.up * r * rotSpeed * Time.deltaTime);

    }

    void PlayerMoveAni()
    {
        if (h == 0 & v == 0)
        {
            isMove = false;
            anim.SetBool("IsMove", false);
        }
        else
        {
            isMove = true;
            anim.SetBool("IsMove", true);
        }
        anim.SetFloat("PositionX", h);
        anim.SetFloat("PositionY", v);

    }

    void PlayerAttack()
    {
        if (Input.GetMouseButton(0))
        {
            isAttack = true;
            if (isAttack)
            {
                shildColl.enabled = false;
                swordColl.enabled = true;
                anim.SetBool("IsCombo", true);
                //if(!source.isPlaying)
                //{
                //    source.clip = attackSound;
                //    source.PlayDelayed(0.5f);
                //    source.Play();
                //}
                //else if (Input.GetMouseButtonUp(0))
                //    anim.SetBool("IsCombo", false);
            }

        }
        isAttack = false;
    }

    void PlayerGuard()
    {
        
        if (Input.GetMouseButton(1))
        {
            StartCoroutine(StopAni());
        }
        else if (Input.GetMouseButtonUp(1))
        {
            isGuard = false;
            shildColl.enabled = false;
            swordColl.enabled = false;
            animSpeed = 1.0f;
            anim.SetFloat("GuardSpeed", animSpeed);
            anim.SetBool("IsGuard", false);
        }
    }

    IEnumerator StopAni()
    {
        isGuard = true;
        if (isGuard)
        {
            shildColl.enabled = true;
            swordColl.enabled = false;
            animSpeed = 0.0f;
            anim.SetBool("IsGuard", true);
            yield return ws;
            anim.SetFloat("GuardSpeed", animSpeed);
        }
        
    }
}
