using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUps : MonoBehaviour {

    private GameObject player, bomb, oil;
    private Collider playerCol;
    private Vector3 playerPos;
    private Transform explosion;
    public GameObject[] puBtn;

    void Start ()
    {
        player = GameObject.FindWithTag("Player");
        playerCol = player.GetComponent<Collider>();
    }

    private void Update()
    {
        gameObject.transform.RotateAround(transform.position, transform.up, Time.deltaTime * 90f);
        playerPos = player.transform.position;
    }

    private void OnTriggerEnter(Collider playerCol)
    {
        // Set random powerup button to active
        int randomPU = Random.Range(0, 4);
        RectTransform[] Children = GameObject.Find("ActivatePowerUp").GetComponentsInChildren<RectTransform>();
        if (Children.Length == 1) // If there is currently no powerup equipped
        {
            puBtn[randomPU].SetActive(true);
        }
        gameObject.GetComponent<Renderer>().enabled = false;
        gameObject.GetComponent<Collider>().enabled = false;
        StartCoroutine(Wait4());
    }

    // Speed Boost: Player ball recieves an increase in speed for a short period of time. Recieved only by the bottom 75% of players.
    public void PowerUp1 () 
    {
        // Remove powerup icon
        puBtn[0].SetActive(false);
        // Double speed
        player.GetComponent<Controller>().speed *= 2;
        // Start countdown to halve speed
        StartCoroutine(Wait1());
    }

    // Oil Slick: Instantiates a puddle of oil which slows down balls which collide with it for a short period of time. The oil is destroyed upon collision.
    public void PowerUp2()
    {
        puBtn[1].SetActive(false);
        Vector3 vel = player.GetComponent<Rigidbody>().velocity;
        Vector3 direction = Vector3.Normalize(vel);
        // Instantiate 3 units behind player.
        oil = Instantiate(Resources.Load("OilSpill") as GameObject, new Vector3(playerPos.x - direction.x * 3.0f, 
            (playerPos.y - direction.y) - (PlayerPrefs.GetFloat("Size") / 2) + 0.1f,
            playerPos.z - direction.z * 3.0f), Quaternion.identity);
    }

    // Bomb: Instantiates a bomb which emits explosive force shortly after activation and then is destroyed, affecting all balls within a certain radius of the bomb.
    public void PowerUp3() 
    {
        // Remove powerup icon
        puBtn[2].SetActive(false);
        // Instantiate bomb
        bomb = Instantiate(Resources.Load("BombBall") as GameObject, new Vector3(playerPos.x, playerPos.y + 1f, playerPos.z), Quaternion.identity);
        // Start countdown to explosion
        StartCoroutine(Wait2());
    }

    // Invulnerability: Player ball recieves massive buff (speed, mass and size increase). Recieved only by the bottom 25% of players.
    public void PowerUp4() 
    {
        // Remove powerup icon
        puBtn[3].SetActive(false);
        // Increase Speed, mass and size
        player.GetComponent<Controller>().speed *= 10;
        player.GetComponent<Rigidbody>().mass *= 5;
        player.transform.localScale *= 2;
        // Start countdown to remove buffs
        StartCoroutine(Wait3());
    }
 
// Coroutines =================

    public IEnumerator Wait1()
    {
        yield return new WaitForSeconds(4f); // waits 4 seconds
        player.GetComponent<Controller>().speed /= 2; // half speed
    }

    public IEnumerator Wait2()
    {
        yield return new WaitForSeconds(4f); // waits 4 seconds
        // Instantiate explosion and explosive force
        explosion = Instantiate(Resources.Load("Explosion", typeof(Transform)) as Transform, bomb.transform.position, Quaternion.identity);
        bomb.transform.GetComponentInChildren<Rigidbody>().AddExplosionForce(10.0f, bomb.transform.position, 0.5f, 0f, ForceMode.Impulse);
        Destroy(bomb);
    }

    public IEnumerator Wait3()
    {
        yield return new WaitForSeconds(6f); // waits 6 seconds
        // set values back to normal
        player.GetComponent<Controller>().speed /= 10;
        player.GetComponent<Rigidbody>().mass /= 5;
        player.transform.localScale /= 2;
    }

    public IEnumerator Wait4()
    {
        yield return new WaitForSeconds(6f); // waits 5 seconds
        gameObject.GetComponent<Renderer>().enabled = true;
        gameObject.GetComponent<Collider>().enabled = true;
    }
}
