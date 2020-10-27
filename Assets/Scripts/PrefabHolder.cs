using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

// This script needs to be on a GameObject with a ConvertToEntity component
// set to "Convert and Inject Game Object", or nothing will happen!

public class PrefabHolder : MonoBehaviour, IDeclareReferencedPrefabs, IConvertGameObjectToEntity
{
    public GameObject playerPrefab;
    public Entity playerPrefabEntity;

    public GameObject otherPlayerPrefab;
    public Entity otherPlayerPrefabEntity;

    public GameObject shotPrefab;
    public Entity shotPrefabEntity;

    public void DeclareReferencedPrefabs(List<GameObject> referencedPrefabs)
    {
        referencedPrefabs.Add(playerPrefab);
        referencedPrefabs.Add(otherPlayerPrefab);
        referencedPrefabs.Add(shotPrefab);
    }

    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        playerPrefabEntity = conversionSystem.GetPrimaryEntity(playerPrefab);
        otherPlayerPrefabEntity = conversionSystem.GetPrimaryEntity(otherPlayerPrefab);
        shotPrefabEntity = conversionSystem.GetPrimaryEntity(shotPrefab);
    }

    public static PrefabHolder Get()
    {
        return FindObjectOfType<PrefabHolder>();
    }
}
