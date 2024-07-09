using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character_Controller : MonoBehaviour
{
    public static Character_Controller instance;

    public Rigidbody2D playerRB;
    public float playerSpeed;

    private Vector2 moveInput;
    private Vector2 mouseInput;
    public float mousesensivitiy;

    public Camera viewCamera;

    public GameObject bulletImpact;
    public int maxAmmo;
    public Text ammoText;
    
    public Animator animator;
    //Knockback
    public float knockback;
    public float knockbackLenght;
    public float knockbackCount;
    public bool knockbackRight;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        //İmleç Gizleme
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode. Locked;
    }
    void Update()
    {
       // Karakter Hareketleri
        moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        Vector3 moveHorizontal = transform.up * -moveInput.x;
        Vector3 moveVertical = transform.right * moveInput.y;

        if(knockbackCount <= 0)
        {
            playerRB.velocity = (moveHorizontal + moveVertical) * playerSpeed;
        }
        else
        {
        if (knockbackRight)
            playerRB.velocity = new Vector2(-knockback, knockback);
        if (!knockbackRight)
            playerRB.velocity = new Vector2(knockback, knockback);
            knockbackCount -= Time.deltaTime;
        }
        //Kamera Görüş
        mouseInput = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y") * mousesensivitiy);
        transform.rotation = Quaternion. Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y,transform.rotation.eulerAngles.z - mouseInput.x);
        viewCamera.transform.localRotation = Quaternion.Euler(viewCamera.transform.localRotation.eulerAngles + new Vector3(0f, mouseInput.y, 0f));
    
        //Ateş Etme
        if(Input.GetMouseButtonDown(0))
        {
            if(maxAmmo > 0)
            {
                Ray ray = viewCamera.ViewportPointToRay(new Vector3(.5f, .5f, 0f));

                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    //Debug.Log("Görüyorum" + hit.transform.name);
                    Instantiate(bulletImpact, hit.point, transform.rotation);

                    if(hit.transform.tag == "Enemy")
                    {
                        hit.transform.parent.GetComponent<Enemy_Control>().TakeDamage();
                    }
                }
                else
                {
                    Debug.Log("Görmüyorum");
                }
                    maxAmmo--;
                    ammoText.text = maxAmmo +"";
                    animator.SetTrigger("shoot");
                    Audio_Manager.instance.PlayPlayerShoot();
            }
            
        }
    
    }
}
