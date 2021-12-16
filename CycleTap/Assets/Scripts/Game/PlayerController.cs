
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float Smooth;
    public float JumpForce;
    public float GravityAcceleration;
    public float MaxGravity;
    public bool pause = false;
    private ShieldTrigger St; 
    public GameObject Shield;
    public bool ShieldEnable = false;

    private Vector3 m_TargetPosition;
    private float m_DownwardVelocity;
    private Animator Animator;



    #region Unity Functions
    public void Start()
    {
        Animator = GetComponent<Animator>();
        St = FindObjectOfType<ShieldTrigger>();
    }

    #endregion

    #region public Functions

    public void OnInit()
    {
        m_TargetPosition = transform.position;
    }

    public void OnUpdate()
    { //  Debug.Log(St.ShieldEnable + "199" );
        if (pause)
        {
            return;
        }
         if ( ShieldEnable== true)
         {
              Shield.SetActive(true);
            //  Animator.Play("Player_Shield_open");
      
             
         }
         else if ( ShieldEnable== false)
         {     
            
             
             Shield.SetActive(false);
              
         } 
        
        Jump();
        Fall();
        Move();
      //  Debug.Log("done");
    }
    #endregion

    #region Private Functions

    private void Jump()
    {
        if (Input.GetMouseButton(0))
        {
            Animator.SetBool("Forward", true);
            m_TargetPosition.z = transform.position.z + JumpForce;
            m_DownwardVelocity = 0;
          //  Debug.Log("done");
        }
        else
        {
            Animator.SetBool("Forward", false);
           // Animator.SetBool("Gravity", true);
        }


    }
    private void Fall()
    {
        m_DownwardVelocity += GravityAcceleration;
        m_DownwardVelocity = Mathf.Clamp(m_DownwardVelocity, 0, MaxGravity);
        m_TargetPosition.z -= m_DownwardVelocity * Time.deltaTime;
        if (m_TargetPosition.z <= -4)
        {
            m_TargetPosition.z = -4;
        }
    }
    private void Move()
    {
        transform.position = Vector3.Lerp(transform.position, m_TargetPosition, Smooth * Time.deltaTime);
    }

        private void StopAnimation()
    {
      //  Animator.Stop("Player_Shield_open");
    }

     private void OnTriggerEnter(Collider other)
    { 
        if (other.gameObject.tag.Equals("ProtectionPickup"))
        {
           ShieldEnable = true;
           Debug.Log("touched");
        }

    }
 
    #endregion
}
