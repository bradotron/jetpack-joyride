using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Column : MonoBehaviour
{
  void OnTriggerEnter2D(Collider2D other)
  {
    if (other.GetComponent<Astronaut>() != null)
    {
      GameController.instance.AstronautScored();
    }
  }
}
