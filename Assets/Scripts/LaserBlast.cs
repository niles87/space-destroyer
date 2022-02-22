using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBlast : MonoBehaviour
{
    private float movement = 10f;
    private int playerLevel;
    private enum Lasers {Level1, Level2}

    public LaserBlast(Vector3 p, int level)
    {
        transform.position = p;
        playerLevel = level;

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * movement);

    }

}
