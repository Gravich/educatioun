using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager Instanse;
    public float Timer;
    public List<Creature> CreaturesPrefabs;
    private void Awake()
    {
        if (Instanse == null)
        {
            Instanse = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void Respawn(Creature target)
    {
        Destroy(target.gameObject);
        Instanse.StartCoroutine(GoToRespawn(target.GetType(), target.spawnPoint, target.RespawnData));
    }

    private IEnumerator GoToRespawn(System.Type obj, Vector3 spawnPosition, object _respawnData)
    {
        yield return new WaitForSeconds(Timer);
        foreach (var creature in CreaturesPrefabs)
        {
            if (creature.GetType() == obj)
            {
                Instantiate(creature, spawnPosition, new Quaternion()).RespawnData = _respawnData;
                break;
            }
        }
        Debug.Log("Время и стекло");
    }
}
