using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;

public class combatAgent : Agent
{
    [SerializeField] private Transform leftWall;
    [SerializeField] private Transform rightWall;
    [SerializeField] private GameObject Player;
    [SerializeField] private GameObject Enemy;
    [SerializeField] private animationStateController animatorscript;
    [SerializeField] private enemyAnimationStateController animatorscriptEnemy;
    [SerializeField] private CombatMechanic combatMechanic;


    public override void OnEpisodeBegin()
    {
        combatMechanic.restart();
    }
    public override void CollectObservations(VectorSensor sensor)
    {
        //float leftWallDistance = Enemy.transform.localPosition.x - leftWall.localPosition.x;
        //float rightWallDistance = Enemy.transform.localPosition.x - rightWall.localPosition.x;
        float playerDistance = Enemy.transform.localPosition.x - Player.transform.localPosition.x;

        //sensor.AddObservation(leftWallDistance);
        //sensor.AddObservation(rightWallDistance);
        sensor.AddObservation(playerDistance);

        sensor.AddObservation(animatorscriptEnemy.animator.GetCurrentAnimatorStateInfo(0).IsName("blok") ? 1 : 0);
        sensor.AddObservation(animatorscriptEnemy.animator.GetCurrentAnimatorStateInfo(0).IsName("cios") ? 1 : 0);
        sensor.AddObservation(animatorscript.animator.GetCurrentAnimatorStateInfo(0).IsName("blok") ? 1 : 0);
        sensor.AddObservation(animatorscript.animator.GetCurrentAnimatorStateInfo(0).IsName("cios") ? 1 : 0);
        
        base.CollectObservations(sensor);
    }

    public override void OnActionReceived(ActionBuffers actions)
    {
        int move = actions.DiscreteActions[0]; // 0=stop 1=left 2=right 3=punch 4=block

        switch (move)
        {
            case 0: animatorscriptEnemy.left = false; animatorscriptEnemy.right = false; animatorscriptEnemy.punch = false; animatorscriptEnemy.block = false; break;
            case 1: combatMechanic.EnemyLeft(); animatorscriptEnemy.right = true; break;
            case 2: combatMechanic.EnemyRight(); animatorscriptEnemy.left = true; break;
            case 3: combatMechanic.EnemyPunch(); animatorscriptEnemy.punch = true; break;
            case 4: combatMechanic.EnemyBlock(); animatorscriptEnemy.block = true; break;
        }

        if(combatMechanic.playerHitted)
        {
            combatMechanic.playerHitted = false;
            AddReward(0.1f);
            if(combatMechanic.currentHealth <=0)
            {
                AddReward(1.0f);
                EndEpisode();
            }
        }

        if (combatMechanic.enemyHitted)
        {
            combatMechanic.enemyHitted = false;
            AddReward(-0.1f);
            if (combatMechanic.currentHealthEnemy <= 0)
            {
                AddReward(-1.0f);
                EndEpisode();
            }
        }

        AddReward(-1f/10000);
    }

    public override void Heuristic(in ActionBuffers actionsOut)
    {
        ActionSegment<int> discreteActions = actionsOut.DiscreteActions;

        if(Input.GetKey(KeyCode.LeftArrow))
        {
            discreteActions[0] = 1;
        } 
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            discreteActions[0] = 2;
        }
        else if(Input.GetKey(KeyCode.Keypad5))
        {
            discreteActions[0] = 3;
        }
        else if (Input.GetKey(KeyCode.Keypad6))
        {
            discreteActions[0] = 4;
        }
        else 
        {
            discreteActions[0] = 0;
        }
    }
}
