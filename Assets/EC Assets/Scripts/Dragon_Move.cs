using UnityEngine;

public class Dragon_Movement : MonoBehaviour
{

    public float speed = 5;
    public bool goingUp = true;
    private float ratWait = 1, fireballWait = 1;
    private float ratTimer = 0, fireballTimer = 0.5f;
    private float hugeRatWait = 10;
    private float hugeRatTimer = 0;


    public GameObject rat, fireball, HugeRat;


    void Update()
    {

        ratTimer += Time.deltaTime;
        fireballTimer += Time.deltaTime;
        hugeRatTimer += Time.deltaTime;

        if(ratTimer > ratWait)
        {
            Instantiate(rat, transform.position, Quaternion.identity);
            ratTimer = 0;
            ratWait = Random.Range(1f, 2f);
        }

        if(fireballTimer > fireballWait)
        {
            Instantiate(fireball, transform.position, Quaternion.identity);
            fireballTimer = 0;
            fireballWait = Random.Range(0.5f, 1f);
        }

        if(hugeRatTimer > hugeRatWait)
        {
            Instantiate(HugeRat, transform.position, Quaternion.identity);
            hugeRatTimer = 0;
            hugeRatWait = Random.Range(10f, 25f);
        }

        transform.Translate(transform.up * speed * Time.deltaTime);

        if(transform.position.y > 4 && goingUp == true)
        {
            goingUp = false;
            speed *= -1;
        }

        if(transform.position.y < -4 && goingUp == false)
        {
            goingUp = true;
            speed *= -1;
        }
    }

}