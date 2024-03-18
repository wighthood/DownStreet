using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
   [SerializeField] private Rigidbody2D Rigidbody2D;
   [SerializeField] private TMP_Text text;
   [SerializeField] private int speed;
   private int score =0;
   public bool isgrounded = false;

    public void LeftRight(InputAction.CallbackContext context)
    {
        Rigidbody2D.velocity = (context.ReadValue<Vector2>() * speed);
    }
    public void shoot(InputAction.CallbackContext context)
    {
        Debug.Log("pew");
    }

    private void Update()
    {
        if (!isgrounded)
        {
            score += 100;
            text.SetText("score : " + score);
        }
    }
}
