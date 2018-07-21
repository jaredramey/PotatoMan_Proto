using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    [HideInInspector]
    private GameObject player;
    [SerializeField]
    [HideInInspector]
    private Vector3 offset;

    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("Player");
        try
        {
            offset = transform.position - player.transform.position;
        }catch
        {
            Debug.Log("Could not calculate player offset.");
            offset = new Vector3(0,0,0);
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}
