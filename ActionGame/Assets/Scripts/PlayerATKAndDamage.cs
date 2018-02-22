using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerATKAndDamage :ATKAndDamage {


    public float attackB = 80;
    public float attackRange = 100;
    public float attackGun = 100;
    public WeaponGun gun;
    public AudioClip shot;
    public AudioClip sword;
    public void AttackA()
    {
        AudioSource.PlayClipAtPoint(sword, transform.position, 0.8f);
        GameObject enemy = null;
        float distance = attackDistance;
        foreach (GameObject go in SpawnManager.instance.enemyList)
        {
            float temp = Vector3.Distance(go.transform.position, transform.position);
            if (temp < distance)
            {
                enemy = go;
                distance = temp;
            }
        }
        if (enemy != null)
        {
            Vector3 targetPos = enemy.transform.position;
            targetPos.y = transform.position.y;
            transform.LookAt(targetPos);
            enemy.GetComponent<ATKAndDamage>().TakeDamage(normalAttack);
        }

    }
    public void AttackB()
    {

        AudioSource.PlayClipAtPoint(sword, transform.position, 0.8f);
        GameObject enemy = null;
        float distance = attackDistance;
        foreach (GameObject go in SpawnManager.instance.enemyList)
        {
            float temp = Vector3.Distance(go.transform.position, transform.position);
            if (temp < distance)
            {
                enemy = go;
                distance = temp;
            }
        }
        if (enemy != null)
        {
            Vector3 targetPos = enemy.transform.position;
            targetPos.y = transform.position.y;
            transform.LookAt(targetPos);
            enemy.GetComponent<ATKAndDamage>().TakeDamage(attackB);
        }

    }
    public void AttackRange()
    {

        AudioSource.PlayClipAtPoint(sword, transform.position, 0.8f);
        List<GameObject> enemyList = new List<GameObject>();
        foreach (GameObject go in SpawnManager.instance.enemyList)
        {
            float temp = Vector3.Distance(go.transform.position, transform.position);
            if (temp < attackDistance)
            {
                enemyList.Add(go);
                //go.GetComponent<ATKAndDamage>().TakeDamage(attackRange);
            }
        }
        foreach (GameObject go in enemyList)
        {
            go.GetComponent<ATKAndDamage>().TakeDamage(attackRange);
        }
    }
    public void AttackGun()
    {
        gun.attack = attackGun;
        gun.Shot();
        AudioSource.PlayClipAtPoint(shot, transform.position, 0.8f);
    }
}
