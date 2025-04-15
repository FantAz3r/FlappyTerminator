using System;
using UnityEngine;

[RequireComponent(typeof(PlayerMover))]
[RequireComponent(typeof(PlayerCollisionHandler))]
[RequireComponent(typeof(Health))]
public class Player : MonoBehaviour
{
    private PlayerMover _playerMover;
    private PlayerCollisionHandler _handler;
    private InputService _inputService;
    private PlayerAttacker _playerAttack;
    private Health _health;

    public event Action Crushed;

    private void Awake()
    {
        _handler = GetComponent<PlayerCollisionHandler>();
        _playerMover = GetComponent<PlayerMover>();
        _inputService = GetComponent<InputService>();
        _playerAttack = GetComponent<PlayerAttacker>();
        _health = GetComponent<Health>();
    }

    private void OnEnable()
    {
        _handler.CollisionDetected += ProcessCollision;
        _inputService.Jumped += _playerMover.Jump;
        _inputService.Attacked += Attack;
        _health.Died += OnDied;
    }

    private void OnDisable()
    {
        _handler.CollisionDetected -= ProcessCollision;
        _inputService.Jumped -= _playerMover.Jump;
        _inputService.Attacked -= Attack;
        _health.Died -= OnDied;
    }

    public void Reset()
    {
        _playerMover.Reset();
        _health.Heal(_health.MaxHealth - _health.CurrentHealth);
    }

    private void OnDied()
    {
        Crushed?.Invoke();
    }

    private void ProcessCollision(IObstacle interactable)
    {
        Crushed?.Invoke();
    }

    private void Attack()
    {
        _playerAttack.Shoot(); 
    }
}

