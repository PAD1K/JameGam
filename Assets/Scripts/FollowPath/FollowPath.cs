using System.Collections;
using UnityEngine;
using PathCreation;
using System;

public class FollowPath : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _minDistance = .1f;
    [SerializeField] private MovementType _movementType;
    [SerializeField] private MoveMode _moveMode;
    [SerializeField] private MoveDirection _moveDirection = MoveDirection.Forward;
    [SerializeField] private PathCreator _path;

    private int _currentTargetIndex;
    public event Action OnEndReached;

    public float Speed 
    {
        get
        {
            return _speed;
        }
        set
        {
            if(value < 0)
            {
                _speed = 0;
            }
            else
            {
                _speed = value;
            }
        }
    }
    public PathCreator Path 
    {
        set
        {
            StopMoving();
            _path = value;
        }
    }

    public Vector3 CurrentTarget { get; private set; }
    private Coroutine _coroutine;

    public void StartMoving()
    {
        StopMoving();
        StartCoroutine(MoveAlongThePath());
    }

    public void StopMoving()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);
    }

    private IEnumerator MoveAlongThePath()
    {
        CurrentTarget = _path.path.GetPoint(_currentTargetIndex);

        Func<Vector3> move = () => { return Vector3.zero; };
        Action checkPosition = () => { return; };

        switch (_movementType)
        {
            case MovementType.Lerp:
                {
                    move = () => Vector3.Lerp(transform.position, CurrentTarget, _speed * Time.deltaTime);
                    break;
                }
            case MovementType.Constant:
                {
                    move = () => Vector3.MoveTowards(transform.position, CurrentTarget, _speed * Time.deltaTime);
                    break;
                }
        }

        switch (_moveMode)
        {
            case MoveMode.Loop:
                {
                    checkPosition = () =>
                    {
                        if (Vector3.Distance(transform.position, CurrentTarget) > _minDistance)
                            return;
                            
                        _currentTargetIndex = (_currentTargetIndex + (int)_moveDirection) >= (_path.path.NumPoints - 1) ? 0 : _currentTargetIndex + (int)_moveDirection;
                        CurrentTarget = _path.path.GetPoint(_currentTargetIndex);

                    };
                    break;
                }
            case MoveMode.Linear:
                {
                    checkPosition = () =>
                    {
                        if (Vector3.Distance(transform.position, CurrentTarget) > _minDistance)
                            return;

                        _currentTargetIndex = _currentTargetIndex + (int)_moveDirection;

                        bool isLeftBorderBreached = _currentTargetIndex < 0;
                        bool isRightBorderBreached = _currentTargetIndex > _path.path.NumPoints - 1;

                        if (isLeftBorderBreached || isRightBorderBreached)
                        {
                            _currentTargetIndex = Mathf.Abs((isRightBorderBreached ? 1 : 0) * (_path.path.NumPoints - 1) - 1);
                            _moveDirection = (MoveDirection)((int)_moveDirection * -1);
                        }

                        CurrentTarget = _path.path.GetPoint(_currentTargetIndex);
                    };
                    break;
                }
            case MoveMode.OneTime:
                {
                    checkPosition = () =>
                    {
                        if (Vector3.Distance(transform.position, CurrentTarget) > _minDistance)
                            return;

                        _currentTargetIndex = _currentTargetIndex + (int)_moveDirection;

                        bool isLeftBorderBreached = _currentTargetIndex < 0;
                        bool isRightBorderBreached = _currentTargetIndex > _path.path.NumPoints - 1;

                        if (isLeftBorderBreached || isRightBorderBreached)
                        {
                            OnEndReached?.Invoke();
                            StopMoving();
                            return;
                        }

                        CurrentTarget = _path.path.GetPoint(_currentTargetIndex);
                    };
                    break;
                }
        }
        

        while (true)
        {
            yield return null;

            checkPosition();
            transform.position = move();
        }
    }

    public enum MovementType
    {
        Lerp,
        Constant
    }

    public enum MoveMode
    {
        Loop,
        Linear,
        OneTime
    }

    public enum MoveDirection
    {
        Forward = 1,
        Backward = -1
    }
}
