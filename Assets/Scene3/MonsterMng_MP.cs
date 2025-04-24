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
            //����ȯ�Ǿ �����ǵ���
            DontDestroyOnLoad(this.gameObject);
        }else
        {
            Destroy(this.gameObject);
        }

    }

    public void Save()
    {
        //���� ���!
        print("����Ϸ�!");
        // ������ �ٸ����� ���ٿ͵� ���⿡ �����ð� �������� �����־����..
    }
}
