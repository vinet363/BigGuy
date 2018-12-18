using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class StartButtonMenu : MonoBehaviour
{
    [SerializeField] GameObject startButton;
    EventSystem m_EventSystem;

    private void OnEnable()
    {
        m_EventSystem = EventSystem.current;
        StartCoroutine("ButtonSpawn");
    }

    IEnumerator ButtonSpawn()
    {
        yield return new WaitForSeconds(0.01f);
        m_EventSystem.SetSelectedGameObject(startButton);
    }
}
