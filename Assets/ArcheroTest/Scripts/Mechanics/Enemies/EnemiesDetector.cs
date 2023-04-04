using UnityEngine;

public class EnemiesDetector : MonoBehaviour
{
    public SpawnEnemies EnemiesSpawner;
    public PlayerMove Player;

    public bool CheckEnemyOnLevel(out Enemy enemy)
    {
        enemy = null;
        if (EnemiesSpawner.Enemies.Count == 0)
        {
            return false;
        }

        float minDistanse = float.MaxValue;

        foreach (var item in EnemiesSpawner.EnemiesOnLevel)
        {
            float CurDistanseToPlayer = (item.transform.position - Player.transform.position).sqrMagnitude;
            if (CurDistanseToPlayer < minDistanse)
            {
                minDistanse = CurDistanseToPlayer;
                enemy = item;
            }
        }

        return enemy != null;
    }

}
