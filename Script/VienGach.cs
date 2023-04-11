using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VienGach : MonoBehaviour
{

    public float speed;
    public float height;
    public GameObject minigach;
    private Vector2 originPosition;
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        originPosition = transform.position;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        ContactPoint2D[] contacts = new ContactPoint2D[2];
        collision.GetContacts(contacts);
        if (contacts[0].normal.y > 0 && contacts[0].normal.x ==  0 || contacts[0].normal.x < 0)
        {
            PlaySounds("Sounds/Break");
            if (collision.gameObject.tag == "nhanvat")
            {
                StartCoroutine(GoUpAndDown());
                GameObject mini = Instantiate(minigach);
                Destroy(gameObject,0.1f);
                mini.transform.position = originPosition;
            }    
            
        }    
    }
    public void PlaySounds(string name)
    {
        audioSource.PlayOneShot(Resources.Load<AudioClip>(name));
    }
    IEnumerator GoUpAndDown()
    {
        //nay len
        while (true)
        {
            transform.position = new Vector3(
                transform.position.x,
                transform.position.y + speed * Time.deltaTime
                );
            if (transform.position.y > originPosition.y + height)
            {

                break;
            }
            yield return null;
        }
        while (true)
        {
            transform.position = new Vector3(
                transform.position.x,
                transform.position.y - speed * Time.deltaTime
                );
            if (transform.position.y < originPosition.y)
            {
                transform.position = originPosition;
                break;
            }
            yield return null;
        }
    }
}
