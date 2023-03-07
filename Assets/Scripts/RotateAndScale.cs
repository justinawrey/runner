using UnityEngine;

public class RotateAndScale : MonoBehaviour
{
  private bool scalingUp = true;

  [SerializeField]
  private float lowerScale = 0.9f;

  [SerializeField]
  private float upperScale = 1.1f;

  [SerializeField]
  private float scaleSpeed = 0.4f;

  [SerializeField]
  private float rotationAmount = 1;

  [SerializeField]
  private float rotationSpeed = 1;

  private void Update()
  {
    HandleScale();
  }

  private void HandleScale()
  {
    float currScale = gameObject.transform.localScale.x;
    float scaleAmount = scaleSpeed * Time.deltaTime;

    if (scalingUp)
    {
      gameObject.transform.localScale += new Vector3(scaleAmount, scaleAmount, 0);
    }
    else
    {
      gameObject.transform.localScale -= new Vector3(scaleAmount, scaleAmount, 0);
    }

    float newScale = gameObject.transform.localScale.x;

    if (newScale >= upperScale)
    {
      scalingUp = false;
    }

    if (newScale <= lowerScale)
    {
      scalingUp = true;
    }
  }
}
