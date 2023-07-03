using System.Collections;
using UnityEngine;
using Signals;

namespace Unit
{
    public class Swordsman : Unit
    {
        private void OnEnable()
        {
            animator = GetComponent<Animator>();
        }
        private void Update()
        {
            Attack();
        }

        private void GiveDamage()
        {
            if (enemy == null)
            {
                Debug.Log(unitName+"Bum2");
            }
            else
            {
                enemy.GetComponent<Unit>().healthPoint -= attackPower;
                Debug.Log(enemy.GetComponent<Unit>().unitName + " " + enemy.GetComponent<Unit>().healthPoint);
            }
        
        }
        //isAttack animator isPlayer Enemy

        private IEnumerator AttackFunc()
        {
            if (IsAttack == false)
            {
                while (true)
                {
                    UnitSignals.Instance.onAttackingAnimation?.Invoke(animator);
                    yield return new WaitForSeconds(1f);
                    GiveDamage();
                    if (enemy == null)
                    {
                        Debug.Log(unitName + "Bum1");
                        IsAttack = false;
                        break;
                    }

                    if (enemy.GetComponent<Unit>().healthPoint <= 0)
                    {
                        if (gameObject.CompareTag(("Player")))
                        {
                            CoreGameSignals.Instance.onKillEnemyUnit?.Invoke(enemy.GetComponent<Unit>().unitRevenue);
                        }
                        Destroy(enemy.gameObject);
                        IsAttack = false;
                        break;
                    }
                }
            }
        }
        //Isplayer Canmove Enemy IsAttack animator

        private void Attack()
        {
            if (gameObject.CompareTag("Player") )
            {
                var transform1 = transform;
                RaycastHit2D hit = Physics2D.Raycast(transform1.position + new Vector3(0.5f, 0, 0), transform1.right, range);
                var transform2 = transform;
                var position = transform2.position;
                Debug.DrawLine(position + new Vector3(0.5f, 0, 0), (position + transform2.right * range) + new Vector3(0.5f, 0, 0), Color.green);

                if (hit.collider != null)
                {
                    if (hit.collider.CompareTag("Enemy"))
                    {
                        //UnitSignals.Instance.onAttack?.Invoke(this);
                        Canmove = false;
                        enemy = hit.transform;
                        StartCoroutine(AttackFunc());
                        IsAttack = true;
                    }
                    if (hit.collider.CompareTag("Castle2"))
                    {
                        Canmove = false;
                        enemy = hit.transform;
                        StartCoroutine(CastleAttack());
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
                    UnitSignals.Instance.onWalkingAnimation.Invoke(animator);
                }
            }
            if (gameObject.CompareTag("Enemy") )
            {
                var transform1 = transform;
                RaycastHit2D hit = Physics2D.Raycast(transform1.position + new Vector3(-0.5f, 0, 0), -transform1.right, range);
                var transform2 = transform;
                var position = transform2.position;
                Debug.DrawLine(position + new Vector3(-0.5f, 0, 0), (position + -transform2.right * range) + new Vector3(-0.5f, 0, 0), Color.green);

                if (hit.collider != null)
                {
                    if (hit.collider.CompareTag("Player"))
                    {
                    
                        Canmove = false;
                        enemy = hit.transform;
                        StartCoroutine(AttackFunc());
                        IsAttack = true;
                    }
                    if (hit.collider.CompareTag("Castle1"))
                    {
                        Canmove = false;
                        enemy = hit.transform;
                        StartCoroutine(CastleAttack());
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
                    UnitSignals.Instance.onWalkingAnimation.Invoke(animator);
                }
            }
        }
    }
}
