using System.Collections;
using UnityEngine;

public class SnakeSpawner : MonoBehaviour
{
  [SerializeField]
  private GameObject snakePrefab;

  // Start is called before the first frame update
  private void Start()
  {
    Instantiate(snakePrefab, transform.position, Quaternion.identity);
    StartCoroutine(SpawnRoutine());
  }

  private void OnDisable()
  {
    StopCoroutine(SpawnRoutine());
  }

  private IEnumerator SpawnRoutine()
  {
    while (true)
    {
      float interval = Random.Range(0.8f, 1.8f);
      yield return new WaitForSeconds(interval);
      GameObject snake = Instantiate(snakePrefab, transform.position, Quaternion.identity);
      float speedFactor = Random.Range(1f, 1.5f);
      snake.GetComponent<SnakeMovement>().SetScrollSpeed(speedFactor);
    }
  }
}
