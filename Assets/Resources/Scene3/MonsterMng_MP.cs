using UnityEngine;

public class MonsterMng_MP : MonoBehaviour
{
    private static MonsterMng_MP instance = null;

    public static MonsterMng_MP Instance
    {
        get
        {
            if(null == instance)
            {
                return null;
            }
            return instance;
        }
    }

    private void Awake()
    {
        if(instance ==null)
        {
            //씬전환되어도 유지되도록
            DontDestroyOnLoad(this.gameObject);
        }else
        {
            Destroy(this.gameObject);
        }

    }

    public void Save()
    {
        //저장 기능!
        print("저장완료!");
        // 유저가 다른곳을 갔다와도 여기에 일정시간 아이템이 남아있어야함..
    }
}
