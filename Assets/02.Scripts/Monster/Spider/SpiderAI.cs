using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum State
{
    PATROL = 1, TRACE, ATTACK, HIT, DIE
}
public class SpiderAI : MonoBehaviour
{
    public State state = State.PATROL;
    [SerializeField]
    private Transform playerTr;
    private Transform enemyTr;
    public float attackDist = 3.0f;
    public float traceDist = 7.0f;
    public bool isDie = false;
    private WaitForSeconds ws;
    private MonsterMovement movement;
    private Animator anim;
    private readonly int hashMove = Animator.StringToHash("IsMoving");
    private readonly int hashHit = Animator.StringToHash("Hit");
    private readonly int hashDie = Animator.StringToHash("IsDead");
    private readonly int hashAttack = Animator.StringToHash("Attack");
    public BoxCollider mouthColl;

    private float attackTime = 0f;

    private void Awake()
    {
        var player = GameObject.FindGameObjectWithTag("Player");
        if(player != null)
        {
            playerTr = player.GetComponent<Transform>();
        }
        enemyTr = GetComponent<Transform>();
        anim = GetComponent<Animator>();
        ws = new WaitForSeconds(0.3f);
        movement = GetComponent<MonsterMovement>();
        mouthColl = GameObject.FindGameObjectWithTag("SpiderMouth").GetComponent<BoxCollider>();
        mouthColl.enabled = false;

        
    }

    private void OnEnable()
    {
        isDie = false;
        StartCoroutine(CheckState());
        StartCoroutine(Action());
        
    }

    IEnumerator CheckState()//상태체크
    {
        yield return new WaitForSeconds(1.0f);
        while(!isDie)
        {
            if (state == State.DIE) yield break;
            float dist = Vector3.Distance(playerTr.position, enemyTr.position);
            if (dist <= attackDist)
            {
                state = State.ATTACK;
                
            }
            else if (dist <= traceDist)
            {
                state = State.TRACE;
            }
            else
            {
                state = State.PATROL;
            }
            yield return ws;
        }
    }

    IEnumerator Action()//애니메이션 실행
    {
        while(!isDie)
        {
            yield return ws;
            switch(state)
            {
                case State.PATROL:
                    mouthColl.enabled = false;
                    movement.patrolling = true;
                    anim.SetBool(hashMove, true);
                    break;
                case State.TRACE:
                    mouthColl.enabled = false;
                    movement.traceTarget = playerTr.position;
                    anim.SetBool(hashMove, true);
                    break;
                case State.ATTACK:
                    if (attackTime >= 2.0f)
                    {
                        movement.Stop();
                        anim.SetBool(hashMove, false);
                        mouthColl.enabled = true;
                        anim.SetTrigger(hashAttack);

                        attackTime = 0f;
                    }
                    break;
                case State.HIT:
                    movement.Stop();
                    mouthColl.enabled = false;
                    anim.SetBool(hashMove, false);
                    anim.SetTrigger(hashHit);
                    break;
                case State.DIE:
                    movement.Stop();
                    mouthColl.enabled = false;
                    anim.SetBool(hashDie, true);
                    anim.SetBool(hashMove, false);
                    break;

            }
        }
    }


    void Update()
    {
        attackTime += Time.deltaTime;
    }

    public void OnPlayerDie()
    {
        movement.Stop();
        StopAllCoroutines();
    }
}
