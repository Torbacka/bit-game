using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingAI : BaseDestructubleObject
{
    public Vector3 InitialMoveVector;
    public float Speed;

    private Vector3 CurrentMoveVector;
    private BoxCollider2D boxCollider;

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
        transform.position = CurrentPosition + InImpulse;

        ContactFilter2D ContactFilter = new ContactFilter2D();
        Collider2D[] Colliders = new Collider2D[1];
        boxCollider.OverlapCollider(ContactFilter, Colliders);

        if (Colliders[0] != null && Colliders[0].gameObject != null)
        {
            if (Colliders[0].gameObject.CompareTag("StaticObj"))
            {
                transform.position = CurrentPosition;
            }
        }
    }

    protected override void NotifyHit() 
    {

    }
}
