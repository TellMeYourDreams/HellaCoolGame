using UnityEngine;
using UnityEngine.UI;
using TMPro;
using JetBrains.Annotations;
using Unity.Collections.Tests.CoreCLR.TestJobs;

public class EXPsystem : MonoBehaviour
{
    [Header("Interface")]
    [SerializeField] TextMeshProUGUI lvlText;
    [SerializeField] TextMeshProUGUI expText;

    int reqEXP = 20, totalEXP = 0, currentLVL = 0;
    [SerializeField] private PlayerAttack playerAttack;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

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
