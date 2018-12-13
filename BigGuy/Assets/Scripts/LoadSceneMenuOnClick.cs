using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneMenuOnClick : MonoBehaviour
{
    [SerializeField] GameObject cameraAnim;
    int sceneIndex;
    Animator Anim;

    void Start()
    {
        Anim = cameraAnim.GetComponent<Animator>();
    }

    public void LoadByIndex(int sceneBuildIndex)
    {
        sceneIndex = sceneBuildIndex;
        StartCoroutine("LoadPlayScene");
        Anim.Play("MainMenucamera2");
    }

    IEnumerator LoadPlayScene()
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(sceneIndex);
    }
}
