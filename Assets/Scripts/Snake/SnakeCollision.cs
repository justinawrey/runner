using UnityEngine;

public class SnakeCollision : MonoBehaviour
{
  // Dont allow snakes to collide with eachother
  private void OnCollisionEnter2D(Collision2D collision)
  {
    if (collision.gameObject.tag == "Enemy")
    {
      Physics2D.IgnoreCollision(GetComponent<PolygonCollider2D>(), collision.collider);
    }
  }
}
