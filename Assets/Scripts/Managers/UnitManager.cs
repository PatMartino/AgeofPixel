using System;
using System.Collections;
using UnityEngine;
using Signals;

namespace Managers
{
    public class UnitManager : MonoBehaviour
    {
        private bool _canMove;

        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void OnDestroy()
        {
            UnSubscribeEvents();
        }

        private void SubscribeEvents()
        {
            /*UnitSignals.Instance.onMovement += OnMovement;
            UnitSignals.Instance.onAttack += OnAttack;
            UnitSignals.Instance.stopMovement += StopMovement;/*/        }
        private void UnSubscribeEvents()
        {
            /*UnitSignals.Instance.onMovement -= OnMovement;
            UnitSignals.Instance.onAttack -= OnAttack;
            UnitSignals.Instance.stopMovement -= StopMovement;*/
        }




        public void OnMovement(Unit.Unit unit)
        {
            switch (gameObject.CompareTag("Player"))
            {
                case true when GetComponent<Unit.Unit>().GetCanMove() && unit.GetCanMove():
                    transform.Translate(0.02f, 0, 0);
                    //UnitSignals.Instance.onWalkingAnimation?.Invoke();
                    break;
                case false when GetComponent<Unit.Unit>().GetCanMove() && unit.GetCanMove():
                    transform.Translate(-0.02f, 0, 0);
                    //UnitSignals.Instance.onWalkingAnimation?.Invoke();
                    break;
            }
        }

        public void OnAttack(Unit.Unit unit)
        {
            if (gameObject.CompareTag("Player"))
            {
                var transform1 = transform;
                RaycastHit2D hit = Physics2D.Raycast(transform1.position + new Vector3(1, 0, 0), transform1.right,
                    unit.range, unit.layerMask);
                var transform2 = transform;
                var position = transform2.position;
                //Debug.DrawLine(position + new Vector3(1, 0, 0),
                    //(position + transform2.right * unit.range) + new Vector3(1, 0, 0), Color.green);
                if (hit.collider != null)
                {
                    if (hit.collider.CompareTag("Enemy"))
                    {
                        GetComponent<Unit.Unit>().SetCanMove(unit, 0);
                        GetComponent<Unit.Unit>().enemy = hit.transform;
                        StartCoroutine(AttackFunc(unit));
                        GetComponent<Unit.Unit>().SetIsAttack(unit, 1);
                    }

                    if (hit.collider.CompareTag("Castle2"))
                    {
                        GetComponent<Unit.Unit>().SetCanMove(unit, 0);
                        GetComponent<Unit.Unit>().enemy = hit.transform;
                        StartCoroutine(CastleAttack(unit));
                        GetComponent<Unit.Unit>().SetIsAttack(unit, 1);
                    }
                }
                else
                {
                    GetComponent<Unit.Unit>().SetCanMove(unit, 1);
                    GetComponent<Unit.Unit>().SetCanMove2(unit, 1);
                    UnitSignals.Instance.onWalkingAnimation.Invoke(unit.animator);
                    //animator.Play("Walk");
                }
            }

            if (gameObject.CompareTag("Enemy"))
            {
                var transform1 = transform;
                RaycastHit2D hit = Physics2D.Raycast(transform1.position + new Vector3(-1, 0, 0), -transform1.right,
                    unit.range, unit.layerMask);
                var transform2 = transform;
                var position = transform2.position;
                Debug.DrawLine(position + new Vector3(-1, 0, 0),
                    (position + -transform2.right * unit.range) + new Vector3(-1, 0, 0), Color.green);
                if (hit.collider != null)
                {
                    if (hit.collider.CompareTag("Player"))
                    {
                        GetComponent<Unit.Unit>().SetCanMove(unit, 0);
                        GetComponent<Unit.Unit>().enemy = hit.transform;
                        StartCoroutine(AttackFunc(unit));
                        GetComponent<Unit.Unit>().SetIsAttack(unit, 1);
                    }

                    if (hit.collider.CompareTag("Castle1"))
                    {
                        GetComponent<Unit.Unit>().SetCanMove(unit, 0);
                        GetComponent<Unit.Unit>().enemy = hit.transform;
                        StartCoroutine(CastleAttack(unit));
                        GetComponent<Unit.Unit>().SetIsAttack(unit, 1);
                    }
                }
                else
                {
                    GetComponent<Unit.Unit>().SetCanMove(unit, 1);
                    GetComponent<Unit.Unit>().SetCanMove2(unit, 1);
                    UnitSignals.Instance.onWalkingAnimation.Invoke(unit.animator);
                    //animator.Play("Walk");
                }
            }
        }


        private IEnumerator AttackFunc(Unit.Unit unit)
        {
            if (gameObject.CompareTag("Player"))
            {
                if (gameObject.GetComponent<Unit.Unit>().GetIsAttack() == false)
                {
                    while (true)
                    {
                        UnitSignals.Instance.onAttackingAnimation.Invoke(unit.animator);
                        //animator.Play("Attack");
                        yield return new WaitForSeconds(1f);
                        if (unit.enemy == null || !unit.enemy.gameObject.CompareTag("Enemy"))
                        {
                            Debug.Log(unit.unitName + "Bum1");
                            UnitSignals.Instance.setIsAttack(unit, 0);
                            break;
                        }

                        GiveDamage(unit);
                        if (unit.enemy.GetComponent<Unit.Unit>().healthPoint <= 0)
                        {
                            if (gameObject.CompareTag(("Player")))
                            {
                                CoreGameSignals.Instance.onKillEnemyUnit?.Invoke(unit.enemy.GetComponent<Unit.Unit>()
                                    .unitRevenue);
                            }

                            Destroy(unit.enemy.gameObject);
                            UnitSignals.Instance.setIsAttack(unit, 0);
                            break;
                        }
                    }
                }
            }
            else
            {
                if (gameObject.GetComponent<Unit.Unit>().GetIsAttack() == false)
                {
                    while (true)
                    {
                        UnitSignals.Instance.onAttackingAnimation.Invoke(unit.animator);
                        //animator.Play("Attack");
                        yield return new WaitForSeconds(1f);
                        if (unit.enemy == null || !unit.enemy.gameObject.CompareTag("Player"))
                        {
                            Debug.Log(unit.unitName + "Bum1");
                            UnitSignals.Instance.setIsAttack(unit, 0);
                            break;
                        }

                        GiveDamage(unit);
                        if (unit.enemy.GetComponent<Unit.Unit>().healthPoint <= 0)
                        {
                            Destroy(unit.enemy.gameObject);
                            UnitSignals.Instance.setIsAttack(unit, 0);
                            break;
                        }
                    }
                }
            }
        }

        void GiveDamage(Unit.Unit unit)
        {
            if (unit.enemy == null)
            {
                Debug.Log(unit.unitName + "Bum2");
            }
            else
            {
                unit.enemy.GetComponent<Unit.Unit>().healthPoint -= unit.attackPower;
                Debug.Log(unit.enemy.GetComponent<Unit.Unit>().unitName + " " +
                          unit.enemy.GetComponent<Unit.Unit>().healthPoint);
            }
        }

        IEnumerator CastleAttack(Unit.Unit unit)
        {
            if (gameObject.CompareTag("Player"))
            {
                if (gameObject.GetComponent<Unit.Unit>().GetIsAttack() == false)
                {
                    while (true)
                    {
                        UnitSignals.Instance.onAttackingAnimation.Invoke(unit.animator);
                        //myAnimator.Play("Attack");
                        yield return new WaitForSeconds(1f);
                        if (unit.enemy == null || !unit.enemy.gameObject.CompareTag("Castle2"))
                        {
                            Debug.Log(unit.unitName + "Bum1");
                            UnitSignals.Instance.setIsAttack(unit, 0);
                            break;
                        }

                        unit.enemy.GetComponent<Castles>().castle2Hp -= unit.attackPower;
                        Debug.Log(unit.enemy.GetComponent<Castles>().castle2Hp);
                        if (unit.enemy.GetComponent<Castles>().castle2Hp <= 0)
                        {
                            CoreGameSignals.Instance.endGame?.Invoke(1);
                        }
                    }
                }
            }
            else
            {
                if (gameObject.GetComponent<Unit.Unit>().GetIsAttack() == false)
                {
                    while (true)
                    {
                        UnitSignals.Instance.onAttackingAnimation.Invoke(unit.animator);
                        //myAnimator.Play("Attack");
                        yield return new WaitForSeconds(1f);
                        if (unit.enemy == null || !unit.enemy.gameObject.CompareTag("Castle1"))
                        {
                            Debug.Log(unit.unitName + "Bum1");
                            UnitSignals.Instance.setIsAttack(unit, 0);
                            break;
                        }

                        unit.enemy.GetComponent<Castles>().castle1Hp -= unit.attackPower;
                        Debug.Log(unit.enemy.GetComponent<Castles>().castle1Hp);
                        if (unit.enemy.GetComponent<Castles>().castle1Hp <= 0)
                        {
                            CoreGameSignals.Instance.endGame?.Invoke(0);
                        }
                    }
                }
            }
        }

        public void StopMovement(Unit.Unit unit)
        {
            if (gameObject.CompareTag("Player"))
            {
                var transform1 = transform;
                RaycastHit2D hit1 = Physics2D.Raycast(transform1.position + new Vector3(1, 0, 0), transform1.right,
                    unit.movementRange);
                var transform2 = transform;
                var position = transform2.position;
                Debug.DrawLine(position + new Vector3(1, 0, 0),
                    (position + transform2.right * unit.movementRange) + new Vector3(1, 0, 0), Color.red);
                if (hit1.collider != null)
                {
                    if (hit1.collider.CompareTag("Player"))
                    {
                        UnitSignals.Instance.setCanMove2?.Invoke(unit, 0);
                    }
                }
                else
                {
                    UnitSignals.Instance.setCanMove2?.Invoke(unit, 0);
                }
            }



        }
    }
}

