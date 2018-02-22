﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationAttack : MonoBehaviour {
    public Animator animator;
    public bool isCanAttackB = false;//判断能否进行连招
void Start()
    {
        EventDelegate NormalAttackEvent = new EventDelegate(this, "OnNormalAttackClick");
        GameObject.Find("NormalAttack").GetComponent<UIButton>().onClick.Add(NormalAttackEvent);

        EventDelegate RangeAttackEvent = new EventDelegate(this, "OnRangeAttackClick");
        GameObject.Find("RangeAttack").GetComponent<UIButton>().onClick.Add(RangeAttackEvent);

        EventDelegate RedAttackEvent = new EventDelegate(this, "OnRedAttackClick");
        GameObject redAttack = GameObject.Find("RedAttack");
        redAttack.GetComponent<UIButton>().onClick.Add(RedAttackEvent);
        redAttack.SetActive(false);


    }
    public void OnNormalAttackClick()
    {
        if (this.animator.GetCurrentAnimatorStateInfo(0).IsName("PlayerAttackA") && isCanAttackB)
        {
            this.animator.SetTrigger("AttackB");
        }
        else {
            this.animator.SetTrigger("AttackA");
        }
    }
    public void OnRangeAttackClick()
    {
        this.animator.SetTrigger("AttackRanger");
    }
    public void OnRedAttackClick()
    {
        this.animator.SetTrigger("AttackGun");
    }
    public void AttackB1()
    {
        isCanAttackB = true;
    }
    public void AttackB2()
    {
        isCanAttackB = false;
    }
}
