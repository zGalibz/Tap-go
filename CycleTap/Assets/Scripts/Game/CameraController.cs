
using UnityEngine;
[RequireComponent(typeof(Camera))]
public class CameraController : MonoBehaviour
{
    public Transform player;
    public float smooth;
    public Vector3 Offset;

    private Camera m_camera;
    private Vector3 m_TargetPosition;
    private Vector3 m_InitialPosition;


    #region Unity Functions 


    #endregion

    #region Public Function
   public void OnInit()
    {
        m_camera = GetComponent<Camera>();
        m_TargetPosition = transform.position;
        m_InitialPosition = m_TargetPosition;
    }

    // Update is called once per frame
    public void OnUpdate()
    {
        FollowPlayer();
    }
    #endregion


    #region private Function
    private void FollowPlayer()
    {
        if (!player)
        {
            Debug.LogWarning("Camera could not find a reference to the player");
            return;
        }
        if (player.position.z > transform.position.z + Offset.z)
        {
            m_TargetPosition.z = player.position.z - Offset.z;
        }

        transform.position = Vector3.Lerp(transform.position,m_TargetPosition,smooth *Time.deltaTime);

    }

    #endregion

}
