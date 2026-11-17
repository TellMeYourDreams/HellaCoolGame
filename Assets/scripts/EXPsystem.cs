using UnityEngine;
using UnityEngine.UI;
using TMPro;
using JetBrains.Annotations;

public class EXPsystem : MonoBehaviour
{
    [Header("Interface")]
    [SerializeField] TextMeshProUGUI lvlText;
    [SerializeField] TextMeshProUGUI expText;
    [SerializeField] TextMeshProUGUI dmgText;
    [SerializeField] TextMeshProUGUI hpText;

    private HealthManager healthManager;

    int reqEXP = 20, totalEXP = 0, currentLVL = 0, dmg = 10;
    [SerializeField] private PlayerAttack playerAttack;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Start()
    {
        healthManager = FindAnyObjectByType<HealthManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
        public void AddEXP(int amount)
    {
        totalEXP += amount;
        CheckLVLUP();
        UpdateInterface();
    }
    void CheckLVLUP()
    {
           
        while (totalEXP >= reqEXP)
        {
            currentLVL++;
            playerAttack.AddDamage(10f);
            dmg += 10;
            dmgText.text = "\nDMG: " + dmg;
            healthManager.health += 50;
            hpText.text = "HP: " + healthManager.health;
            totalEXP = totalEXP - reqEXP;
            UpdateLVL();
        }
    }
    void UpdateLVL()
    {
        if (currentLVL < 10) {
            reqEXP = (int)(reqEXP * 1.15);
        }
        else if (currentLVL < 10)
        {
            reqEXP = (int)(reqEXP * 1.35);
        }
        else if (currentLVL > 9) {
            reqEXP = (int)(reqEXP * 1.6);
        }

        UpdateInterface();
    }
    void UpdateInterface()
    {
        lvlText.text = "Level " + currentLVL.ToString();
        expText.text = "\n\nEXP: " + totalEXP + "/" + reqEXP;
    }
}

