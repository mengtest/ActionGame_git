﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {

    public static SpawnManager instance;

    public EnemySpawn[] monsterSpawnArray;
    public EnemySpawn[] bossSpawnArray;
    public AudioClip victory;
    public List<GameObject> enemyList = new List<GameObject>();

    void Awake()
    {
        instance = this;
    }

    // Use this for initialization
    void Start()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        //第一波敌人的生成
        foreach (EnemySpawn s in monsterSpawnArray)
        {
            enemyList.Add(s.Spawn());
        }

        while (enemyList.Count > 0)
        {
            yield return new WaitForSeconds(0.2f);
        }

        //第二波敌人的产生
        foreach (EnemySpawn s in monsterSpawnArray)
        {
            enemyList.Add(s.Spawn());
        }
        yield return new WaitForSeconds(0.5f);
        foreach (EnemySpawn s in monsterSpawnArray)
        {
            enemyList.Add(s.Spawn());
        }

        while (enemyList.Count > 0)
        {
            yield return new WaitForSeconds(0.2f);
        }

        //第三波敌人的产生
        foreach (EnemySpawn s in monsterSpawnArray)
        {
            enemyList.Add(s.Spawn());
        }
        yield return new WaitForSeconds(0.5f);
        foreach (EnemySpawn s in monsterSpawnArray)
        {
            enemyList.Add(s.Spawn());
        }
        yield return new WaitForSeconds(0.5f);
        foreach (EnemySpawn s in bossSpawnArray)
        {
            enemyList.Add(s.Spawn());
        }

        while (enemyList.Count > 0)
        {
            yield return new WaitForSeconds(0.2f);
        }
        AudioSource.PlayClipAtPoint(victory, transform.position, 1);

        //游戏胜利
       
    }
}
