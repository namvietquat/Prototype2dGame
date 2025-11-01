using UnityEngine;

public class AnimationEvents : MonoBehaviour
{
    private PlayerController _player;
    void Awake()
    {
        _player = GetComponent<PlayerController>();
    }
    public void AttackFinish()
    {
        _player.TriggerAnimationEvent();
    }
}