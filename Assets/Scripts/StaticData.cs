using System;
using UnityEngine;

public static class StaticData
{
    public static int PlayerHP = 4;
    public static int PlayerMaxHP = 4;
    public static bool IsPlayerDead = false;

    public static int PlayerGold = 0;
    public static int PlayerScore = 0;

    public static event EventHandler OnPlayerHPChange;
    public static event EventHandler OnPlayerDeath;

    public static event EventHandler<int> OnPlayerGoldChange;
    public static event EventHandler<int> OnPlayerScoreChange;

    public static void PlayerTakeDamage(int damage) {
        Debug.Log("Takedamage");
        PlayerHP -= damage;
        if (PlayerHP <= 0) {
            PlayerHP = 0;
            IsPlayerDead = true;
            OnPlayerDeath?.Invoke(null , EventArgs.Empty);
        }
        OnPlayerHPChange?.Invoke(null, EventArgs.Empty);
    }

    public static void PlayerHeal(int heal) {
        PlayerHP = Mathf.Clamp(PlayerHP + heal,0, PlayerMaxHP);
        OnPlayerHPChange?.Invoke(null, EventArgs.Empty);
    }

    public static void ChangePlayerScore(int change) {
        PlayerScore += change;
        OnPlayerScoreChange?.Invoke(null,PlayerScore);
    }

    public static void ChangePlayerGold(int change) {
        PlayerGold += change;
        OnPlayerGoldChange?.Invoke(null, PlayerGold);
    }
}