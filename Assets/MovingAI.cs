using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingAI : MonoBehaviour
{
    public Vector3 InitialMoveVector;
    public float Speed;

    private Vector3 CurrentMoveVector;
    private BoxCollider2D boxCollider;
    private int direction = 1;
    private int prevDirection = 1;

    // Start is called before the first frame update
    void Start()
    {
        CurrentMoveVector = InitialMoveVector;
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 Impulse = CurrentMoveVector * Speed * Time.deltaTime;
        Move(Impulse);
    }

    private void Move(Vector3 InImpulse)
    {
        Vector3 CurrentPosition = transform.position;

        ContactFilter2D ContactFilter = new ContactFilter2D();
        Collider2D[] Colliders = new Collider2D[1];
        boxCollider.OverlapCollider(ContactFilter, Colliders);
        
        int multiplier = direction;

        if (Colliders[0] != null && Colliders[0].gameObject != null)
        {            
            direction = direction * -1;

            if (prevDirection != direction)
            {
                multiplier = multiplier * -1;
            }
            
            if (Colliders[0].gameObject.CompareTag("StaticObj"))
            {
                //transform.position = CurrentPosition;
            }
        }
        
        transform.position = CurrentPosition + multiplier * InImpulse;
        prevDirection = direction;
    }
}
