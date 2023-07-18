using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNewArea : MonoBehaviour
{

    public string levelLoad;
    public string startpoint;
  
    playerMovement player;

    // Start is called before the first frame update
    void Start()
    {
        player = FindAnyObjectByType<playerMovement>();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Abby")
        {
            player.startpoint = startpoint;
            SceneManager.LoadScene(levelLoad);
        }
    }
}
