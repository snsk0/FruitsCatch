using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    [SerializeField] private string sceneName;


    public void OnChangeScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
