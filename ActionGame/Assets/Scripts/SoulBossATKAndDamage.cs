using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulBossATKAndDamage :ATKAndDamage {

    private Transform player;
    public AudioClip bossAttack;
    void Awake()
    {
        base.Awake();
        player = GameObject.FindGameObjectWithTag(Tags.player).transform;
    }


    public void Attack1()
    {
      
        if (Vector3.Distance(transform.position, player.position) < attackDistance)
        {
            AudioSource.PlayClipAtPoint(bossAttack, transform.position, 1);
            player.GetComponent<ATKAndDamage>().TakeDamage(normalAttack);
        }
    }
    public void Attack2()
    {
     
        if (Vector3.Distance(transform.position, player.position) < attackDistance)
        {
            player.GetComponent<ATKAndDamage>().TakeDamage(normalAttack);
        }
    }
}
