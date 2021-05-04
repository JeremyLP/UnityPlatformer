using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Contient les références des states dans lesquels on se trouve.
public class PlayerStateMachine 
{
    //---------------------------------------------------------------------------------------------------------------------------------------------
    // Le "{ get; private set; }" signifie que tout autre script ayant une référence à cette variable
    // pourra récupérer son contenu mais pas le modifier.
    public PlayerState CurrentState { get; private set; } 

    //---------------------------------------------------------------------------------------------------------------------------------------------
    // Fonction qui initialise le state actuel en récupérant les informations du constructeur "PlayerState".
    public void Initialize(PlayerState startingState)
    {
        CurrentState = startingState;
        CurrentState.Enter();
    }
    //---------------------------------------------------------------------------------------------------------------------------------------------
    // Fonction qui nous sort du state actuel pour en activer un nouveau.
    public void ChangeState(PlayerState newState)
    {
        CurrentState.Exit();
        CurrentState = newState;
        CurrentState.Enter(); 
    }
}
