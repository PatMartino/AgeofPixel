using System.Collections;
using UnityEngine;

public class Swordsman : Unit
{
    private void Update()
    {
        Attack();
    }

    void GiveDamage()
    {
        if (Enemy == null)
        {
            Debug.Log(unitName+"Bum2");
        }
        else
        {
            Enemy.GetComponent<Unit>().healthPoint -= AttackPower;
            Debug.Log(Enemy.GetComponent<Unit>().unitName + " " + Enemy.GetComponent<Unit>().healthPoint);
        }
        
    }

    private IEnumerator AttackFunc()
    {
        if (IsAttack == false)
        {
            while (true)
            {
                //myAnimator.Play("Attack");
                yield return new WaitForSeconds(2f);
                GiveDamage();
                if (Enemy == null)
                {
                    Debug.Log(unitName + "Bum1");
                    IsAttack = false;
                    break;
                }

                if (Enemy.GetComponent<Unit>().healthPoint <= 0)
                {
                    Destroy(Enemy.gameObject);
                    IsAttack = false;
                    break;
                }


            }
        }

    }

    private void Attack()
    {
        if (gameObject.CompareTag("Player") )
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position + new Vector3(1, 0, 0), transform.right, range);
            Debug.DrawLine(transform.position + new Vector3(1, 0, 0), (transform.position + transform.right * range) + new Vector3(1, 0, 0), Color.green);

            if (hit.collider != null)
            {
                if (hit.collider.CompareTag("Enemy"))
                {
                    Canmove = false;
                    Enemy = hit.transform;
                    StartCoroutine(AttackFunc());
                    IsAttack = true;
                }
                if (hit.collider.CompareTag("Player"))
                {
                    Canmove = false;
                }

            }
            else
            {
                Canmove = true;
            }
        }
        if (gameObject.CompareTag("Enemy") )
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position + new Vector3(-1f, 0, 0), -transform.right, range);
            Debug.DrawLine(transform.position + new Vector3(-1f, 0, 0), (transform.position + -transform.right * range) + new Vector3(-1f, 0, 0), Color.green);

            if (hit.collider != null)
            {
                if (hit.collider.CompareTag("Player"))
                {
                    
                    Canmove = false;
                    Enemy = hit.transform;
                    StartCoroutine(AttackFunc());
                    IsAttack = true;
                }
                if (hit.collider.CompareTag("Enemy"))
                {
                    Canmove = false;
                }
            }
            else
            {
                Canmove = true;
            }
        }
    }
}
