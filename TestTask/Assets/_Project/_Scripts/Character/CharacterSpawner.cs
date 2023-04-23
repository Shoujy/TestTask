using UnityEngine;

public class CharacterSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private Transform _spawnPosition;

    private void Awake()
    {
        Instantiate(_player, _spawnPosition.position, Quaternion.identity);
    }
}
