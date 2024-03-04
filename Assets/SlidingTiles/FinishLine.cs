using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{


    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (collision.CompareTag("Player"))
        {


            Destroy(collision.transform.parent.gameObject);//.SetActive(false);
          // ObjectPool.instance.RecycleToPool(collision.transform.parent.gameObject);
        }
        else if (collision.CompareTag("Tiles"))
        {

            print("Unfinishedtile " + collision.gameObject.name);
            if (!collision.GetComponent<Tiles>().tilesPressed)
            {
                print("game failed");
                GameController.GameOver();
                TileBoard.OnTileSpeedChanged?.Invoke(0);
            }
        }
    }

}
