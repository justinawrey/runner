using UnityEngine;
using UnityEngine.Tilemaps;

public class Scrollable : MonoBehaviour, IFreezable
{
  private float BASE_SCROLL_SPEED = 5f;
  private int REPOSITION_BUFFER_UNITS = 5;
  private Tilemap tileMap;
  private int width;
  private bool stopped = false;

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

  private void Update()
  {
    if (stopped)
    {
      return;
    }

    if (transform.position.x < -(width + REPOSITION_BUFFER_UNITS))
    {
      transform.position += new Vector3(width * 2, 0, 0);
    }
    else
    {
      transform.position -= new Vector3(BASE_SCROLL_SPEED * scrollSpeed * Time.deltaTime, 0, 0);
    }
  }

  public void Freeze()
  {
    stopped = true;
  }
}
