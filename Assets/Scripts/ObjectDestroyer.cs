using UnityEngine;

public class ObjectDestroyer : MonoBehaviour
{
  [SerializeField]
  private string collisionTag;

  private void OnTriggerEnter2D(Collider2D collider)
  {
    if (collider.gameObject.tag == collisionTag)
    {
      Destroy(collider.gameObject);
    }
  }
}
