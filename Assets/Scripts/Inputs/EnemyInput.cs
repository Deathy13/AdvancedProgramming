using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInput : MonoBehaviour
{
    public Enemy enemy;
    // Use this for initialization
    void Start()
    {
        enemy = GetComponent<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        enemy.Move();
    }
}
