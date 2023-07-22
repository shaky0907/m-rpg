using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartUp : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartingGame());
    }


    IEnumerator StartingGame() { 
        yield return new WaitForSeconds(4);
        Destroy(gameObject);
        SceneManager.LoadScene("Spawn");
    }
       
}
