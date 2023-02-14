using UnityEngine;
using System.Collections;
using Managers;
using UnityEngine.Serialization;

public class Unit : MonoBehaviour
{
    [HideInInspector]
    public int healthPoint;    
    [HideInInspector]
    public string unitName;   
    [HideInInspector]
    public int range;
    [HideInInspector]
    public int unitCost;
    [HideInInspector]
    public int unitRevenue;

    protected int AttackPower;
    protected bool Canmove = true;
    protected bool Canmove2 = true;
    protected Transform Enemy;
    protected bool IsAttack = false;
    public LayerMask layerMask;
    protected bool IsPlayer;
    private GameObject _gameManager;
    
    public UnitData myUnit;
    
    public virtual void  Start()
    {
        _gameManager= GameObject.FindGameObjectWithTag("GameManager");
        healthPoint = myUnit.healthPoint;
        AttackPower = myUnit.attackPower;
        unitName = myUnit.unitName;
        
        unitCost = myUnit.unitCost;
        unitRevenue = myUnit.unitReveune;
        IsPlayer = myUnit.isPlayer;
        range = myUnit.range;
        MakeTag();
    }
    public virtual void FixedUpdate()
    {
        Movement();
    }

    private void Movement()
    {
        if (IsPlayer&& Canmove && Canmove2)
        {
            transform.Translate(0.02f, 0, 0);
        }
        else if (IsPlayer == false && Canmove && Canmove2)
        {
            transform.Translate(-0.02f, 0, 0);
        }
    }

    private void MakeTag()
    {
        if (myUnit.isPlayer)
        {
            tag = "Player";
        }
        else
        {
            tag = "Enemy";
        }
    }

    protected virtual IEnumerator CastleAttack()
    {
        if (IsPlayer)
        {
            if (IsAttack == false)
            {
                while (true)
                {
                    //myAnimator.Play("Attack");
                    yield return new WaitForSeconds(2f);
                    if (Enemy == null||!Enemy.gameObject.CompareTag("Castle2"))
                    {
                        Debug.Log(unitName + "Bum1");
                        IsAttack = false;
                        break;
                    }
                    Enemy.GetComponent<Castles>().castle2Hp -= AttackPower;
                    Debug.Log(Enemy.GetComponent<Castles>().castle2Hp);
                    if (Enemy.GetComponent<Castles>().castle2Hp <= 0)
                    {
                        _gameManager.GetComponent<GameManager>().EndGame(1);
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
                    if (Enemy == null||!Enemy.gameObject.CompareTag("Castle1"))
                    {
                        Debug.Log(unitName + "Bum1");
                        IsAttack = false;
                        break;
                    }
                    Enemy.GetComponent<Castles>().castle1Hp -= AttackPower;
                    Debug.Log(Enemy.GetComponent<Castles>().castle1Hp);
                    if (Enemy.GetComponent<Castles>().castle1Hp <= 0)
                    {
                        _gameManager.GetComponent<GameManager>().EndGame(1);
                    }
                }
            }
        }
    }
    /*private void OnTriggerEnter2D(Collider2D collision)
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
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (gameObject.tag == "Player")
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                movement = true;

            }
        }
        else if (gameObject.tag == "Enemy")
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                movement = true;
            }
        }
    }
    */
    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.tag == "Player")
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                movement = false;
                enemy = collision.transform;
                StartCoroutine(attackFunc());

            }
            else if(gameObject.tag == "Player")
            {
                movement = false;
            }
        }
        else if(gameObject.tag == "Enemy")
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                movement = false;
                enemy = collision.transform;
                StartCoroutine(attackFunc());

            }
            else if (gameObject.tag == "Enemy")
            {
                movement = false;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (gameObject.tag == "Player")
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                movement = true;

            }
        }
        else if (gameObject.tag == "Enemy")
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                movement = true;
            }
        }
    }*/
    /*void giveDamage()
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


        if (gameObject.tag == "Player" && isRanged == false)
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
        if (gameObject.tag == "Player" && isRanged == true)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position + new Vector3(1, 0, 0), transform.right, range,layerMask);
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

            if (gameObject.tag == "Enemy" && isRanged == false)
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
        if (gameObject.tag == "Enemy" && isRanged == true)
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


    }*/
}

