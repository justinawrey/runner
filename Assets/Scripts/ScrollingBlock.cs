using UnityEngine;

public class ScrollingBlock : MonoBehaviour
{
  [SerializeField]
  private float scrollSpeed = 1f;

  private void Update()
  {
    gameObject.transform.position -= new Vector3(scrollSpeed * Time.deltaTime, 0, 0);
  }
}
