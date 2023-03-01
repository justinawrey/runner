using UnityEngine;

interface IFreezable
{
  void Freeze();
}

public class StopAllMovement : MonoBehaviour
{
  public void Freeze()
  {
    StopSpawners();
    StopSnakeAnimations();
    FreezeComponent<Scrollable>();
    FreezeComponent<FixedMovement>();
    FreezeComponent<ParticleController>();
  }

  private void FreezeComponent<T>() where T : IFreezable
  {
    T[] everything = gameObject.GetComponentsInChildren<T>();

    for (int i = 0; i < everything.Length; i++)
    {
      T t = everything[i];
      t.Freeze();
    }
  }

  private void StopSpawners()
  {
    ObjectSpawner[] spawners = gameObject.GetComponentsInChildren<ObjectSpawner>();

    for (int i = 0; i < spawners.Length; i++)
    {
      ObjectSpawner spawner = spawners[i];
      spawner.StopSpawning();
    }
  }

  private void StopSnakeAnimations()
  {
    GameObject[] snakes = GameObject.FindGameObjectsWithTag("Enemy");

    for (int i = 0; i < snakes.Length; i++)
    {
      GameObject snake = snakes[i];
      snake.GetComponent<Animator>().enabled = false;
    }
  }
}
