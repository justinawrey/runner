using System;
using UnityEngine;

[Serializable]
public struct PlayerContext
{
  public Action<PlayerBaseState> SwitchState;
  public Rigidbody2D rb;
  public PlayerRunningState runningState;
  public PlayerJumpingState jumpingState;
}

public class PlayerStateController : MonoBehaviour
{
  private PlayerBaseState currentState;

  [Tooltip("This context is passed through to each state.")]
  [SerializeField]
  private PlayerContext ctx;

  private void Awake()
  {
    ctx.SwitchState = SwitchState;
  }

  private void OnEnable()
  {
    currentState = ctx.runningState;
    currentState.Enter(ctx);
  }

  private void OnDisable()
  {
    currentState.Exit(ctx);
  }

  private void Update()
  {
    currentState.OnUpdate(ctx);
  }

  private void FixedUpdate()
  {
    currentState.OnFixedUpdate(ctx);
  }

  public void SwitchState(PlayerBaseState nextState)
  {
    currentState.Exit(ctx);
    currentState = nextState;
    currentState.Enter(ctx);
  }
}