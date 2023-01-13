using NodeCanvas.Framework;
using ParadoxNotion.Design;

namespace NodeCanvas.Tasks.Conditions
{
    public class Hit : ConditionTask<Unit>
    {
        [RequiredField] public BBParameter<ITargetable> TargetVariable;
        
        private bool _hit;

        protected override string OnInit()
        {
            _hit = false;
            return null;
        }

        protected override void OnEnable()
        {
            agent.WasHit += OnHit;
        }

        protected override void OnDisable()
        {
            agent.WasHit -= OnHit;
        }

        protected override bool OnCheck()
        {
            return _hit;
        }

        private void OnHit(Unit attackingUnit)
        {
            _hit = true;
            TargetVariable.value = attackingUnit;
        }
    }
}