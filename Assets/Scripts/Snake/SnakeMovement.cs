using UnityEngine;

public class SnakeMovement : MonoBehaviour
{
  private float BASE_SCROLL_SPEED = 5f;

  [SerializeField]
  private float scrollSpeed = 1f;

  private void Update()
  {
    transform.position -= new Vector3(BASE_SCROLL_SPEED * scrollSpeed * Time.deltaTime, 0, 0);
  }

  public void SetScrollSpeed(float speed)
  {
    scrollSpeed = speed;
  }
}

