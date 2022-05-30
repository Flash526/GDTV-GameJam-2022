using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject[] players;
    [SerializeField] Queue<GameObject> playerQueue;
    [SerializeField] GameObject playerSpawnPoint;
    [SerializeField] float waitTimeForNextCharacter = 1f;
    [SerializeField] GameObject deathCanvas;

    PlayerInput controls;
    GameObject currentPlayer;

    void Start()
    {
        controls = new PlayerInput();
        controls.Player.Reset.performed += context => Reset();
        controls.Enable();

        playerQueue = new Queue<GameObject>();

        foreach (GameObject player in players)
        {
            playerQueue.Enqueue(player);
        }

        NextPlayer();
    }

    public void NextPlayer()
    {
        if (currentPlayer != null)
        {
            Destroy(currentPlayer);
        }

        if (playerQueue.Count == 0)
        {
            deathCanvas.SetActive(true);
            return;
        }

        StartCoroutine(SpawnNextPlayer());
    }

    IEnumerator SpawnNextPlayer()
    {
        yield return new WaitForSeconds(waitTimeForNextCharacter);

        currentPlayer = Instantiate(playerQueue.Dequeue(), playerSpawnPoint.transform.position, Quaternion.identity);

        if (playerQueue.Count == 0)
        {
            FindObjectOfType<Exit>().OpenDoor();
        }

    }

    void Reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
