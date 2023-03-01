using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Beam : MonoBehaviour
{
  [SerializeField]
  private float minIntensity = 0.1f;

  [SerializeField]
  private float maxIntensity = 0.2f;

  [SerializeField]
  private float minScale = 0.5f;

  [SerializeField]
  private float maxScale = 2f;

  void Start()
  {
    // Set a random intensity and scale
    Light2D light = gameObject.GetComponent<Light2D>();
    light.intensity = Random.Range(minIntensity, maxIntensity);
    gameObject.transform.localScale = new Vector3(Random.Range(minScale, maxScale), 1, 1);
  }
}
