using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiChuyenNhanVat : MonoBehaviour
{
    public new Rigidbody2D rigidbody2D;
    public bool isRight;
    public float speed;
    public float vanToc;
    private bool battu = false;
    private bool isDangDungTrenSan;
    private Animator animator;
    public ParticleSystem psBui;
    public GameObject daibac;
    public GameObject viendan;
    Quaternion rotion;
    public int soluongdan = 3;
    public Text txt_soluongdan;
    private AudioSource audioSource;

    // Start is called before the first frame update
    public void Start()
    {
        isRight = true;
        speed = 8f;
        vanToc = 0;
        rigidbody2D = GetComponent<Rigidbody2D>();
        isDangDungTrenSan = true;
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    public void Update()
    {
        txt_soluongdan.text = "Số lượng đạn : " + soluongdan;
        animator.SetBool("isDungTrenSan", isDangDungTrenSan);
        animator.SetFloat("vantoc", vanToc);
        animator.SetFloat("roixuong", rigidbody2D.velocity.y);
        rotion = psBui.transform.localRotation;
        if (Input.GetKey(KeyCode.RightArrow))
        {

            rotion.y = 180;
            psBui.transform.localRotation = rotion;
            psBui.Play();
            if (!isRight)
            {
                Vector2 scale = transform.localScale;
                scale.x *= scale.x > 0 ? 1 : -1;
                transform.localScale = scale;
                isRight = true;
            }
            transform.Translate(Time.deltaTime * speed, 0, 0);
            vanToc = speed;

        }
        else if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            vanToc = 0;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rotion.y = 0;
            psBui.transform.localRotation = rotion;
            psBui.Play();

            if (isRight)
            {
                Vector2 scale = transform.localScale;
                scale.x *= scale.x > 0 ? -1 : 1;
                transform.localScale = scale;
                isRight = false;
            }
            transform.Translate(-Time.deltaTime * speed, 0, 0);

            vanToc = speed;


        }
        else if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            vanToc = 0;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isDangDungTrenSan)
            {

                if (!battu)
                {

                    rigidbody2D.AddForce(new Vector2(0, 400));

                }
                else
                {
                    rigidbody2D.AddForce(new Vector2(0, 10));
                }
                isDangDungTrenSan = false;
                PlaySounds("Sounds/Squish");

            }
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            if(soluongdan > 0)
            {

                GameObject _viendan = Instantiate(viendan);
                _viendan.transform.position = new Vector3(transform.position.x + (isRight ? 0.8f : -1), transform.position.y);
                _viendan.GetComponent<VienDan>().setSpeed(isRight ? 5f : -5f);
                PlaySounds("Sounds/Kick");
                soluongdan--;
            }
            
        }

        
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("nendat")
            ||collision.gameObject.CompareTag("viengach")
            || collision.gameObject.CompareTag("qua"))
        {
            isDangDungTrenSan = true;
        }
        if(collision.gameObject.CompareTag("kichhoatdaibat"))
        {
            daibac.SetActive(true);
        }
        
    }
    public void PlaySounds(string name)
    {
        audioSource.PlayOneShot(Resources.Load<AudioClip>(name));
    }

}
