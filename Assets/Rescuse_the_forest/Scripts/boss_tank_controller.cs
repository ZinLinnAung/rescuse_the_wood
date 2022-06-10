using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss_tank_controller : MonoBehaviour
{
    public enum BossState { shooting,hurt,moving};
    [Header("State")]
    public BossState CurrentState;
    public Transform theBoss;
    public Animator animator;
    [Header("Moving")]
    public float movespeed;
    public Transform leftpoint, rightpoint;
    private bool movingRight;
    public SpriteRenderer SR;

    [Header("Fire")]
    public Transform firepoint;
    public GameObject bullet;
    public float timeBetweenShot;
    private float TimeCount;

    [Header("Hurt")]

    public float hurtTime;
    private float hurtCounter;
    public GameObject hitbox;
    void Start()
    {
        CurrentState = BossState.shooting;
    }

    
    void Update()
    {
        switch (CurrentState)
        {
            case BossState.shooting:
                TimeCount -= Time.deltaTime;
                if(TimeCount<=0)
                {
                    TimeCount = timeBetweenShot;
                    var newbullet=Instantiate(bullet, firepoint.position, firepoint.rotation);
                    newbullet.transform.localScale = theBoss.localScale;
                }

                break;

            case BossState.hurt:
                if(hurtCounter>0)
                {
                    
                    hurtCounter -= Time.deltaTime;
                    if(hurtCounter<=0)
                    {
                        CurrentState = BossState.moving;
                        

                    }
                }
                break;

            case BossState.moving:
                if(movingRight)
                {
                   
                    theBoss.position += new Vector3(movespeed * Time.deltaTime, 0f, 0f);
                    if(theBoss.position.x>=rightpoint.position.x)
                    {
                        movingRight = false;
                        EndMovement();
                        theBoss.localScale = new Vector3(1, 1, 1);


                    }
                }else
                {
                   
                    theBoss.position -= new Vector3(movespeed * Time.deltaTime, 0f, 0f);
                    if (theBoss.position.x <= leftpoint.position.x)
                    {
                        movingRight = true;
                        EndMovement();
                        theBoss.localScale = new Vector3(-1, 1, 1);
                    }
                }
                break;
        }
#if UNITY_EDITOR
        if(Input.GetKeyDown(KeyCode.H))
        {
            TakeHit();
        }
#endif

    }

    public void TakeHit()
    {
        CurrentState = BossState.hurt;
        
        hurtCounter = hurtTime;
        animator.SetTrigger("hurt");

    }
    private void EndMovement()
    {
        CurrentState = BossState.shooting;
        TimeCount = timeBetweenShot;
        animator.SetTrigger("stop");
        hitbox.SetActive(true);
    }
}
