using UnityEngine;

[CreateAssetMenu(fileName = "HealthPotionDataSO", menuName = "Data/Health Potion Data SO")]
public class HealthPotionDataSO : ItemEffectDataSO
{
    public float HealPercent = 0.1f;
    public override void ApplyEffect()
    {
        base.ApplyEffect();
        Player.Instance.Controller.ChangeHealth(HealPercent);
    }
}