using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyNavigationScript : MonoBehaviour
{

    public Transform player;
    UnityEngine.AI.NavMeshAgent nav;
    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<UnityEngine.AI.NavMeshAgent>(); 
    }

    // Update is called once per frame
    void Update()
    {
        nav.SetDestination(player.position);
        
    }
}
