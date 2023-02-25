using UnityEngine;

public class PlayerBaseState : MonoBehaviour
{
  public virtual void Enter(PlayerContext ctx) { }
  public virtual void Exit(PlayerContext ctx) { }
  public virtual void OnUpdate(PlayerContext ctx) { }
  public virtual void OnFixedUpdate(PlayerContext ctx) { }
}