using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [HideInInspector]
    public float speed;
    private Rigidbody2D monsterBody;

    /**
    * - RigidBody -> Body type
    * - 1. Dynamic: Force & Gravity will apply to the game object.
    * - 2. Kinematic: Force will apply to the game object, not Gravity.
    * - 3. Static: Has RigidBody but Force & Gravity does not apply to it.
    **/

    void Awake()
    {
        monsterBody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        monsterBody.velocity = new Vector2(speed, monsterBody.velocity.y);   
    }
}
