using UnityEngine;
using Models;
using StateMachine;
using Views;

public class Enemy : MonoBehaviour
{
    [SerializeField] KillableCharacterModel enemyModel;
    [SerializeField] Animator anim;
    [SerializeField] Health.Health health;
    [SerializeField] StateMachineManager enemyStateMachine;
    [SerializeField] Poolable poolable;

    private GameView game;
    private static readonly int DIE_TRIGGER = Animator.StringToHash("Die");

    public Health.Health Health { get => health; }

    private void Awake()
    {
        health.HpPoints = enemyModel.HealthPoints;
        health.OnCharacterDead += Die;
        game = FindObjectOfType<GameView>();
    }

    public void Die()
    {
        game.OnEnemyKilled();
        enemyStateMachine.SwitchToNewState(typeof(DeathState));
        poolable.ReturnToPool();
    }
}
