using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderManager : MonoBehaviour
{
    [SerializeField]
    private Transform[] spawnPoints;
    [SerializeField]
    private GameObject[] enemys;
    private float createTime = 3.0f;
    private int maxEnemy = 3;
    [SerializeField]
    private List<GameObject> enemy_Pool = new List<GameObject>();
    private WaitForSeconds ws;

    void Start()
    {
        spawnPoints = GameObject.Find("SpiderSpawnPoint").GetComponentsInChildren<Transform>();
        enemys = Resources.LoadAll<GameObject>("Monster/Spider");
        ws = new WaitForSeconds(createTime);
        CreatePoolingSpiders();
        createTime = 2.0f;
    }


    void Update()
    {
        if (spawnPoints.Length > 0)
            StartCoroutine(CreateSpiders());
    }

    void CreatePoolingSpiders()
    {
        GameObject objectEnemy = new GameObject("ObjectEnemy");
        for(int i=0; i<maxEnemy; i++)
        {
            int enemyIndex = Random.Range(0, enemys.Length);
            GameObject obj = Instantiate(enemys[enemyIndex], objectEnemy.transform);
            obj.name = "Spider_" + (i + 1).ToString();
            obj.SetActive(false);
            enemy_Pool.Add(obj);

        }
    }

    IEnumerator CreateSpiders()
    {
        yield return ws;

        foreach(GameObject enemys in enemy_Pool)
        {
            if(!enemys.activeSelf)
            {
                int idx = Random.Range(0, spawnPoints.Length);
                enemys.transform.position = spawnPoints[idx].position;
                enemys.SetActive(true);
                break;
            }
        }
    }
}
