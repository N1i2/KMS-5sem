using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject startButton; 
    public GameObject player; 

    void Start()
    {
        EnablePlayerControl(false);

        if (startButton != null && startButton.GetComponent<Button>() != null)
        {
            startButton.GetComponent<Button>().onClick.AddListener(StartGame);
        }
        else
        {
            Debug.LogError("StartButton не установлена или отсутствует компонент Button.");
        }
    }

    void StartGame()
    {
        if (startButton != null)
        {
            startButton.SetActive(false);
        }

        EnablePlayerControl(true);
    }

    void EnablePlayerControl(bool enable)
    {
        if (player != null)
        {
            var playerComponents = player.GetComponents<MonoBehaviour>();
            foreach (var component in playerComponents)
            {
                component.enabled = enable;
            }
        }
        else
        {
            Debug.LogError("Player не установлен.");
        }
    }
}
