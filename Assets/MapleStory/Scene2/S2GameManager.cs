using UnityEngine;
using UnityEngine.SceneManagement;

public class S2GameManager : MonoBehaviour
{
    private bool potalEnable = false;

    private void OnEnable()
    {
        S2Potal.s2PotalEvent += PotalEnable;
        S2ZombiMushroomScript.mushroomAction += NextScene;
    }

    private void OnDisable()
    {
        S2Potal.s2PotalEvent -= PotalEnable;
        S2ZombiMushroomScript.mushroomAction -= NextScene;
    }

    private void Awake()
    {
        GameObject mushroom = GameObject.Find("ZombiMushroom");
        DontDestroyOnLoad(mushroom);
    }

    private void PotalEnable(bool _flag)
    {
        this.potalEnable = _flag;
    }

    private void NextScene()
    {
        if (this.potalEnable)
        {
            SceneManager.LoadScene("Scene4");
        }
    }
}
