using System.Collections.Generic;
using UnityEngine;

public class AgentController : MonoBehaviour
{
    protected StateMachine _stateMachine;
    public StateMachine StateMachine => _stateMachine;
    protected Rigidbody2D _rb;
    public Rigidbody2D RB => _rb;
    protected Animator _animator;
    public Animator Anim => _animator;

    #region Detection flags
    protected bool _isGroundDetect;
    protected bool _isWallDetected;
    public bool IsGroundDetect => _isGroundDetect;
    public bool IsWallDetected => _isWallDetected;
    #endregion

    #region Serialized fields
    [SerializeField] protected float _health = 100f;
    [SerializeField] protected float _detectGroundDistance = 0.7f;
    [SerializeField] protected float _detectWallDistance = 0.3f;
    [SerializeField] protected LayerMask _groundLayer;
    [SerializeField] protected LayerMask _wallLayer;
    [SerializeField] protected Transform _detectGameobject;
    [SerializeField] protected HealthBar _healthBar;
    #endregion

    public float FacingDirection => transform.localScale.x;

    protected virtual void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _stateMachine = new StateMachine();
        if (_healthBar)
        {
            _healthBar.MaxHealth = _health;
            _healthBar.HealthBarSlider.maxValue = _health;
            _healthBar.SetValue(_health);
        }
        
    }

    void Update()
    {
        _stateMachine.CurrentState.Update();
        DetectGround();
        DetectWall();
    }

    public void SetFacingDirection(float direction)
    {
        if (direction == 0)
        {
            return;
        }
        if (direction > 0 != transform.localScale.x > 0)
        {
            transform.localScale *= new Vector2(-1f, 1f);
        }
    }

    private void DetectGround()
    {
        List<RaycastHit2D> hit = new();
        var filter = new ContactFilter2D
        {
            layerMask = _groundLayer,
            useLayerMask = true
        };
        if (Physics2D.Raycast(_detectGameobject.position, Vector2.down, filter, hit, _detectGroundDistance) > 0)
        {
            _isGroundDetect = true;
        }
        else
        {
            _isGroundDetect = false;
        }
    }

    private void DetectWall()
    {
        List<RaycastHit2D> hit = new();
        var filter = new ContactFilter2D
        {
            layerMask = _wallLayer,
            useLayerMask = true
        };
        if (Physics2D.Raycast(_detectGameobject.position, Vector2.right * FacingDirection, filter, hit, _detectWallDistance) > 0)
        {
            _isWallDetected = true;
        }
        else
        {
            _isWallDetected = false;
        }
    }

    public void TriggerAnimationEvent()
    {
        _stateMachine.CurrentState.TriggerAnimationEvent();
    }

    protected virtual void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(_detectGameobject.position, _detectGameobject.position + Vector3.down * _detectGroundDistance);
        Gizmos.DrawLine(_detectGameobject.position, _detectGameobject.position + Vector3.right * _detectWallDistance * FacingDirection);
    }
}
