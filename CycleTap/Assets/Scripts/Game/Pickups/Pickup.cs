
using UnityEngine;

public class Pickup : MonoBehaviour
{
    private GameController m_Game;
    private bool m_Didcollect;
     
  


    protected GameController game
    {
        get
        {
            if (!m_Game)
            {
                m_Game = GameController.instance;
            }
            if (!m_Game)
            {
                Debug.LogWarning("GameController Not found [pickup]");

            }
            return m_Game;
        }
    }

    #region Unity Functions

    private void OnTriggerEnter(Collider _col)

    {
        
        if (!game) return;
        if (m_Didcollect) return;
        if (_col.gameObject.tag.Equals("Player"))
        {
            m_Didcollect = true;
            OnPlayerCollect();
            Destroy(gameObject);
        }

    }
    

    #endregion

    #region Override Function

    protected virtual void OnPlayerCollect()
    {
        Debug.Log("Player Picked up [" + gameObject.name + "]");
    }

    #endregion
}
