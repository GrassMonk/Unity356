using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class PowerUps : MonoBehaviour {

    private GameObject bomb, oil;
    private Transform explosion;
    public GameObject[] puBtn;
    private AudioSource collect, pu1Sound, pu2Sound, pu31Sound, pu32Sound, pu4Sound;

    private void Start()
    {
        collect = GameObject.Find("PUSound").GetComponent<AudioSource>();
        pu1Sound = GameObject.Find("PU1Sound").GetComponent<AudioSource>();
        pu2Sound = GameObject.Find("PU2Sound").GetComponent<AudioSource>();
        pu31Sound = GameObject.Find("PU3-1Sound").GetComponent<AudioSource>();
        pu32Sound = GameObject.Find("PU3-2Sound").GetComponent<AudioSource>();
        pu4Sound = GameObject.Find("PU4Sound").GetComponent<AudioSource>();
    }

    private void Update()
    {
        gameObject.transform.RotateAround(transform.position, transform.up, Time.deltaTime * 90f);
    }

    private void OnTriggerEnter(Collider collision)
    {
        collect.pitch = UnityEngine.Random.Range(0.5f, 2);
        collect.Play();
        // get current progress
        float [] totProg = GameObject.Find("Player").GetComponent<TrackPosition>().totProg;
        int place = GameObject.Find("Player").GetComponent<TrackPosition>().place;
        GameObject player = collision.gameObject;
        int randomPU;

        if (collision.gameObject.tag == "Player") // if player
        {
            if (place == totProg.Length + 1) // if player in last place
                randomPU = Random.Range(3, 4); // Give Invulnerability
            else
                randomPU = Random.Range(0, 3);  // Set random powerup button to active
            RectTransform[] Children = GameObject.Find("ActivatePowerUp").GetComponentsInChildren<RectTransform>();
            if (Children.Length == 1) // If there is currently no powerup equipped
            {
                puBtn[randomPU].SetActive(true);
            }
            // Temporarily remove powerup
            gameObject.GetComponent<Renderer>().enabled = false;
            gameObject.GetComponent<Collider>().enabled = false;
            StartCoroutine(Wait4(player));
        }
        else if (collision.gameObject.tag == "racer0" || 
            collision.gameObject.tag == "racer1" ||
            collision.gameObject.tag == "racer2" ||
            collision.gameObject.tag == "racer3" ||
            collision.gameObject.tag == "racer4" ||
            collision.gameObject.tag == "racer5" ||
            collision.gameObject.tag == "racer6" ||
            collision.gameObject.tag == "racer7" ) // if AI racer
        {
            int lastPlace = 0;
            for (int i = 0; i < totProg.Length; i++)
                if (totProg[i] < totProg[lastPlace])
                    lastPlace = i;
            if (player.tag == "racer"+lastPlace && place != totProg.Length + 1) // if AI in last place
                randomPU = Random.Range(3, 4); // Give Invulnerability
            else
                randomPU = Random.Range(0, 3);  // Set random powerup button to active
            StartCoroutine(Wait5(randomPU, player)); // Delay activation
            // Temporarily remove powerup
            gameObject.GetComponent<Renderer>().enabled = false;
            gameObject.GetComponent<Collider>().enabled = false;
            StartCoroutine(Wait4(player));
        }
    }

    // Speed Boost: Player ball recieves an increase in speed for a short period of time. Recieved only by the bottom 75% of players.
    public void PowerUp1 (GameObject player)
    {
        pu1Sound.pitch = UnityEngine.Random.Range(0.5f, 2);
        pu1Sound.Play();
        // Double speed
        if (player.gameObject.tag == "Player")
        {
            // Remove powerup icon
            puBtn[0].SetActive(false);
            player.GetComponent<Controller>().acceleration *= 2;
            player.GetComponent<Controller>().maxSpeed *= 2;
        }
        else
            player.GetComponent<NavMeshAgent>().speed *= 2;
        // Start countdown to halve speed
        StartCoroutine(Wait1(player));
    }

    // Oil Slick: Instantiates a puddle of oil which slows down balls which collide with it for a short period of time. The oil is destroyed upon collision.
    public void PowerUp2(GameObject player)
    {
        pu2Sound.pitch = UnityEngine.Random.Range(0.5f, 2);
        pu2Sound.Play();
        Vector3 vel;
        if (player.gameObject.tag == "Player")
        {
            puBtn[1].SetActive(false);
            vel = player.GetComponent<Rigidbody>().velocity;
        }
        else
            vel = player.GetComponent<NavMeshAgent>().velocity;
        Vector3 playerPos = player.transform.position;
        Vector3 direction = Vector3.Normalize(vel);
        // Instantiate 5 units behind player.
        oil = Instantiate(Resources.Load("OilSpill") as GameObject, new Vector3(playerPos.x - direction.x * 5.0f, 
            (playerPos.y - direction.y) - (player.transform.localScale.y / 2) + 0.1f,
            playerPos.z - direction.z * 5.0f), Quaternion.identity);
    }

    // Bomb: Instantiates a bomb which emits explosive force shortly after activation and then is destroyed, affecting all balls within a certain radius of the bomb.
    public void PowerUp3(GameObject player)
    {
        pu31Sound.Play();
        // Remove powerup icon
        if (player.gameObject.tag == "Player")
            puBtn[2].SetActive(false);
        Vector3 playerPos = player.transform.position;
        // Instantiate bomb
        bomb = Instantiate(Resources.Load("BombBall") as GameObject, new Vector3(playerPos.x, playerPos.y + 1f, playerPos.z), Quaternion.identity);
        // Start countdown to explosion
        StartCoroutine(Wait2(player));
    }

    // Invulnerability: Player ball recieves massive buff (speed, mass and size increase). Recieved only by the bottom 25% of players.
    public void PowerUp4(GameObject player) 
    {
        pu4Sound.pitch = UnityEngine.Random.Range(0.5f, 2);
        pu4Sound.Play();
        // Remove powerup icon
        if (player.gameObject.tag == "Player")
        {
            puBtn[3].SetActive(false);
            // Increase Speed, mass and size
            player.GetComponent<Controller>().acceleration *= 10;
            player.GetComponent<Controller>().maxSpeed *= 3;
        }
        else
            player.GetComponent<NavMeshAgent>().speed *= 10;
        player.GetComponent<Rigidbody>().mass *= 5;
        player.transform.localScale *= 2;
        // Start countdown to remove buffs
        StartCoroutine(Wait3(player));
    }
 
// Coroutines =================

    public IEnumerator Wait1(GameObject player)
    {
        yield return new WaitForSeconds(4f); // waits 4 seconds
        if (player.gameObject.tag == "Player")
        {
            player.GetComponent<Controller>().acceleration /= 2;
            player.GetComponent<Controller>().maxSpeed /= 2;
        }
        else
            player.GetComponent<NavMeshAgent>().speed /= 2;
    }

    public IEnumerator Wait2(GameObject player)
    {
        yield return new WaitForSeconds(2f); // waits 2 seconds
        pu32Sound.Play();
        // Instantiate explosion and explosive force
        explosion = Instantiate(Resources.Load("Explosion", typeof(Transform)) as Transform, bomb.transform.position, Quaternion.identity);
        bomb.transform.GetComponentInChildren<Rigidbody>().AddExplosionForce(10.0f, bomb.transform.position, 0.5f, 0f, ForceMode.Impulse);
        Destroy(bomb);
        yield return new WaitForSeconds(5f); // waits 5 seconds
        Destroy(explosion.gameObject);
    }

    public IEnumerator Wait3(GameObject player)
    {
        yield return new WaitForSeconds(6f); // waits 6 seconds
        // set values back to normal
        if (player.gameObject.tag == "Player")
        {
            player.GetComponent<Controller>().acceleration /= 10;
            player.GetComponent<Controller>().maxSpeed /= 3;
        }
        else
            player.GetComponent<NavMeshAgent>().speed /= 10;
        player.GetComponent<Rigidbody>().mass /= 5;
        player.transform.localScale /= 2;
    }

    public IEnumerator Wait4(GameObject player)
    {
        yield return new WaitForSeconds(6f); // waits 6 seconds
        gameObject.GetComponent<Renderer>().enabled = true;
        gameObject.GetComponent<Collider>().enabled = true;
    }

    public IEnumerator Wait5(int randomPU, GameObject player)
    {
        int ranWait = Random.Range(0, 5);
        yield return new WaitForSeconds((float)(ranWait)); // waits 0-4 seconds
        if (randomPU == 0)
            PowerUp1(player);
        else if (randomPU == 1)
            PowerUp2(player);
        else if (randomPU == 2)
            PowerUp3(player);
        else
            PowerUp4(player);
    }
}
