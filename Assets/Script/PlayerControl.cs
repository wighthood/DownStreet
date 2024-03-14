using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private Rigidbody2D Rigidbody2D;
    [SerializeField] private int speed;
   public void LeftRight (InputAction.CallbackContext context)
    {
        Rigidbody2D.velocity = (context.ReadValue<Vector2>() * speed);
    }

    public void shoot(InputAction.CallbackContext context)
    {
        if(context.started)
        {
            if (Rigidbody2D.velocity.y <= -0.5f)
            {
                Rigidbody2D.velocity = new Vector2(Rigidbody2D.velocity.x,-0.5f);
            }
            Rigidbody2D.velocity += Vector2.up * 0.25f;
        }
    }
}
