using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnPool : MonoBehaviour
{
  public GameObject columnPrefab;
  private Vector2 objectPoolPosition = new Vector2(-15f, -25f);
  private GameObject[] columns;
  public int columnPoolSize = 5;
  private float timeSinceLastSpawn = 0f;
  public float spawnRate = 3f;
  public float columnMin = -3f;
  public float columnMax = 3f;
  private float spawnXPosition = 10f;
  private int currentColumn = 0;
  // Start is called before the first frame update
  void Start()
  {
    columns = new GameObject[columnPoolSize];
    for (int i = 0; i < columnPoolSize; i++)
    {
      columns[i] = Instantiate(columnPrefab, objectPoolPosition, Quaternion.identity);
    }
  }

  // Update is called once per frame
  void Update()
  {
    timeSinceLastSpawn += Time.deltaTime;

    if (!GameController.instance.gameOver && timeSinceLastSpawn >= spawnRate)
    {
      timeSinceLastSpawn = 0f;

      float spawnYPosition = Random.Range(columnMin, columnMax); 

      columns[currentColumn].transform.position = new Vector2(spawnXPosition, spawnYPosition);

      currentColumn++;
      currentColumn = currentColumn % columns.Length;
    }
  }
}
