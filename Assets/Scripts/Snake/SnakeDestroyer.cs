using UnityEngine;

public class SnakeDestroyer : MonoBehaviour
{
  private void OnTriggerEnter2D(Collider2D collider)
  {
    if (collider.gameObject.tag == "Enemy")
    {
      Destroy(collider.gameObject);
    }
  }
}
