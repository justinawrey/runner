using UnityEngine;

public class Audio : MonoBehaviour
{
  [SerializeField]
  private AudioSource src;

  [SerializeField]
  private AudioClip jump, land, die;

  [SerializeField]
  private float jumpPitch, landPitch, diePitch, jumpVolume, landVolume, dieVolume;

  public void Jump()
  {
    src.clip = jump;
    src.volume = jumpVolume;
    src.pitch = jumpPitch;
    src.Play();
  }

  public void Land()
  {
    src.clip = land;
    src.volume = landVolume;
    src.pitch = landPitch;
    src.Play();
  }

  public void Die()
  {
    src.clip = die;
    src.volume = dieVolume;
    src.pitch = diePitch;
    src.Play();
  }
}
