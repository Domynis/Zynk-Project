using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UI;
public class PlayerHealthController : MonoBehaviour
{
    #region Properties

    public static PlayerHealthController Instance { get; set; }
    public Text counterText;
    
    [SerializeField] private int healthInitial = 10;

    
    private int healthCurrent;
   

    

    #endregion

    #region Initialisation methods

    
    void Start()
    {
        Instance = this;
        Instance.ResetHealth();

    }

    void Update()
    {
        Instance.counterText.text = Instance.healthCurrent.ToString();
    }

    public void ResetHealth()
    {
        Instance.healthCurrent = healthInitial;
    }

    #endregion

    #region Gameplay methods

    public void TakeDamage(int damageAmount)
    {
        if (!Controller.Instance.CanPause)
            return;

        Instance.StartCoroutine(VignetteOnDamage.Instance.showVignette(1));
        Instance.healthCurrent -= damageAmount;

        if (Instance.healthCurrent <= 0)
        {
            Destroy(gameObject);
            GameSystem.Instance.GameOver();
        }
    }

    public void Heal(int healAmount)
    {
        Instance.healthCurrent += healAmount;

        if (Instance.healthCurrent > Instance.healthInitial)
        {
            Instance.ResetHealth();
        }
    }


    



    #endregion
}