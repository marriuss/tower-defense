using NodeCanvas.Framework;
using ParadoxNotion.Design;

namespace NodeCanvas.Tasks.Conditions
{
    public class TargetDied : ConditionTask<Unit>
    {
        [RequiredField] public BBParameter<ITargetable> TargetVariable;

        private ITargetable _target;
        private bool _targetDied;

        protected override string OnInit()
        {
            _target = TargetVariable.value;
            _targetDied = false;
            return null;
        }

        protected override void OnEnable()
        {
            _target.Died += OnTargetDied;
        }

        protected override void OnDisable()
        {
            _target.Died -= OnTargetDied;
        }

        protected override bool OnCheck()
        {
            return _targetDied;
        }

        private void OnTargetDied()
        {
            _targetDied = true;
        }
    }
}