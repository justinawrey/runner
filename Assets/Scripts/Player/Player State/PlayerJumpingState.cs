using System.Collections;
using UnityEngine;

public class PlayerJumpingState : PlayerBaseState
{
  private bool delayingCollision = false;

  [SerializeField]
  private PlayerInputController inputController;

  [SerializeField]
  private PlayerCollisionController collisionController;

  [SerializeField]
  private ParticleController particleController;

  [SerializeField]
  private Animator animator;

  [SerializeField]
  private float jumpForce = 9;

  [SerializeField]
  private float jumpCutMultiplier = 0.6f;

  [SerializeField]
  private float gravityScale = 5f;

  [SerializeField]
  private float fallMultiplier = 1.6f;

  public override void Enter(PlayerContext ctx)
  {
    // Delay the grounded collision for a small amount so we don't
    // immediately change state back to running
    StartCoroutine(CollisionDelay());
    ctx.rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
    animator.ResetTrigger("Landing");
    animator.SetTrigger("Launching");
    particleController.OnLaunch();
  }

  public override void Exit(PlayerContext ctx)
  {
    animator.ResetTrigger("Launching");
    animator.SetTrigger("Landing");
    animator.SetFloat("Vertical Velocity", 0);
    particleController.OnLand();
  }

  public override void OnUpdate(PlayerContext ctx)
  {
    if (!delayingCollision && collisionController.Grounded())
    {
      ctx.SwitchState(ctx.runningState);
    }

    // Apply jump cut
    if (inputController.JumpInputUp)
    {
      ctx.rb.AddForce(Vector2.down * ctx.rb.velocity.y * (1 - jumpCutMultiplier), ForceMode2D.Impulse);
    }
  }

  public override void OnFixedUpdate(PlayerContext ctx)
  {
    animator.SetFloat("Vertical Velocity", ctx.rb.velocity.y);

    // Extra downwards gravity for falling portion of jump
    if (ctx.rb.velocity.y < 0)
    {
      ctx.rb.gravityScale = gravityScale * fallMultiplier;
    }
    else
    {
      ctx.rb.gravityScale = gravityScale;
    }
  }

  private IEnumerator CollisionDelay()
  {
    delayingCollision = true;
    yield return new WaitForSeconds(0.1f);
    delayingCollision = false;
  }
}