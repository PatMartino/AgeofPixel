using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer : Unit
{
    public override void Start()
    {
        base.Start();
        makeTag();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Movement();
    }
    void Update()
    {
        attack();
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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.tag == "Player")
        {
            if (collision.gameObject.tag == "Player")
            {
                movement = false;
            }
        }
        else if (gameObject.tag == "Enemy")
        {
            if (collision.gameObject.tag == "Enemy")
            {
                movement = false;
            }
        }
    }
    void giveDamage()
    {
        if (enemy == null)
        {
            Debug.Log(unitName + "Bum2");
        }
        else
        {
            enemy.GetComponent<Unit>().healthPoint -= attackPower;
            Debug.Log(enemy.GetComponent<Unit>().unitName + " " + enemy.GetComponent<Unit>().healthPoint);
        }
    }
    public IEnumerator attackFunc()
    {
        if (isAttack == false)
        {
            while (true)
            {
                //myAnimator.Play("Attack");
                yield return new WaitForSeconds(2f);
                if (enemy == null)
                {
                    Debug.Log(unitName + "Bum1");
                    isAttack = false;
                    break;
                }

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
            RaycastHit2D hit = Physics2D.Raycast(transform.position + new Vector3(1, 0, 0), transform.right, range, layerMask);
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
            }
            else
            {
                movement = true;
            }
        }
        if (gameObject.tag == "Enemy" )
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position + new Vector3(-1, 0, 0), -transform.right, range, layerMask);
            Debug.DrawLine(transform.position + new Vector3(-1, 0, 0), (transform.position + -transform.right * range) + new Vector3(-1, 0, 0), Color.green);
            if (hit.collider != null)
            {
                if (hit.collider.tag == "Player")
                {
                    movement = false;
                    enemy = hit.transform;
                    StartCoroutine(attackFunc());
                    isAttack = true;
                }
            }
            else
            {
                movement = true;
            }
        }
    }
}
