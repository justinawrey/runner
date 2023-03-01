using UnityEngine;

public class PlayerRunningState : PlayerBaseState
{
  [SerializeField]
  private PlayerInputController inputController;

  [SerializeField]
  private PlayerCollisionController collisionController;

  public override void OnUpdate(PlayerContext ctx)
  {
    if (inputController.JumpInputDown && collisionController.Grounded())
    {
      ctx.SwitchState(ctx.jumpingState);
    }
  }
}