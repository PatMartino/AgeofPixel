using System;
using System.Collections;
using Data;
using Managers;
using UnityEngine;
using Signals;
using Unity.Collections;
using UnityEngine.Serialization;

namespace Unit
{
    public class Unit : MonoBehaviour
    {
        [HideInInspector]
        public int healthPoint;    
        [HideInInspector]
        public string unitName;   
        [HideInInspector]
        public float range;
        [HideInInspector]
        public int unitCost;
        [HideInInspector]
        public int unitRevenue;
        [HideInInspector]
        public int attackPower;
        public float movementRange = 0.5f;
        
        private Animator _animator;
        protected bool Canmove = true;
        protected bool Canmove2 = true;
        public Transform enemy;
        protected bool IsAttack;
        public LayerMask layerMask;
        protected bool IsPlayer;
        private GameObject _gameManager;
        public Animator animator;
        
    
        public UnitData myUnit;

        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            UnitSignals.Instance.setCanMove+=SetCanMove;
            UnitSignals.Instance.setCanMove2+=SetCanMove2;
            UnitSignals.Instance.setIsAttack += SetIsAttack;
        }

        public virtual void  Start()
        {
            _animator = GetComponent<Animator>();
            _gameManager= GameObject.FindGameObjectWithTag("GameManager");
            healthPoint = myUnit.healthPoint;
            attackPower = myUnit.attackPower;
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

        public void SetCanMove(Unit unit, int i)
        {
            unit.Canmove = i switch
            {
                0 => false,
                1 => true,
                _ => unit.Canmove
            };
        }
        public void SetCanMove2(Unit unit, int i)
        {
            unit.Canmove2 = i switch
            {
                0 => false,
                1 => true,
                _ => unit.Canmove2
            };
        }
        public void SetIsAttack(Unit unit, int i)
        {
            unit.IsAttack = i switch
            {
                0 => false,
                1 => true,
                _ => unit.IsAttack
            };
        }
        public bool GetIsAttack()
        {
            return IsAttack;
        }
        public bool GetCanMove()
        {
            return Canmove;
        }
        public bool GetCanMove2()
        {
            return Canmove2;
        }

        private void Movement()
        {
            switch (IsPlayer)
            {
                case true when Canmove && Canmove2:
                    transform.Translate(0.02f, 0, 0);
                    //UnitSignals.Instance.onWalkingAnimation?.Invoke();
                    break;
                case false when Canmove && Canmove2:
                    transform.Translate(-0.02f, 0, 0);
                    //UnitSignals.Instance.onWalkingAnimation?.Invoke();
                    break;
            }
            /*switch (IsPlayer)
            {
                case true:
                    transform.Translate(0.02f, 0, 0);
                    //UnitSignals.Instance.onWalkingAnimation?.Invoke();
                    break;
                case false:
                    transform.Translate(-0.02f, 0, 0);
                    //UnitSignals.Instance.onWalkingAnimation?.Invoke();
                    break;
            }*/
        }
        

        private void MakeTag()
        {
            tag = myUnit.isPlayer ? "Player" : "Enemy";
        }

        protected IEnumerator CastleAttack()
        {
            if (IsPlayer)
            {
                if (IsAttack == false)
                {
                    while (true)
                    {
                        UnitSignals.Instance.onAttackingAnimation.Invoke(_animator);
                        //myAnimator.Play("Attack");
                        yield return new WaitForSeconds(1f);
                        if (enemy == null||!enemy.gameObject.CompareTag("Castle2"))
                        {
                            Debug.Log(unitName + "Bum1");
                            IsAttack = false;
                            break;
                        }
                        enemy.GetComponent<Castles>().castle2Hp -= attackPower;
                        Debug.Log(enemy.GetComponent<Castles>().castle2Hp);
                        if (enemy.GetComponent<Castles>().castle2Hp <= 0)
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
                        UnitSignals.Instance.onAttackingAnimation.Invoke(_animator);
                        //myAnimator.Play("Attack");
                        yield return new WaitForSeconds(1f);
                        if (enemy == null||!enemy.gameObject.CompareTag("Castle1"))
                        {
                            Debug.Log(unitName + "Bum1");
                            IsAttack = false;
                            break;
                        }
                        enemy.GetComponent<Castles>().castle1Hp -= attackPower;
                        Debug.Log(enemy.GetComponent<Castles>().castle1Hp);
                        if (enemy.GetComponent<Castles>().castle1Hp <= 0)
                        {
                            _gameManager.GetComponent<GameManager>().EndGame(1);
                        }
                    }
                }
            }
        }
    }
}

