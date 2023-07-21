using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;


public class Follow : MonoBehaviour
{
    public NavMeshAgent enemy;
    public Transform Player;

    private void Start()
    {
        enemy = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        enemy.destination = Player.position;
        

    }
}
