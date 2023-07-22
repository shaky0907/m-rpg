using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNewArea : MonoBehaviour
{

    public string levelLoad;
    public string Spawnpoint;
  
    

    // Start is called before the first frame update
    void Start()
    {
        
        

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("player"))
        {
           
            GameManager.Instance.spawnManager.playerSpawn = Spawnpoint;

            SceneManager.LoadScene(levelLoad);
        }
    }
}
