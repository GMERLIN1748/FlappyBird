using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject _pipe;

    [SerializeField]
    private float _yoffsetMin = 1f, _yoffsetMax = 3f;

    [SerializeField]
    private birdscript _player;

    private float _spawnFrequency = 3f;

    private float _timeTillNextSpawn = 0f;


    // Update is called once per frame
    void Update()
    {
        if (_timeTillNextSpawn <= 0f && _player.IsAlive)
        {
            Vector3 newPosition = new Vector3(transform.position.x, Random.Range(_yoffsetMin, _yoffsetMax));
            Instantiate(_pipe, newPosition, transform.rotation);
            _timeTillNextSpawn = _spawnFrequency; ;
        }
        else
        {
            _timeTillNextSpawn -= Time.deltaTime;
        }
    }
}