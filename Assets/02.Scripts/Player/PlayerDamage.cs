using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDamage : MonoBehaviour
{
    private const string enemyTag = "SpiderMouth";
    private PlayerStatus playerStatus;
    [SerializeField]
    private Image HpBar;
    private WaitForSeconds ws;
    private int spiderDmg = 10;
    private PlayerMovement playerMovement;
    private SpiderAI spiderAI;
    private WaitForSeconds attackWs;
    private Animator anim;

    void Start()
    {
        ws = new WaitForSeconds(0.3f);
        playerStatus = GetComponent<PlayerStatus>();
        playerStatus.currHp = playerStatus.initHp;
        HpBar = GameObject.Find("Player_Canvas").transform.GetChild(0).
            transform.GetChild(0).GetComponent<Image>();
        playerMovement = GetComponent<PlayerMovement>();
        spiderAI = GameObject.FindObjectOfType<SpiderAI>();
        attackWs = new WaitForSeconds(1.5f);
        anim = GetComponent<Animator>();

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == enemyTag)
        {
            if (!playerMovement.isGuard)
            {
                StartCoroutine(MinusPlayerHP());
                if (playerStatus.currHp <= 0f)
                    PlayerDie();
            }
        }
    }

    IEnumerator MinusPlayerHP()
    {
        playerStatus.currHp -= spiderDmg;
        DisPlayHpBar();
        yield return attackWs;
    }

    void DisPlayHpBar()
    {
        HpBar.fillAmount = (playerStatus.currHp / playerStatus.initHp);
    }

    void PlayerDie()
    {
        anim.SetTrigger("Die");
        GameManager.isGameOver = true;
    }

    void Update()
    {
        
    }
}
