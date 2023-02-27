using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollisionController : MonoBehaviour
{
  [SerializeField]
  private Rigidbody2D rb2d;

  [SerializeField]
  private LayerMask groundLayer;

  [SerializeField]
  private Transform groundCheck;

  [SerializeField]
  private GameObject score;

  public bool Grounded()
  {
    return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
  }

  private void OnTriggerEnter2D(Collider2D collider)
  {
    if (collider.gameObject.tag == "Enemy")
    {
      score.GetComponent<Score>().IncreaseScore();

      // Disable the collider afterwards to prevent double increment
      // I think its because the player has a polygon collider?
      collider.gameObject.GetComponent<BoxCollider2D>().enabled = false;
    }
  }

  private void OnCollisionEnter2D(Collision2D collision)
  {
    if (collision.gameObject.tag == "Enemy")
    {
      // TODO!
      SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
  }
}