using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpiderDamage : MonoBehaviour
{
    private const string playerTag = "PlayerSword";
    private PlayerStatus playerStatus;
    private MonsterState monsterState;
    [SerializeField]
    private WaitForSeconds ws;
    private NavMeshAgent agent;
    private Rigidbody rbody;
    [SerializeField]
    private GameObject mouth;
    //private SoundManager soundManager;
    //private AudioClip hitSound;
    //private AudioSource source;

    void Start()
    {
        ws = new WaitForSeconds(0.3f);
        playerStatus = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStatus>();
        monsterState = GetComponent<MonsterState>();
        monsterState.currHp = monsterState.initHp;
        agent = GetComponent<NavMeshAgent>();
        rbody = GetComponent<Rigidbody>();
        mouth = GameObject.FindGameObjectWithTag("Spider").transform.GetChild(0).transform.
            GetChild(0).transform.GetChild(1).GetComponent<GameObject>();
//soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
        //hitSound = soundManager.spiderHit;
        //source = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == playerTag)
        {
            monsterState.currHp -= playerStatus.Dmg;
            //if (!source.isPlaying)
            //{
            //    source.clip = hitSound;
            //    source.PlayDelayed(0.2f);
            //    source.Play();
            //}
            if (monsterState.currHp <= 0f)
                SpiderDie();
        }
    }

    void SpiderDie()
    {
        agent.isStopped = true;
        GetComponent<SpiderAI>().state = State.DIE;
        GetComponent<CapsuleCollider>().enabled = false;
        rbody.isKinematic = true;
        StartCoroutine(PushPool());
        PlayerQuest.questCount += 1;
    }

    IEnumerator PushPool()
    {
        yield return new WaitForSeconds(2.0f);

        GetComponent<SpiderAI>().state = State.PATROL;
        GetComponent<CapsuleCollider>().enabled = true;
        monsterState.currHp = monsterState.initHp;
        this.gameObject.SetActive(false);
    }


}
