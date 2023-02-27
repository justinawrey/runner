using UnityEngine;

public class ParticleController : MonoBehaviour
{
  [SerializeField]
  private ParticleSystem runningParticles;

  [SerializeField]
  private ParticleSystem launchingParticles;

  [SerializeField]
  private ParticleSystem landingParticles;

  private void Start()
  {
    runningParticles.Play();
    launchingParticles.Stop();
    landingParticles.Stop();
  }

  public void OnLaunch()
  {
    runningParticles.Stop();
    launchingParticles.Emit((int)Random.Range(6f, 10f));
  }

  public void OnLand()
  {
    landingParticles.Emit((int)Random.Range(6f, 10f));
    runningParticles.Play();
    runningParticles.Clear();
  }
}
