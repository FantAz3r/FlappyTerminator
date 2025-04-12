using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Button _startButton;
    [SerializeField] private Player _player;
    [SerializeField] private EnemySpawner _enemySpawner;
    [SerializeField] private BulletSpawner _bulletSpawner;
    [SerializeField] private GameObject _restartPanel;
    [SerializeField] private Button _restartButton;

    private void OnEnable()
    {
        _player.Crushed += GameOver;
        _startButton.onClick.AddListener(HandleButtonClick);
    }

    private void OnDisable()
    {
        _player.Crushed -= GameOver;
        _startButton.onClick.RemoveListener(HandleButtonClick);
    }

    private void HandleButtonClick()
    {
        Time.timeScale = 1f;
        _enemySpawner.StartSpawn();
        _player.Reset();
        _restartPanel.SetActive(false);
    }

    private void GameOver()
    {
        Time.timeScale = 0f;
        _enemySpawner.StopSpawn();
        _bulletSpawner.RemoveBullets();
        _restartPanel.SetActive(true);
    }
}
