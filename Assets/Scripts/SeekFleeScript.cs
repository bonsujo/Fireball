using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekFleeScript : MonoBehaviour
{

    public GameObject character;
    public GameObject target;

    public bool fleeMode = false;

    private Vector3 velocity;
    public float mass = 15;
    public float maxVel = 3;
    public float maxForce = 15;
    // Start is called before the first frame update
    void Start()
    {
        velocity = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 desiredVelocity = target.transform.position - character.transform.position;
        desiredVelocity = desiredVelocity.normalized * maxVel;

        Vector3 steering = desiredVelocity - velocity;
        steering = Vector3.ClampMagnitude(steering, maxForce);
        steering /= mass;

        velocity = Vector3.ClampMagnitude(velocity + steering, maxVel);
        if (fleeMode == false)        
            character.transform.position += velocity * Time.deltaTime;
        
        else
            character.transform.position += (-1 *velocity) * Time.deltaTime;
        
        character.transform.position = new Vector3(character.transform.position.x, 1, character.transform.position.z);

        character.transform.forward = velocity.normalized;

        
    } 
}
