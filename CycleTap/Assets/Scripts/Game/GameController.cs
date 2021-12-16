
using UnityEngine;
using UnityCore.Session;
using UnityCore.Menu;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityCore.Data;
using TMPro;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public PlayerController player;
    public new CameraController camera;
    public ObstacleController obstacle;
    public int PlayerScorePerUnit;
    public TMPro.TMP_Text TextScore;
    public TMPro.TMP_Text TextCoin;
    public TMPro.TMP_Text TextTotalcoin;
   // public Text TextTotalCoin;
    public int PlayerFallRange;
    public int Coin;
    public bool Admin;
    public int MatchCoin;
    public int CurrentMatchcoin;
    public int TotalCoins;
    
    public GameObject Shield;
   
    ShieldTrigger St;
    private SessionController m_Session;
    private int players_Score, Current_score;
    private int m_coinMultiplier = 1;
    private float m_coiMultiplierDuration;
    private float m_ProtectionDuration;
    private bool m_Protected = false;
    private bool m_DiddropPickup;
    private int value =1;
    private bool coinmulti = false;
    private float _dt2;
    private float Campos;
    private float campos2;
    private SessionController sessio

    {
        get
        {
            if (!m_Session)
            {
                m_Session = SessionController.instance;
            }
            if (!m_Session)
            {
                Debug.LogWarning("Game is trying to access the session, but no instance of sessionController was found");

            }
            return m_Session;
        }
    }
    #region Unity Functions
    public SaveData1 SaveData;
    public DataManagement DataManagement;
   
    private void Start()
    {
        // SaveData.SaveData();
        SaveData.LoadData();
        TotalCoins = DataManagement.Coin;
        Campos = camera.transform.position.z;
        St = FindObjectOfType<ShieldTrigger>();
        //SaveData.LoadData();
        PageController.instance.TurnPageOff(PageType.GameOver);
        if (!sessio)
        {
            return;

        }
        sessio.InitializeGame(this);
    }
    #endregion

    #region public Functions
    public void HandleCoinMultiplierPickUp(int _multiplier, float duration)
    {

        coinmulti = true;
        m_coinMultiplier = _multiplier;
        m_coiMultiplierDuration = duration;
        _dt2 = _dt2 + Time.deltaTime;
        value = value * m_coinMultiplier;
        
       
        obstacle.ResetI();
    }
    public void HandleProtectionPickup(float _duration)
    {
        m_ProtectionDuration = _duration;
        m_Protected = true;
        obstacle.ResetI();
        
    }
    public void HandleCoin(int _value)
    {

        _value = value * _value;
        Coin += value;
        // TotalCoins = TotalCoins+ Coin;
        obstacle.ResetI();
        

    }
    

    public void OnInit()
    {
        player.OnInit();
        camera.OnInit();
        obstacle.AddObstacle();
       
    }




    public void OnUpdate()
    {   
        player.OnUpdate();
        camera.OnUpdate();
        obstacle.AddObstacle();
        obstacle.AddPickup();
       // DetectPlayerFall();
        EnforcePickupRules();
        OnScreenUi();
      
       // DataManagement.Coin = Coin;
       // Debug.Log(DataManagement.Coin + "coins");
    }


    public int PlayerScore()
    {
        campos2 = camera.transform.position.z - Campos;
        // players_Score = (int)player.transform.position.z / PlayerScorePerUnit;
        players_Score = (int)campos2 / PlayerScorePerUnit;
        
        return players_Score;
    }

    private bool _save = true;

    public void Die()
    {
        if (_save)
        {
            SaveData.SaveData();
            _save = false;

        }
        if (m_Protected) return;
        if (!Admin) return;
        if (Admin)
        {
            player.pause = true;
            PageController.instance.TurnPageOn(PageType.GameOver);
        }


    }
    public void TryAgain()
    {
        EndGame();
    }
    #endregion



    #region Private Functions
    private void EnforcePickupRules()
    {
        float _dt = Time.deltaTime;
        m_ProtectionDuration -= _dt;
        m_coiMultiplierDuration -= _dt;
        if (m_ProtectionDuration <= 0 && m_Protected)
        {   
            player.ShieldEnable = false;
            m_Protected = false;
            m_ProtectionDuration = 0;
            
        }

        if (m_coiMultiplierDuration <=0 &&coinmulti == true)
        {
            Debug.Log("coinmulti Off");
            coinmulti = false;
            value = value / m_coinMultiplier;
           
        }

    }


    private void Awake()
    {
        DataManagement = FindObjectOfType<DataManagement>();
        SaveData = FindObjectOfType<SaveData1>();
      //  SaveData.LoadData();
        if (!instance)
        {
            instance = this;
        }
    }



  /*  private void DetectPlayerFall()
    {

        if (player.transform.position.z < camera.transform.position.z + PlayerFallRange)
        {
            Die();
        }
    }*/


    private void EndGame()
    {
      
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
     
    }



    private void OnScreenUi()
    {
        if (TextScore == null) return;
        TextScore.text = PlayerScore().ToString();
        TextCoin.text =  Coin.ToString();
       // TextTotalcoin.text = TotalCoins.ToString();

    }
   
    
    #endregion

}
