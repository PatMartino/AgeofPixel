using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swordsman : Unit
{
    


    Unit("Swordsman", 50, 25, 10, 10)
    void Start()
    {
        makeTag();
        
    }
    void FixedUpdate()
    {
        Movement();
    }
    void Update()
    {
        attack();
    }
    public void Movement()
    {
        if (myUnit.isPlayer == true && movement)
        {
            transform.Translate(0.02f, 0, 0);
        }
        else if (isPlayer == false && movement)
        {
            transform.Translate(-0.02f, 0, 0);
        }
    }
    void makeTag()
    {
        if (myUnit.isPlayer == true)
        {
            tag = "Player";
        }
        else
        {
            tag = "Enemy";
        }
    }
    void giveDamage()
    {
        enemy.GetComponent<Unit>().healthPoint -= attackPower;
        Debug.Log(enemy.GetComponent<Unit>().unitName + " " + enemy.GetComponent<Unit>().healthPoint);
    }
    public IEnumerator attackFunc()
    {
        if (isAttack == false)
        {
            while (true)
            {
                //myAnimator.Play("Attack");
                yield return new WaitForSeconds(2f);
                giveDamage();

                if (enemy.GetComponent<Unit>().healthPoint <= 0)
                {
                    Destroy(enemy.gameObject);
                    isAttack = false;
                    break;
                }

            }
        }

    }

    void attack()
    {


        if (gameObject.tag == "Player" )
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position + new Vector3(1, 0, 0), transform.right, range);
            Debug.DrawLine(transform.position + new Vector3(1, 0, 0), (transform.position + transform.right * range) + new Vector3(1, 0, 0), Color.green);

            if (hit.collider != null)
            {
                if (hit.collider.tag == "Enemy")
                {
                    movement = false;
                    enemy = hit.transform;
                    StartCoroutine(attackFunc());
                    isAttack = true;
                }
                if (hit.collider.tag == "Player")
                {
                    movement = false;
                }

            }
            else
            {
                movement = true;
            }


        }
        

        if (gameObject.tag == "Enemy" )
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position + new Vector3(-1f, 0, 0), -transform.right, range);
            Debug.DrawLine(transform.position + new Vector3(-1f, 0, 0), (transform.position + -transform.right * range) + new Vector3(-1f, 0, 0), Color.green);

            if (hit.collider != null)
            {
                if (hit.collider.tag == "Player")
                {
                    movement = false;
                    enemy = hit.transform;
                    StartCoroutine(attackFunc());
                    isAttack = true;
                }
                if (hit.collider.tag == "Enemy")
                {
                    movement = false;
                }


            }

            else
            {
                movement = true;
            }

        }
        

        //movement=false;
        //enemy = bum.transform;
        //StartCoroutine(attackFunc());

    }
}
