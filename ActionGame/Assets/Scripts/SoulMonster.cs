using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulMonster : MonoBehaviour {

    private Transform player;
    public float attackDistance = 2.5f;
    public float speed = 2;
    private CharacterController cc;
    private Animator animator;
    private PlayerATKAndDamage playerATkandDamage;
    [Header("Monster Attack Speed")]
    public float attackTime = 3;//Boss attack for 3 seconds
    public float attackTimer = 0;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag(Tags.player).transform;
        playerATkandDamage = player.GetComponent<PlayerATKAndDamage>();
          cc = this.GetComponent<CharacterController>();
        this.animator = this.GetComponent<Animator>();
        attackTimer = attackTime;
    }
    void Update()
    {if (playerATkandDamage.hp <= 0)
        {
            this.animator.SetBool("Walk", false);
            return;
        }
        Vector3 targetPos = player.position;
        targetPos.y = transform.position.y;
        transform.LookAt(targetPos);
        float distance = Vector3.Distance(targetPos, transform.position);
        if (distance <= attackDistance)
        {
            attackTimer += Time.deltaTime;
            if(attackTimer>attackTime)
            {
             
                    this.animator.SetTrigger("Attack");
                
                attackTimer = 0;

            }
            else
            {
                this.animator.SetBool("Walk", false);
            }
           
        }
        else
        {
            attackTimer = attackTime;//一追上就 进行攻击
            if (this.animator.GetCurrentAnimatorStateInfo(0).IsName("MonRun"))//判断当前是否是Run动画
            {
                cc.SimpleMove(transform.forward * speed);
            }
            this.animator.SetBool("Walk", true);
                
        }
    }
}
