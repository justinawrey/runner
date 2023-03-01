using System.Collections;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
  [SerializeField]
  private GameObject prefab;

  [SerializeField]
  private float minInterval = 0.5f;

  [SerializeField]
  private float maxInterval = 1.5f;

  [SerializeField]
  private float minSpeed = 1f;

  [SerializeField]
  private float maxSpeed = 1.2f;

  private Coroutine spawnRoutine;

  // Start is called before the first frame update
  private void Start()
  {
    GameObject p = Instantiate(prefab, transform.position, Quaternion.identity);
    p.transform.parent = transform.parent;
    spawnRoutine = StartCoroutine(SpawnRoutine());
  }

  private void OnDisable()
  {
    StopSpawning();
  }

  public void StopSpawning()
  {
    StopCoroutine(spawnRoutine);
  }

  private IEnumerator SpawnRoutine()
  {
    while (true)
    {
      float interval = Random.Range(minInterval, maxInterval);
      yield return new WaitForSeconds(interval);
      GameObject prefabObject = Instantiate(prefab, transform.position, Quaternion.identity);
      prefabObject.transform.parent = transform.parent;
      float speedFactor = Random.Range(minSpeed, maxSpeed);
      prefabObject.GetComponent<FixedMovement>().SetScrollSpeed(speedFactor);
    }
  }
}
