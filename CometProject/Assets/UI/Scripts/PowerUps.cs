using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUps : MonoBehaviour {

    private GameObject player;
    private Collider playerCol;
    public GameObject puBtn;

	// Use this for initialization
	void Start ()
    {
        player = GameObject.FindWithTag("Player");
        playerCol = player.GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider playerCol)
    {
        RectTransform[] Children = GameObject.Find("ActivatePowerUp").GetComponentsInChildren<RectTransform>();
        if (Children.Length == 1) // If there is currently no powerup equipped
        {
            puBtn.SetActive(true);
        }
    }

    public void PowerUp1 () // Speed Boost: Player ball recieves an increase in speed for a short period of time. Recieved only by the bottom 75% of players.
    {
        GameObject.Find("PowerUp1Btn").SetActive(false);
    }

    public void PowerUp2() // Oil Slick: Instantiates a puddle of oil which slows down balls which collide with it for a short period of time. The oil is destroyed upon collision.
    {
        GameObject.Find("PowerUp2Btn").SetActive(false);
    }

    public void PowerUp3() // Bomb: Instantiates a bomb which emits explosive force shortly after activation and then is destroyed, affecting all balls within a certain radius of the bomb.
    {
        GameObject.Find("PowerUp3Btn").SetActive(false);
    }

    public void PowerUp4() // Invulnerability: Player ball recieves massive buff (speed boost, unaffected by traps or other players). Recieved only by the bottom 25% of players.
    {
        GameObject.Find("PowerUp4Btn").SetActive(false);
    }
}
