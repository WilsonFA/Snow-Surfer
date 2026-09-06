using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float amountTorque = 1f;
    [SerializeField] float baseSpeed = 15;
    [SerializeField] float boostSpeed = 20f;
    InputAction moveAction;
    Rigidbody2D myRigidBody2D;
    SurfaceEffector2D surfaceEffector2D;
    Vector2 moveVector;


    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        myRigidBody2D = GetComponent<Rigidbody2D>();
        surfaceEffector2D = FindAnyObjectByType<SurfaceEffector2D>();
    }


    void Update()
    {
        RotatePlayer();
        BoostPlayer();
    }

    void RotatePlayer()
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

    void BoostPlayer()
    {
        Vector2 moveVector;
        moveVector = moveAction.ReadValue<Vector2>();
        if (moveVector.y > 0)
        {
            surfaceEffector2D.speed = boostSpeed;
        }
        else
        {
            surfaceEffector2D.speed = baseSpeed;
        }
    }
}
