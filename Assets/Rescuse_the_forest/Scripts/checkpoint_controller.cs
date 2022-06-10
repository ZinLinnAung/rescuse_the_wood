using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkpoint_controller : MonoBehaviour
{
    public static checkpoint_controller instant;
    private checkpoint[] checkpoints;
    
    public Vector3 checkpointPosition;

    private void Awake()
    {
        instant = this;
    }
    void Start()
    {
        checkpoints = FindObjectsOfType<checkpoint>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DeativateCheckPoint()
    {
        for(int i=0;i<checkpoints.Length;i++)
        {
            checkpoints[i].restartcheckpoint();
        }
            
    }

    public void SpawnPoint(Vector3 newposition)
    {
        checkpointPosition = newposition;
    }
}
