using UnityEngine;

public class PlayerCollisionController : MonoBehaviour
{
  [SerializeField]
  private Rigidbody2D rb2d;

  [SerializeField]
  private LayerMask groundLayer;

  [SerializeField]
  private Transform groundCheck;

  public bool Grounded()
  {
    return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
  }
}