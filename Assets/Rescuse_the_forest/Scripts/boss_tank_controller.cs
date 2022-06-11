using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss_tank_controller : MonoBehaviour
{
    public enum BossState { shooting,hurt,moving,end};
    [Header("State")]
    public BossState CurrentState;
    public Transform theBoss;
    public Animator animator;
    [Header("Moving")]
    public float movespeed;
    public Transform leftpoint, rightpoint;
    private bool movingRight;
    public SpriteRenderer SR;
    public GameObject mine;
    public Transform minepoint;
    public float timebetweenmine;
    private float minecount;

    [Header("Fire")]
    public Transform firepoint;
    public GameObject bullet;
    public float timeBetweenShot;
    private float TimeCount;

    [Header("Hurt")]

    public float hurtTime;
    private float hurtCounter;
    public GameObject hitbox;

    [Header("Health")]
    public float health = 5;
    public GameObject explosion;
    public bool isdefected;
    public float speedup;

    public GameObject bouncepad;
    
    void Start()
    {
        CurrentState = BossState.shooting;
        bouncepad.SetActive(false);
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
                        minecount = 0;
                        if(isdefected)
                        {
                            theBoss.gameObject.SetActive(false);
                            Instantiate(explosion, transform.position, transform.rotation);
                            CurrentState = BossState.end;
                            Audio_manager.instance.EndBossMusic();
                            bouncepad.SetActive(true);
                        }
                        

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
                minecount -= Time.deltaTime;
                if(minecount<=0)
                {
                    minecount = timebetweenmine;
                    Instantiate(mine, minepoint.position, minepoint.rotation);
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
        Audio_manager.instance.PlaySFX(0);

        Boss_tank_mine[] mines = FindObjectsOfType<Boss_tank_mine>();
        if (mines.Length > 0|| isdefected)
        {
            foreach (Boss_tank_mine newmine in mines)
            {
                newmine.Explose();
            }
        }
        health--;
        if(health<=0)
        {
            isdefected = true;
        }else
        {
            timeBetweenShot /= speedup;
            timebetweenmine /= speedup;
        }
    }
    private void EndMovement()
    {
        CurrentState = BossState.shooting;
        TimeCount = timeBetweenShot;
        animator.SetTrigger("stop");
        hitbox.SetActive(true);
    }
}
