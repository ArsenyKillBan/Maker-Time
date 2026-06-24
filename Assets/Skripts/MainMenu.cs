using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] int indexLevelScene, indexInfiniteScene, indexxxScene;

    private void SetActrivScene(int activeScene)
    {
        SceneManager.LoadScene(activeScene);
    }

    public void ActiveLevelScene()
    {
        SetActrivScene(indexLevelScene);
    }
    public void ActiveInfiniteScene()
    {
        SetActrivScene(indexInfiniteScene);
    }
    public void ActivexxxScene()
    {
        SetActrivScene(indexxxScene);
    }
}
