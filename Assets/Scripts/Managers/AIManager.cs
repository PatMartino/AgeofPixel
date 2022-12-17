using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIManager : MonoBehaviour
{
    int unitNumber;
    float time;
    bool spawn = false;  
    void Update()
    {
        StartCoroutine(Spawn());
    }
    IEnumerator Spawn()
    {
        while (spawn == false)
        {
            spawn = true;
            yield return new WaitForSeconds(1f);
            UnitTimer();
        }
    }
    void UnitTimer()
    {
            
            unitNumber = Random.Range(0, 2);
            time = Random.Range(4, 12);
            StartCoroutine(Timer());
            
            
    }
    IEnumerator Timer()
    {
        yield return new WaitForSeconds(time);
        EnemyUnitSpawn();
        Debug.LogWarning("Bum");
        spawn = false;
    }
    void EnemyUnitSpawn()
    {
        if (unitNumber == 0)
        {
            Object.Instantiate(Resources.Load<GameObject>("Swordsman(Enemy)"), new Vector3(11, 0, 0), Quaternion.identity);
        }
        else if (unitNumber == 1)
        {
            Object.Instantiate(Resources.Load<GameObject>("Enemy_Archer"), new Vector3(11, 0, 0), Quaternion.identity);
        }
    }
}
