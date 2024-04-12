using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.VFX;

public class GameManager : MonoBehaviour
{
    // static instance of the GameManager
    public static GameManager Instance { get; private set; }

    // Game elements
    [SerializeField] Transform _ceiling; // the spawn point of the enemies
    [SerializeField] int _points;
    [SerializeField] float _spawnRate = 2f;

    // Prefabs
    [SerializeField] GameObject _bunny;

    // Referances
    [SerializeField] TextMeshProUGUI _pointText;

    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
        } else
        {
            Instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        _points = 0;
        StartCoroutine(SpawnBunny());
    }

    public void AddPoints()
    {
        _points += 10;
        _pointText.text = _points.ToString();

        if(_points >= 100)
        {
            SceneManager.LoadScene("3A_WinEndScene");
        }
    }

    IEnumerator SpawnBunny() 
    { 
        if (_bunny != null) 
        {
            float spawnPointX = 0;
            while (true)
            {
                spawnPointX = Random.Range(-6f, 6f);
                Instantiate(_bunny, new Vector2(spawnPointX, _ceiling.position.y), Quaternion.identity);
                yield return new WaitForSeconds(_spawnRate);

            }
        }

    }

    public void ResetGame()
    {
        Destroy(gameObject);
    }
}
