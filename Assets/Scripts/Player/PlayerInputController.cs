using UnityEngine;

static class PlayerInputController
{
  public static bool JumpInputDown => Input.GetKeyDown(KeyCode.Space);
  public static bool JumpInputUp => Input.GetKeyUp(KeyCode.Space);
}