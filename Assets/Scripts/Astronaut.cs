using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Astronaut : MonoBehaviour
{
  private bool IsDead;
  private Rigidbody2D rb2d;
  private Animator animator;
  public float upForce = 200f;

  // Start is called before the first frame update
  void Start()
  {
    rb2d = GetComponent<Rigidbody2D>();
    animator = GetComponent<Animator>();
  }

  // Update is called once per frame
  void Update()
  {
    if (!IsDead)
    {
      if (Input.GetKeyDown(KeyCode.Space))
      {
        rb2d.velocity = Vector2.zero;
        rb2d.AddForce(new Vector2(0, upForce));
        animator.SetTrigger("Jet");
      }
    }
  }

  void OnCollisionEnter2D()
  {
    IsDead = true;
    animator.SetTrigger("Die");
    GameController.instance.AstronautDied();
  }
}
