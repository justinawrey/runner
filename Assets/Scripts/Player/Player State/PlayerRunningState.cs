using UnityEngine;

public class PlayerRunningState : PlayerBaseState
{
  [SerializeField]
  private PlayerCollisionController collisionController;

  public override void OnUpdate(PlayerContext ctx)
  {
    if (PlayerInputController.JumpInputDown && collisionController.Grounded())
    {
      ctx.SwitchState(ctx.jumpingState);
    }
  }
}