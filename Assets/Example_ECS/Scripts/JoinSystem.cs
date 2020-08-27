using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;
//using UnityEngine.InputSystem;
using Coherence.Replication.Client.Unity.Ecs;
using Coherence.Replication.Client.Connection;
using Coherence.Generated.Internal.FirstProject;
using Coherence.Generated.FirstProject;
using Coherence.Sdk.Unity;
using UnityEngine;
using Unity.Rendering;
using System.Reflection;
using System;
using System.Linq;

[AlwaysUpdateSystem]
class JoinSystem : SystemBase
{
    bool hasSaidWeAreConnected = false;
    bool worldQueryCreated = false;
    bool localPlayerCreated = false;
    Entity player;

    protected override void OnStartRunning()
    {
        Debug.Log("The 'JoinSystem' will try to connect...");
        var coherenceRuntime = World.GetOrCreateSystem<CoherenceRuntimeSystem>();
        coherenceRuntime.Connect("127.0.0.1:32001", ConnectionType.Client);
    }

    protected override void OnUpdate()
    {
        var coherenceRuntime = World.GetOrCreateSystem<CoherenceRuntimeSystem>();
        if (coherenceRuntime.IsConnected && !hasSaidWeAreConnected)
        {
            Debug.Log("Now we are connected!");
            hasSaidWeAreConnected = true;
        }

        if(coherenceRuntime.IsConnected && !worldQueryCreated)
        {
            CreateWorldQuery();
        }

        if(coherenceRuntime.IsConnected && !localPlayerCreated)
        {
            TryToCreatePlayer();
        }

        Entities.WithNone<RenderMesh>().ForEach((Entity networkEntity,
                                                     in Player player) =>
        {
            var newEntity = CreatePlayer(false, new Entity());
            ReplaceEntity(networkEntity, newEntity);
        }).WithStructuralChanges().WithoutBurst().Run();
    }

    void CreateWorldQuery()
    {
        var localUserQuery = EntityManager.CreateEntityQuery(typeof(LocalUser));

        if(localUserQuery.CalculateEntityCount() == 0)
        {
            return;
        }

        var worldQueryEntity = EntityManager.CreateEntity();

        EntityManager.AddComponentData(worldQueryEntity, new CoherenceSimulateComponent
        {
            Authority = localUserQuery.GetSingletonEntity(),
        });

        EntityManager.AddComponentData(worldQueryEntity, new WorldPositionQuery
        {
            position = new float3(0, 0, 0),
        });

        worldQueryCreated = true;
    }

    void TryToCreatePlayer()
    {
        var localUserQuery = EntityManager.CreateEntityQuery(typeof(LocalUser));

        if(localUserQuery.CalculateEntityCount() == 0)
        {
            return;
        }

        var localUserAuthority = localUserQuery.GetSingletonEntity();
        player = CreatePlayer(true, localUserAuthority);
        localPlayerCreated = true;
    }

    private Entity CreatePlayer(bool localPlayer, Entity authority)
    {
        var playerPrefabEntity = PrefabHolder.Get().playerPrefabEntity;
        var newPlayerEntity = World.EntityManager.Instantiate(playerPrefabEntity);

        var query = EntityManager.CreateEntityQuery(typeof(Player));
        var playerCount = query.CalculateEntityCount();
        Debug.Log($"There are {playerCount} pre-existing players in the game world.");

        EntityManager.AddComponentData(newPlayerEntity, new Player()
        {

        });

        EntityManager.AddComponentData(newPlayerEntity, new Translation
        {
            Value = new float3(playerCount * 2.0f, 0.25f, 0.0f)
        });

        if(localPlayer)
        {
            EntityManager.AddComponentData(newPlayerEntity, new CoherenceSimulateComponent
            {
                Authority = authority,
            });

            EntityManager.AddComponentData(newPlayerEntity, new CoherenceSessionComponent
            {

            });

            EntityManager.AddComponentData(newPlayerEntity, new Input
            {
                Value = new float2()
            });
        }

        var localOrRemote = localPlayer ? "local" : "remote";
        Debug.Log($"Done creating {localOrRemote} player {newPlayerEntity.Index}");

        return newPlayerEntity;
    }

    private void ReplaceEntity(Entity networkEntity, Entity newEntity)
    {
#if UNITY_EDITOR
        EntityManager.SetName(newEntity, "Remote Player");
#endif

        //EntityManager.AddComponentData(newEntity, EntityManager.GetComponentData<CoherenceSimulateComponent>(networkEntity));
        CopyComponents(networkEntity, newEntity);

        // Remap
        var mapper = World.GetExistingSystem<SyncSendSystem>().Sender.Mapper;
        if (!mapper.ToCoherenceEntityId(networkEntity, out var entityId))
        {
            Debug.LogError("Networked Entity not found in mapper: " + networkEntity); // Should not happen
        }
        mapper.Remove(entityId);
        mapper.Add(entityId, newEntity);

        EntityManager.DestroyEntity(networkEntity);

        Debug.Log(string.Format("Replaced networked Entity {0}, {1} with {2}.", "?", networkEntity, newEntity));
    }

    public void CopyComponents(Entity src, Entity dst)
    {
        var entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;
        var types = entityManager.GetComponentTypes(src);

        foreach (ComponentType t in types)
        {
            //Debug.LogWarning($"TYPE: {t}");
            if (t == typeof(LinkedEntityGroup))
            {
                continue;
            }

            if (!entityManager.HasComponent(dst, t))
            {
                entityManager.AddComponent(dst, t);
            }

            MethodInfo getMethod = t.IsBuffer ? typeof(EntityManager).GetMethod("GetBuffer") : typeof(EntityManager).GetMethod("GetComponentData");
            if (getMethod != null)
            {
                MethodInfo getMethodGeneric = getMethod.MakeGenericMethod(t.GetManagedType());
                object cmp;
                try
                {
                    cmp = getMethodGeneric.Invoke(entityManager, new object[] { src });
                }
                catch (Exception)
                {
                    var setMethod = typeof(EntityManager).GetMethods().Single(
                                                                              m =>
                                                                              m.Name == (t.IsBuffer ? "AddBuffer" : "AddComponent") &&
                                                                              m.GetParameters().Length == 2 &&
                                                                              m.GetParameters()[0].ParameterType == typeof(Entity) &&
                                                                              !m.IsGenericMethod
                                                                              );


                    if (setMethod != null)
                    {
                        setMethod.Invoke(entityManager, new object[] { dst, t });
                    }

                    continue;
                }

                if (cmp != null)
                {
                    if (t.IsBuffer)
                    {
                        MethodInfo setMethod = typeof(EntityManager).GetMethod("AddBuffer");

                        if (setMethod != null)
                        {
                            MethodInfo setMethodGeneric = setMethod.MakeGenericMethod(t.GetManagedType());
                            setMethodGeneric.Invoke(entityManager, new object[] { dst });
                        }
                    }
                    else
                    {
                        var tt = Convert.ChangeType(cmp, t.GetManagedType());

                        MethodInfo setMethod = typeof(EntityManager).GetMethod("SetComponentData");

                        if (setMethod != null)
                        {
                            MethodInfo setMethodGeneric = setMethod.MakeGenericMethod(t.GetManagedType());
                            setMethodGeneric.Invoke(entityManager, new object[] { dst, tt });
                        }
                    }
                }
            }
        }
    }
}
