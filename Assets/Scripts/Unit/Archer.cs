using System.Collections;
using UnityEngine;
using Signals;

namespace Unit
{
    public class Archer : Unit
    {
        private const float MovementRange = 0.5f;
        [SerializeField] private Animator animator;

        private void OnEnable()
        {
            animator = GetComponent<Animator>();
        }

        void Update()
        {
            Attack();
            StopMovement();
        }
        private void StopMovement()
        {
            if (gameObject.CompareTag("Player") )
            {
                var transform1 = transform;
                RaycastHit2D hit1 = Physics2D.Raycast(transform1.position + new Vector3(1, 0, 0), transform1.right, MovementRange);
                var transform2 = transform;
                var position = transform2.position;
                Debug.DrawLine(position + new Vector3(1, 0, 0), (position + transform2.right * MovementRange) + new Vector3(1, 0, 0), Color.red);
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
                var transform1 = transform;
                RaycastHit2D hit1 = Physics2D.Raycast(transform1.position + new Vector3(-1, 0, 0), -transform1.right, MovementRange);
                var transform2 = transform;
                var position = transform2.position;
                Debug.DrawLine(position + new Vector3(-1, 0, 0), (position + -transform2.right * MovementRange) + new Vector3(-1, 0, 0), Color.red);
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
                        UnitSignals.Instance.onAttackingAnimation.Invoke(animator);
                        //animator.Play("Attack");
                        yield return new WaitForSeconds(1f);
                        if (Enemy == null|| !Enemy.gameObject.CompareTag("Enemy"))
                        {
                            Debug.Log(unitName + "Bum1");
                            IsAttack = false;
                            break;
                        }
                        GiveDamage();
                        if (Enemy.GetComponent<Unit>().healthPoint <= 0)
                        {
                            if (gameObject.CompareTag(("Player")))
                            {
                                CoreGameSignals.Instance.onKillEnemyUnit(Enemy.GetComponent<Unit>().unitRevenue);
                            }
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
                        UnitSignals.Instance.onAttackingAnimation.Invoke(animator);
                        //animator.Play("Attack");
                        yield return new WaitForSeconds(1f);
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
                var transform1 = transform;
                RaycastHit2D hit = Physics2D.Raycast(transform1.position + new Vector3(1, 0, 0), transform1.right, range, layerMask);
                var transform2 = transform;
                var position = transform2.position;
                Debug.DrawLine(position + new Vector3(1, 0, 0), (position + transform2.right * range) + new Vector3(1, 0, 0), Color.green);
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
                    UnitSignals.Instance.onWalkingAnimation.Invoke(animator);
                    //animator.Play("Walk");
                }
            }
            if (gameObject.CompareTag("Enemy") )
            {
                var transform1 = transform;
                RaycastHit2D hit = Physics2D.Raycast(transform1.position + new Vector3(-1, 0, 0), -transform1.right, range, layerMask);
                var transform2 = transform;
                var position = transform2.position;
                Debug.DrawLine(position + new Vector3(-1, 0, 0), (position + -transform2.right * range) + new Vector3(-1, 0, 0), Color.green);
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
                    UnitSignals.Instance.onWalkingAnimation.Invoke(animator);
                    //animator.Play("Walk");
                }
            }
        }

    
    }
}
