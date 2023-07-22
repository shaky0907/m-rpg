using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public SpawnManager spawnManager;

    

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            Application.targetFrameRate = 60;
        }
        else
        {
            Destroy(gameObject);
        }
    }


    private void OnEnable()
    {
        
        SceneManager.sceneLoaded += OnSceneLoaded;

    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;

    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        
        if (scene.buildIndex > 1)
        {
           
            spawnManager.ActivePlayer = Instantiate(spawnManager.playerPrefab);
            spawnManager.ActiveCamera = Instantiate(spawnManager.cameraPrefab);
            spawnManager.ActiveCamera.GetComponent<PlayerTracking>().setPlayer(spawnManager.ActivePlayer);
            spawnManager.spawnPlayer();
            
        }
    }




}
