using UnityEngine;

public class PlayerController
{
    Player player;
    ColliderManager colliderManager;
    public void Init(Player player)
    {
        this.player = player;
    }

    public Player getPlayer()
    {
        return player;
    }

    public void setColliderManager(ColliderManager colliderManager)
    {
        this.colliderManager = colliderManager;
    }

    public void move()
    {   
        if (player.getRigidbody().velocity == Vector2.zero)
            player.getBoxCollider().enabled = false;

        if ( Input.GetKeyDown(KeyCode.RightArrow) && player.getRigidbody().velocity == Vector2.zero)
        {
            player.getBoxCollider().enabled = true;
            Debug.Log("¿À¸¥ÂÊ!");

            player.getPlayerObj().transform.localScale = new Vector2(1, 1);
            player.getRigidbody().AddForce(player.myVelocity, ForceMode2D.Impulse);
        }
        
        else if (Input.GetKeyDown(KeyCode.LeftArrow) && player.getRigidbody().velocity == Vector2.zero)
        {
            player.getBoxCollider().enabled = true;
            Debug.Log("¿ÞÂÊ!");
            player.getPlayerObj().transform.localScale = new Vector2(-1, 1);
            player.getRigidbody().AddForce(-player.myVelocity, ForceMode2D.Impulse);
        }

        colliderManager.OnTriggerEnterToSide();
        colliderManager.OnTriggerEnterToEnermy();
    }
}
