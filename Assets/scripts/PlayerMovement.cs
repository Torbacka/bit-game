using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public float speed;

    private Vector2 _moveVelocity;
    private Rigidbody2D _rigidbody2D;

    // Start is called before the first frame update
    void Start() {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {
        _moveVelocity = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }

    void FixedUpdate() {
        _rigidbody2D.AddForce(_moveVelocity * speed * Time.fixedDeltaTime);
    }
}