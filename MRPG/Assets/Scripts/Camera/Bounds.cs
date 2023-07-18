using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounds : MonoBehaviour
{

    BoxCollider2D bounds;

    PlayerTracking camController;

    // Start is called before the first frame update
    void Start()
    {
        bounds = GetComponent<BoxCollider2D>();
        camController = FindObjectOfType<PlayerTracking>();
        camController.SetBounds(bounds);
    }

}
