using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    public List<GameObject> tilesBoard;
    public Transform spawnPoint;
    int currentIndex = 0;
    public bool gameOver = false;
    [Space]
    [Header("UI Screens")]
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private Button playButton;
    private void Awake()
    {
        instance = this;
    }

    public static void GameOver()
    {
        if (instance.gameOver)
            return;
        SoundController.PlayMusic(false);
        instance.gameOver = true;
        instance.gameOverPanel.SetActive(true);

    }
    // Start is called before the first frame update
    void Start()
    {
        playButton.onClick.AddListener(() =>
        {

            InvokeRepeating(nameof(SpawnTileBoard), 0.5f, 1.5f);
            SoundController.PlayMusic(true);
            playButton.gameObject.SetActive(false);
        });
    }

    public void SpawnTileBoard()
    {
        if (gameOver)
            return;


        /* ObjectPool.instance.SpawnFromPool(tilesBoard[Random.Range(0, tilesBoard.Count)],
             spawnPoint.position, Quaternion.identity);*/


        Instantiate(tilesBoard[Random.Range(0, tilesBoard.Count)],
            spawnPoint.position, Quaternion.identity);
    }
    IEnumerator SpawnTilesBoard()
    {
        yield return new WaitForSeconds(0.5f);
    }


}
