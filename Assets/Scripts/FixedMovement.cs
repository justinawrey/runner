using UnityEngine;

public class FixedMovement : MonoBehaviour, IFreezable
{
  private float BASE_SCROLL_SPEED = 5f;
  private bool stopped = false;

  [SerializeField]
  private float scrollSpeed = 1f;

  private void Update()
  {
    if (stopped)
    {
      return;
    }

    transform.position -= new Vector3(BASE_SCROLL_SPEED * scrollSpeed * Time.deltaTime, 0, 0);
  }

  public void SetScrollSpeed(float speed)
  {
    scrollSpeed = speed;
  }

  public void Freeze()
  {
    stopped = true;
  }
}

