using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState : State
{
    protected D_MoveState stateData;

    protected bool isDetectingWall;
    protected bool isDetectingLedge;
    protected bool isPlayerInMinAgroRange;
    public MoveState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_MoveState stateData) : base(entity, stateMachine, animBoolName)
    {
        //---------------------------------------------------------------------------------------------------------------------------------------------
        // Ici la variable "stateData" est rajoutée dans le constructeur de "MoveState", en plus des variables déjà existantes dans la Classe "State".
        this.stateData = stateData;
    }

    public override void DoChecks()
    {
        base.DoChecks();

        isDetectingLedge = entity.CheckLedge();
        isDetectingWall = entity.CheckWall();
        isPlayerInMinAgroRange = entity.CheckPlayerInMinAgroRange();
    }

    public override void Enter()
    {
        //---------------------------------------------------------------------------------------------------------------------------------------------
        // Ici le "base.Enter()" rappel la fonction de base avant de lui ajouter l'instruction "entity.SetVelocity...". Néanmoins il est possible
        // d'éviter le rappel de la fonction de base en supprimant "base.Enter()".
        base.Enter();
        entity.SetVelocity(stateData.movementSpeed);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

}
