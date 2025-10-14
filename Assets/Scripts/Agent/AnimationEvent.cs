using UnityEngine;

public class AnimationEvent : MonoBehaviour
{
    private PlayerController _player;
    void Awake()
    {
        _player = GetComponent<PlayerController>();
    }
    public void AttackFinish()
    {
        // Notify player
        _player.CallAnimationEvent();
    }
}