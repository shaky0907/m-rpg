using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartPointController : MonoBehaviour
{

    public string startpoint;

    playerMovement player ;
    PlayerTracking cam;

    bool spawn;

    void Start()
    {
        spawn = false;
        player = FindAnyObjectByType<playerMovement>();
        
      
        if (player.startpoint == startpoint)
        {
            player.transform.position = transform.position;


            cam = FindAnyObjectByType<PlayerTracking>();
            cam.transform.position = new Vector3(transform.position.x, transform.position.y, cam.transform.position.z);

        }
       
        
      
        
        
    }

    private void Update()
    {

        if (SceneManager.GetActiveScene().isLoaded && !spawn)
        {
            
            if (player.startpoint == startpoint)
            {
                player.transform.position = transform.position;


                cam = FindAnyObjectByType<PlayerTracking>();
                cam.transform.position = new Vector3(transform.position.x, transform.position.y, cam.transform.position.z);
                spawn = true;
            }
           
            
        }

    }

}
