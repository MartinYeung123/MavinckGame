using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Done_EvasiveManeuver : MonoBehaviour
{
    public Boundary boundary;
    public float tilt;
    public float dodge;
    public float smoothing;
    public int scoreValue;
    public Vector2 startWait;
    public Vector2 maneuverTime;
    public Vector2 maneuverWait;
    public GameObject exp_enm;
    private GameManager GameMaz;

    public int hp = 100;
    private float currentHealth;
    public Image hp_bag;

    private float currentSpeed;
    private float targetManeuver;

    void Start()
    {
        GameObject go = GameObject.FindGameObjectWithTag("GameManager");
        GameMaz = go.GetComponent<GameManager>();
        currentHealth = hp;
        currentSpeed = GetComponent<Rigidbody>().velocity.z;
        StartCoroutine(Evade());
    }

    IEnumerator Evade()
    {
        yield return new WaitForSeconds(Random.Range(startWait.x, startWait.y));
        while (true)
        {
            targetManeuver = Random.Range(1, dodge) * -Mathf.Sign(transform.position.x);
            yield return new WaitForSeconds(Random.Range(maneuverTime.x, maneuverTime.y));
            targetManeuver = 0;
            yield return new WaitForSeconds(Random.Range(maneuverWait.x, maneuverWait.y));
        }
    }

    void FixedUpdate()
    {
        float newManeuver = Mathf.MoveTowards(GetComponent<Rigidbody>().velocity.x, targetManeuver, smoothing * Time.deltaTime);
        GetComponent<Rigidbody>().velocity = new Vector3(newManeuver, 0.0f, currentSpeed);
        GetComponent<Rigidbody>().position = new Vector3
        (
            Mathf.Clamp(GetComponent<Rigidbody>().position.x, boundary.xMin, boundary.xMax),
            -19.5f,
            Mathf.Clamp(GetComponent<Rigidbody>().position.z, boundary.zMin, boundary.zMax)
        );

        GetComponent<Rigidbody>().rotation = Quaternion.Euler(0, 0, GetComponent<Rigidbody>().velocity.x * -tilt);
    }
    public void Damage2(int damage)
    {
        if (currentHealth > 0)
        {
            currentHealth -= damage;
            hp_bag.fillAmount = currentHealth / hp;
        }
        if (currentHealth <= 0)
        {
            //hp = 0;
            Instantiate(exp_enm, transform.position, transform.rotation);
            Destroy(gameObject);
            GameMaz.AddScore(scoreValue);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.SendMessage("Damage", 30, SendMessageOptions.DontRequireReceiver);
            Instantiate(exp_enm, transform.position, transform.rotation);
            Destroy(gameObject);
            GameMaz.AddScore(scoreValue);
        }
    }
}
