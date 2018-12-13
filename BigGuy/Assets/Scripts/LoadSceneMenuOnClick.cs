using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneMenuOnClick : MonoBehaviour
{
    [SerializeField] GameObject cameraAnim;
    [SerializeField] GameObject tvAnim;
    int sceneIndex;
    Animator Anim;
    Animator TVAnim;

    void Start()
    {
        Anim = cameraAnim.GetComponent<Animator>();
        TVAnim = tvAnim.GetComponent<Animator>();
    }

    public void LoadByIndex(int sceneBuildIndex)
    {
        sceneIndex = sceneBuildIndex;
        StartCoroutine("LoadPlayScene");
        Anim.Play("MainMenucamera2");
        TVAnim.Play("TVSpritePlay");
    }

    IEnumerator LoadPlayScene()
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(sceneIndex);
    }
}
