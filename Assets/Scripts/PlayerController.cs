using System;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float speed;

    private Vector2 _moveVelocity;
    private Rigidbody2D _rigidbody2D;

    // Start is called before the first frame update
    void Start() {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _rigidbody2D.freezeRotation = true;
    }

    private void Update() {
        _moveVelocity = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        
    }

    void FixedUpdate() {
        Debug.Log(_moveVelocity*speed);
        _rigidbody2D.MovePosition(_rigidbody2D.position + _moveVelocity * speed * Time.fixedDeltaTime);
    }
}