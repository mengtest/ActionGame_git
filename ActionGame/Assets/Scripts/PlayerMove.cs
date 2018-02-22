using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    private CharacterController cc;
    public float speed = 4;
    [HideInInspector]
    public Animator animator;
    void Awake()
    {
        cc = this.GetComponent<CharacterController>();
        this.animator = GetComponent<Animator>();
    }
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        if(Joystic.h!=0||Joystic.v!=0)
        {
            h = Joystic.h;
            v = Joystic.v;
        }
        if (Mathf.Abs(h) > 0.1f || Mathf.Abs(v) > 0.1)
        {
            this.animator.SetBool("Walk", true);
            if (this.animator.GetCurrentAnimatorStateInfo(0).IsName("PlayerRun"))
            {
                Vector3 targetDir = new Vector3(h, 0, v);
                transform.LookAt(targetDir + transform.position);
                cc.SimpleMove(transform.forward * speed);
            }
        }
        else
        {
            this.animator.SetBool("Walk", false);
        }
     
        
    }
}
