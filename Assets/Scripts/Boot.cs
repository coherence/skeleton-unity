using System;
using Unity.Entities;
using UnityEngine;
using Coherence.Replication.Client.Unity.Ecs;

class Boot : MonoBehaviour
{
    void Start()
    {
        var args = Environment.GetCommandLineArgs();
        var isSimulationServer = false;

        foreach (var arg in args) {
            if(arg == "--simulation-server") {
                isSimulationServer = true;
            }
        }

        #if UNITY_EDITOR
        isSimulationServer = true;
        #endif

        var world = World.DefaultGameObjectInjectionWorld;
        var systemGroup = world.GetOrCreateSystem<PresentationSystemGroup>();

        if(isSimulationServer)
        {
            Debug.Log("Is simulation server.");
            var teamAssignSystem = world.GetOrCreateSystem<TeamAssignSystem>();
            teamAssignSystem.Enabled = true;
            systemGroup.AddSystemToUpdateList(teamAssignSystem);
        }
        else {
            Debug.Log("Is client.");
            var joinSystem = world.GetOrCreateSystem<JoinSystem>();
            joinSystem.Enabled = true;
            systemGroup.AddSystemToUpdateList(joinSystem);
        }

        systemGroup.SortSystems();
        ScriptBehaviourUpdateOrder.AddWorldToCurrentPlayerLoop(world);
    }
}
