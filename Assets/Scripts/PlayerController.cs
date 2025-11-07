using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float amountTorque = 1f;
    InputAction moveAction;
    Rigidbody2D myRigidBody2D;
    

    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        myRigidBody2D = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        Vector2 moveVector;
        moveVector = moveAction.ReadValue<Vector2>();
        if (moveVector.x < 0)
        {
            myRigidBody2D.AddTorque(amountTorque);
        }
        else if (moveVector.x > 0)
        {
            myRigidBody2D.AddTorque(-amountTorque);
        }
    }
}
