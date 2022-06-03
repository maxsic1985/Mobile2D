using Tools;
using UnityEngine;
namespace CarInput
{
    public abstract class BaseInputView : MonoBehaviour
    {
        #region Field
        private SubscriptionProperty<float> _leftMove;
        private SubscriptionProperty<float> _rightMove;

        protected float _speed;
#endregion
        #region Life cycle
        public virtual void Init(SubscriptionProperty<float> leftMove, SubscriptionProperty<float> rightMove, float speed)
        {
            _leftMove = leftMove;
            _rightMove = rightMove;
            _speed = speed;
        }

        protected void OnLeftMove(float value)
        {
            _leftMove.Value = value;
        }

        protected void OnRightMove(float value)
        {
            _rightMove.Value = value;
        }
    }
    #endregion
}

