using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Change_Scene : MonoBehaviour
{
    // Scene index to load
    [SerializeField] private int sceneIndex = 0;

    // Player game object
    [SerializeField] private GameObject player;


    private void OnTriggerEnter2D(Collider2D collision)
    {

        // Make the player game object persistent
        DontDestroyOnLoad(player);

        // Load the selecteed scene
        SceneManager.LoadScene(sceneIndex);
    }
}
