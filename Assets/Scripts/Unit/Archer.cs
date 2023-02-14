using System.Collections;
using UnityEngine;

public class Archer : Unit
{
    private readonly float _movementRange=0.5f;
    void Update()
    {
        Attack();
        StopMovement();
    }

   /* private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.CompareTag("Player"))
        {
            if (collision.gameObject.CompareTag("Player") && İsAttack==false)
            {
                Canmove2 = false;
            }
        }
        else if (gameObject.CompareTag("Enemy")&& İsAttack==false)
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                Canmove2 = false;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (gameObject.CompareTag("Player"))
        {
            if (collision.gameObject.CompareTag("Player") && İsAttack==false)
            {
                Canmove2 = true;
            }
        }
        else if (gameObject.CompareTag("Enemy")&& İsAttack==false)
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                Canmove2 = true;
            }
        }
    }*/
    private void StopMovement()
    {
        if (gameObject.CompareTag("Player") )
        {
            RaycastHit2D hit1 = Physics2D.Raycast(transform.position + new Vector3(1, 0, 0), transform.right, _movementRange);
            Debug.DrawLine(transform.position + new Vector3(1, 0, 0), (transform.position + transform.right * _movementRange) + new Vector3(1, 0, 0), Color.red);
            if (hit1.collider != null)
            {
                if (hit1.collider.CompareTag("Player"))
                {
                    Canmove2 = false;
                }
            }
            else
            {
                Canmove2 = true;
            }
        }
        if (gameObject.CompareTag("Enemy") )
        {
            RaycastHit2D hit1 = Physics2D.Raycast(transform.position + new Vector3(-1, 0, 0), -transform.right, _movementRange);
            Debug.DrawLine(transform.position + new Vector3(-1, 0, 0), (transform.position + -transform.right * _movementRange) + new Vector3(-1, 0, 0), Color.red);
            if (hit1.collider != null)
            {
                if (hit1.collider.CompareTag("Enemy"))
                {
                    Canmove2 = false;
                }
            }
            else
            {
                Canmove2 = true;
            }
        }
    }
    void GiveDamage()
    {
        if (Enemy == null)
        {
            Debug.Log(unitName + "Bum2");
        }
        else
        {
            Enemy.GetComponent<Unit>().healthPoint -= AttackPower;
            Debug.Log(Enemy.GetComponent<Unit>().unitName + " " + Enemy.GetComponent<Unit>().healthPoint);
        }
    }
    
    private IEnumerator AttackFunc()
    {
        if (IsPlayer)
        {
            if (IsAttack == false)
            {
                while (true)
                {
                    //myAnimator.Play("Attack");
                    yield return new WaitForSeconds(2f);
                    if (Enemy == null|| !Enemy.gameObject.CompareTag("Enemy"))
                    {
                        Debug.Log(unitName + "Bum1");
                        IsAttack = false;
                        break;
                    }
                    GiveDamage();
                    if (Enemy.GetComponent<Unit>().healthPoint <= 0)
                    {
                        Destroy(Enemy.gameObject);
                        IsAttack = false;
                        break;
                    }
                }
            }
        }
        else
        {
            if (IsAttack == false)
            {
                while (true)
                {
                    //myAnimator.Play("Attack");
                    yield return new WaitForSeconds(2f);
                    if (Enemy == null|| !Enemy.gameObject.CompareTag("Player"))
                    {
                        Debug.Log(unitName + "Bum1");
                        IsAttack = false;
                        break;
                    }
                    GiveDamage();
                    if (Enemy.GetComponent<Unit>().healthPoint <= 0)
                    {
                        Destroy(Enemy.gameObject);
                        IsAttack = false;
                        break;
                    }
                }
            }
        }
    }
    void Attack()
    {
        if (gameObject.CompareTag("Player") )
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position + new Vector3(1, 0, 0), transform.right, range, layerMask);
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
                if (hit.collider.CompareTag("Castle2"))
                {
                    Canmove = false;
                    Enemy = hit.transform;
                    StartCoroutine(CastleAttack());
                    IsAttack = true;
                }
            }
            else
            {
                Canmove = true;
                Canmove2 = true;
            }
        }
        if (gameObject.CompareTag("Enemy") )
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position + new Vector3(-1, 0, 0), -transform.right, range, layerMask);
            Debug.DrawLine(transform.position + new Vector3(-1, 0, 0), (transform.position + -transform.right * range) + new Vector3(-1, 0, 0), Color.green);
            if (hit.collider != null)
            {
                if (hit.collider.CompareTag("Player"))
                {
                    Canmove = false;
                    Enemy = hit.transform;
                    StartCoroutine(AttackFunc());
                    IsAttack = true;
                }
                if (hit.collider.CompareTag("Castle1"))
                {
                    Canmove = false;
                    Enemy = hit.transform;
                    StartCoroutine(CastleAttack());
                    IsAttack = true;
                }
            }
            else
            {
                Canmove = true;
                Canmove2 = true;
            }
        }
    }

    
}
