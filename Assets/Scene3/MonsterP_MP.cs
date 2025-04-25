using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DropItem { GameObject, dropItem ,name, cnt};//??


public struct MonsterData
{
    public GameObject monster;
    public string name;
    public int level;
    public int hp;
    public int mp;
    public int exp;
    public float atkPhysical;
    public float defPhysical;
    public float atkMagical;
    public float defMagical;
    public float delayTime;
    public float speed;
    public GameObject[] dropItem;//게임오브젝트를 해야하나? enum
    public Vector3 moveDistance;
    public int cntObj;
}

public abstract class MonsterP_MP : MonoBehaviour
{
    public MonsterData monData;

    bool ismonMove = false;
    public delegate void MonDropItemDelegate();
    public MonDropItemDelegate CallbackMonDropItem;

    public abstract void MonInitSetting();
    public virtual IEnumerator MonMoving(Transform _mon)
    {
        //if(player =null)return;
        var mon = Instantiate(monData.monster);
        Vector3 mondis = monData.moveDistance;
        float monSpeed = monData.speed;
        while(true)
        {
            ismonMove = true;
            mon.transform.position = _mon.position;
            Vector3 monMove = mon.transform.position + (mondis * monSpeed * Time.deltaTime);
            yield return null;
        }
    }      
    public abstract void MonTargetFllowMoveing();
    public virtual void MonDead()
    {

    }
    public virtual void MonSpawn(int spawnCnt)
    {
        //몬스터 스폰타임, 몬스터 생성 위치, 현재 몬스터 수 //
        for (int i = 0; i< spawnCnt; ++i)
        {
            int rndInx = Random.Range(0, 6);
            GameObject monGo =
                Instantiate(monData.monster);
           // monGo.AddComponent
        }
    }
        
    public abstract void MonAtk();
    public abstract void MonDropItem();

    public virtual void MonItmeSpawnRand(int _randIdx, Transform _monPos)
    {
        for(int i = 0; i < _randIdx; ++i)
        {

        }
    }

}
