using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiChuyenNhanVat : Photon.MonoBehaviour
{
    public new Rigidbody2D rb;
    public bool isRight;
    public float speed;
    public float vanToc;
    private bool battu = false;
    private bool isDangDungTrenSan;
    public Animator anmin;
    public ParticleSystem psBui;
    public GameObject PlayerCamerera;
    public PhotonView photonView;
    public SpriteRenderer sr;
    public GameObject daibac;
    public GameObject viendan;
    Quaternion rotion;
    private void Awake()
    {
        if (photonView.isMine)
        {
            //PlayerCamerera.SetActive(true);
        }
    }
    // Start is called before the first frame update
    public void Start()
    {
        isRight = true;
        speed = 8f;
        vanToc = 0;
        isDangDungTrenSan = true;

        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    public void Update()
    {
        if (photonView.isMine)
        animator.SetBool("isDungTrenSan", isDangDungTrenSan);
        animator.SetFloat("vantoc", vanToc);
        animator.SetFloat("roixuong", rigidbody2D.velocity.y);
        rotion = psBui.transform.localRotation;
        if (Input.GetKey(KeyCode.RightArrow))
        {
            anmin.SetBool("isDungTrenSan", isDangDungTrenSan);
            anmin.SetFloat("vantoc", vanToc);
            rotion = psBui.transform.localRotation;
            if (Input.GetKey(KeyCode.RightArrow))
            {
                rotion.y = 180;
                psBui.transform.localRotation = rotion;
                psBui.Play();

                photonView.RPC("ChayPhai", PhotonTargets.AllBuffered);
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

                photonView.RPC("ChayTrai", PhotonTargets.AllBuffered);
                transform.Translate(-Time.deltaTime * speed, 0, 0);

                vanToc = speed;

            }
            else if (Input.GetKeyUp(KeyCode.LeftArrow))
            {
                vanToc = 0;
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {

                photonView.RPC("NhayLen", PhotonTargets.AllBuffered);
            }
        }


        if (Input.GetKeyDown(KeyCode.X))
        {
            GameObject _viendan = Instantiate(viendan);
            _viendan.transform.position = new Vector3(transform.position.x + (isRight ? 0.8f : -1), transform.position.y);
            _viendan.GetComponent<VienDan>().setSpeed(isRight ? 5f : -5f);
        }

        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (photonView.isMine)
        {
            if (collision.gameObject.CompareTag("nendat")
            || collision.gameObject.CompareTag("viengach"))
            {
                isDangDungTrenSan = true;
            }
        }

    }  
    [PunRPC]
    public void ChayPhai()
    {

        if (!isRight)
        {
            Vector2 scale = transform.localScale;
            scale.x *= scale.x > 0 ? 1 : -1;
            transform.localScale = scale;
            isRight = true;
        }

    }
    [PunRPC]
    public void ChayTrai()
    {
        
        if (isRight)
        {
            Vector2 scale = transform.localScale;
            scale.x *= scale.x > 0 ? -1 : 1;
            transform.localScale = scale;
            isRight = false;
        }

    }
    [PunRPC]
    public void NhayLen()
    {
        if (isDangDungTrenSan)
        {

            if (!battu)
            {

                rb.AddForce(new Vector2(0, 400));

            }
            else
            {
                rb.AddForce(new Vector2(0, 10));
            }
            isDangDungTrenSan = false;

        }
    }    
    
    
        if(collision.gameObject.CompareTag("kichhoatdaibat"))
        {
            daibac.SetActive(true);
        }
        
    }
  
}
