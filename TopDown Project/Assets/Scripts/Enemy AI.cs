using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    GameObject player;
    [SerializeField]
    float chaseSpeed = 5.0f;
    [SerializeField]
    float chaseTriggerDistance = 10;
    [SerializeField]
    bool goHome = true;
    Vector3 homePosition;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        homePosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {   //why in gods green earth do i have to make everything much more complicated for myself.
        //the chase direction is destination - enemy starting position
        Vector3 playerPosition = player.transform.position;
        Vector3 chaseDir = playerPosition - transform.position;
        Vector3 homeDir = homePosition - transform.position;
        if (chaseDir.magnitude < chaseTriggerDistance)
        {

            //move towards the player
            chaseDir.Normalize();
            GetComponent<Rigidbody2D>().velocity = chaseDir * chaseSpeed;
        }
        else if (goHome)
        {
            
            if (homeDir.magnitude < 0.1f)
            {
                transform.position = homePosition;
                GetComponent<Rigidbody2D>().velocity = homeDir * chaseSpeed;

            }
            else
            {
                homeDir.Normalize();
                GetComponent<Rigidbody2D>().velocity = homeDir * chaseSpeed;
            }
        }
        else
        {   //if the player is NOT close,stop moving
            GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        }    
    }   
}





