using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;

public class PlayerTracking : MonoBehaviour
{

    public GameObject player;

    public BoxCollider2D bBox;

    Vector3 minBounds;
    Vector3 maxBounds;

    Camera cam;
    float halfHeight;
    float halfWidth;

    Rigidbody2D rb;

    float step;

    static bool camExists;


    // Start is called before the first frame update
    void Start()
    {
        rb = player.GetComponent<Rigidbody2D>();
        cam = GetComponent<Camera>();
        step = 5 * Time.deltaTime;

        Application.targetFrameRate = 60;

        loadCam();
        

        halfHeight = cam.orthographicSize;
        halfWidth = cam.orthographicSize * Screen.width / Screen.height;
        
    }

    void loadCam()
    {
        if (!camExists)
        {
            camExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }


    // Update is called once per frame
    void Update()
    {

        Vector3 pos = new Vector3(rb.position.x, rb.position.y, cam.transform.position.z);
        transform.position = Vector3.Lerp(transform.position, pos,step);

        if (bBox == null)
        {
            bBox = FindObjectOfType<Bounds>().GetComponent<BoxCollider2D>();
        }

        float clampedX = Mathf.Clamp(transform.position.x, minBounds.x + halfWidth, maxBounds.x - halfWidth);
        float clampedY = Mathf.Clamp(transform.position.y, minBounds.y + halfHeight, maxBounds.y - halfHeight);


        transform.position =  new Vector3(clampedX, clampedY, transform.position.z);

    }

    public void SetBounds(BoxCollider2D newBounds)
    {
        bBox = newBounds;

        minBounds = bBox.bounds.min;
        maxBounds = bBox.bounds.max;
    }
    
}
