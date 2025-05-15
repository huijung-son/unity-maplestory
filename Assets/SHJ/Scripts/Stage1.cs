using UnityEngine;
using static UnityEditor.PlayerSettings;

public class Stage1 : MonoBehaviour
{

    [SerializeField] private GameObject background;
    [SerializeField] private GameObject foreground;
    private SpriteRenderer backSpr = null;
    private SpriteRenderer frontSpr = null;

    private GameObject[] backgrounds = new GameObject[3];
    private GameObject[] foregrounds = new GameObject[3];

    private void Awake()
    {
        backSpr = background.GetComponent<SpriteRenderer>();
        frontSpr = foreground.GetComponent<SpriteRenderer>();

        for (int i = 0; i < backgrounds.Length; ++i)
        {
            backgrounds[i] = Instantiate(background);
            SpriteRenderer sp = backgrounds[i].GetComponent<SpriteRenderer>();
            Vector3 pos = new Vector3(transform.position.x + (i * sp.sprite.bounds.size.x), 0f, 0f);
            backgrounds[i].transform.position = pos;
            backgrounds[i].transform.SetParent(transform);
        }
        for (int i = 0; i < foregrounds.Length; ++i)
        {
            foregrounds[i] = Instantiate(foreground);
            SpriteRenderer sp = foregrounds[i].GetComponent<SpriteRenderer>();
            Vector3 pos = new Vector3(transform.position.x + (i * sp.sprite.bounds.size.x), 0f, 0f);
            foregrounds[i].transform.position = pos;
            foregrounds[i].transform.SetParent(transform);
        }
    }

    private void Update()
    {
        foreach (GameObject go in backgrounds)
        {
            if (go.transform.position.x <= -backSpr.sprite.bounds.size.x)
            {
                int index = GetFarIndex(backgrounds);
                Vector3 newPos = go.transform.position;
                newPos.x = backgrounds[index].transform.position.x + backSpr.sprite.bounds.size.x;
                go.transform.position = newPos;
            }
        }

        foreach (GameObject go in foregrounds)
        {
            if (go.transform.position.x <= -frontSpr.sprite.bounds.size.x)
            {
                int index = GetFarIndex(foregrounds);
                Vector3 newPos = go.transform.position;
                newPos.x = foregrounds[index].transform.position.x + frontSpr.sprite.bounds.size.x;
                go.transform.position = newPos;
            }
        }
    }

    private int GetFarIndex(GameObject[] gos)
    {
        int index = 0;
        for (int i = 0; i < gos.Length; ++i)
        {
            if (gos[index].transform.position.x < gos[i].transform.position.x)
            {
                index = i;
            }
        }
        return index;
    }

}
