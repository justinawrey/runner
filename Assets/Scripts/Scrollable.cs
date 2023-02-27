using UnityEngine;
using UnityEngine.Tilemaps;

public class Scrollable : MonoBehaviour
{
  private float BASE_SCROLL_SPEED = 5f;
  private Tilemap tileMap;
  private int width;

  [SerializeField]
  private float scrollSpeed = 1f;

  private void Start()
  {
    tileMap = GetComponent<Tilemap>();
    BoundsInt bounds = tileMap.cellBounds;
    width = bounds.xMax - bounds.xMin;
  }

  [ContextMenu("Check width")]
  private void CheckWidth()
  {
    var tm = GetComponent<Tilemap>();
    var width = tm.cellBounds.xMax - tm.cellBounds.xMin;
    print($"WIDTH: {width}");
  }

  [ContextMenu("Compress bounds")]
  private void CompressBounds()
  {
    GetComponent<Tilemap>().CompressBounds();
  }

  private void Update()
  {
    if (transform.position.x < -width)
    {
      transform.position += new Vector3(width * 2, 0, 0);
    }
    else
    {
      transform.position -= new Vector3(BASE_SCROLL_SPEED * scrollSpeed * Time.deltaTime, 0, 0);
    }
  }
}
