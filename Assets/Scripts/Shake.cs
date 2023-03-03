using System.Collections;
using UnityEngine;

public class Shake : MonoBehaviour
{
  [SerializeField]
  private float duration = 1f;

  [SerializeField]
  private AnimationCurve animationCurve;

  public IEnumerator ShakeRoutine()
  {
    Vector3 startPos = transform.position;
    float elapsedTime = 0f;

    while (elapsedTime < duration)
    {
      elapsedTime += Time.deltaTime;
      float strength = animationCurve.Evaluate(elapsedTime / duration);
      transform.position = startPos + Random.insideUnitSphere * strength;
      yield return null;
    }

    transform.position = startPos;
  }
}