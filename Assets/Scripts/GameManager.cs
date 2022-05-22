using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject[] players;
    [SerializeField] Queue<GameObject> playerQueue;
    GameObject currentPlayer;
    [SerializeField] GameObject playerSpawnPoint;

    void Start()
    {
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

        if (playerQueue.Count == 0) return;

        currentPlayer = Instantiate(playerQueue.Dequeue(), playerSpawnPoint.transform.position, Quaternion.identity);
    }
}
