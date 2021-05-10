using System.Collections;
using System.Collections.Generic;
using UnityEngine;
        
//---------------------------------------------------------------------------------------------------------------------------------------------
// Gère le passage d'un state à un autre et garde un oeil sur le state actuel.
public class FiniteStateMachine
{
    public State currentState { get; private set; }

    public void Initialize(State startingState)
    {
        currentState = startingState;
        currentState.Enter();
    }

    public void ChangeState(State newState)
    {
        currentState.Exit();
        currentState = newState;
        currentState.Enter();
    }
}
