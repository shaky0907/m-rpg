using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu]
public class SpawnManager : ScriptableObject
{
    public GameObject playerPrefab;
    public GameObject cameraPrefab;
    
    public string playerSpawn;

    public GameObject ActivePlayer;
    public GameObject ActiveCamera;
    

    public void spawnPlayer()
    {
        
        if (playerSpawn != "")
        {
            GameObject[] spawns = GameObject.FindGameObjectsWithTag("spawner");
            bool foundspawn = false;
            

            foreach(GameObject spawner in spawns)
            {
                if(spawner.name == playerSpawn)
                {
                    foundspawn = true;
                    
                    ActivePlayer.transform.position = spawner.transform.position;
                    ActiveCamera.transform.position = new Vector3(spawner.transform.position.x, spawner.transform.position.y, ActiveCamera.transform.position.z);
                    break;
                }
            }
            if(!foundspawn) 
            {
                
                throw new MissingReferenceException("No hay spawn location con el nombre " + playerSpawn);
            }
           
        }
        else
        {
            GameObject dspawn = GameObject.FindGameObjectWithTag("Default Spawn");

            ActivePlayer.transform.position = dspawn.transform.position;
            ActiveCamera.transform.position = new Vector3(dspawn.transform.position.x, dspawn.transform.position.y, ActiveCamera.transform.position.z);
        }
    }

        
    
}
