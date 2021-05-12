using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//---------------------------------------------------------------------------------------------------------------------------------------------
// Classe de base dont tous les autres states, vont hériter !
// MonoBehavior n'est pas utlisé en tant que classe, car aucun besoin de lier ce script à un objet (entre autres raisons j'imagine)
// Gère principalement le LANCEMENT DES ANIMATIONS EN FONCTION DU STATE UTILISE !
public class PlayerState 
{    
    //---------------------------------------------------------------------------------------------------------------------------------------------
    // protected est utilisé pour limiter l'accéss aux variables à seulement cette la classe en particulier ainsi qu'à chacunes de ses subclasses
    // private se limitant à la classe en question !
    protected Core core;
    protected Player player;

    protected PlayerStateMachine stateMachine;

    //---------------------------------------------------------------------------------------------------------------------------------------------
    // La référence à "PlayerData" au sein de la classe PlayerState, permet à chaques substates d'accéder aux variables qui affectent
    // le joueur.
    protected PlayerData playerData;

    protected bool isAnimationFinished;
    protected bool isExitingState;

    //---------------------------------------------------------------------------------------------------------------------------------------------
    // Permet d'avoir une référence temporelle à chaque fois que l'on entre dans un state.
    protected float startTime;

    //---------------------------------------------------------------------------------------------------------------------------------------------
    // Chaque States se voient dotés d'une chaîne de charactères lors de la création de ces derniers et elle sera utilisée afin de 
    // communiquer quelles animations doivent êtres jouées dans l'animator.
    private string animBoolName;
    

    //---------------------------------------------------------------------------------------------------------------------------------------------
    // Création du constructeur de la classe qui va prendre comme argument, les 4 éléments disposés entre "()", cela servant à initialiser
    // les variables de la classe.
    public PlayerState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName)
    {
    
    //---------------------------------------------------------------------------------------------------------------------------------------------
    // Ici on assigne chacunes des variables requises à la mise en place du constructeur.
    // Par exemple this.player fait référence à "protected player" et "... = player", fait référence a la variable "player" présent dans le
    // constructeur qui contient la classe "Player".
        this.player = player;
        this.stateMachine = stateMachine;
        this.playerData = playerData;
        this.animBoolName = animBoolName;
        core = player.Core;
    }    

    //---------------------------------------------------------------------------------------------------------------------------------------------
    // La fonction "Enter" est appelée quand nous entrons dans un state.
    // Le terme "virtual" est utilisé pour permettre "l'override" par d'autres classes qui héritent de celle ci.
    public virtual void Enter()
    {
        DoChecks();
        player.Anim.SetBool(animBoolName, true);
        startTime = Time.time;
        isAnimationFinished = false;
        isExitingState = false;
    }

    //---------------------------------------------------------------------------------------------------------------------------------------------
    // La fonction "Exit" est appelée quand nous sortons d'un state.
    public virtual void Exit()
    {
        player.Anim.SetBool(animBoolName, false);
        isExitingState = true;
    }

    //---------------------------------------------------------------------------------------------------------------------------------------------
    // "LogicUpdate" est comparable à la fonction "Update" native d'Unity.
    public virtual void LogicUpdate()
    {

    }

    //---------------------------------------------------------------------------------------------------------------------------------------------
    // "PhysicsUpdate" est comparable à la fonction "FixedUpdate" native d'Unity.
    public virtual void PhysicsUpdate()
    {
        DoChecks();
    }

    //---------------------------------------------------------------------------------------------------------------------------------------------
    // Fonction utilisée pour la détection principalement, comme celle du sol, des murs, plafonds etc. Elle est appelée dans les fonctions
    // "Enter" et "PhysicsUpdate" car ce sont ces fonctions qui permettent la détection des éléments de façon optimisée.
    public virtual void DoChecks()
    {

    }

    public virtual void AnimationTrigger() 
    {

    }

    public virtual void AnimationFinishTrigger() => isAnimationFinished = true;
}
