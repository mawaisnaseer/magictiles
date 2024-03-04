using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TileBoard : MonoBehaviour
{
    public float movementSpeed;
    Transform myTransform;

    public static Action<float> OnTileSpeedChanged;
    private void OnEnable()
    {
        OnTileSpeedChanged += SetSpeed;
    }
    private void OnDisable()
    {
        OnTileSpeedChanged -= SetSpeed;
        
    }

    void SetSpeed(float speed)
    {
        MovementSpeed = speed;
    }
    public float MovementSpeed
    {
        get => movementSpeed;
        set
        {
            movementSpeed = value;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        myTransform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        myTransform.position = new Vector3(myTransform.position.x,
            myTransform.position.y + (-1 * movementSpeed * Time.deltaTime),
            myTransform.position.z
            );
    }
}
