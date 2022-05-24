using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupObject : MonoBehaviour
{
    public SpriteRenderer graphics;
    public int dbjTime;
    public bool coin;

    void Start()
    {
        if (!coin) graphics.color = new Color(1f, 0, 0, 1f);
    }
    
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && coin)
         {
              Inventory.instance.AddCoins(1);
              Destroy(gameObject);
         }
         if (collision.CompareTag("Player") && !coin)
         {
              PlayerMovement.instance.DoubleJump(dbjTime);
              Destroy(gameObject);
         }

     }
}
