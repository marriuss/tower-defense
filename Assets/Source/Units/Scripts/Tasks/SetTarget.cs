using NodeCanvas.Framework;
using ParadoxNotion.Design;

namespace NodeCanvas.Tasks.Actions
{
    public class SetTarget : ActionTask<Unit>
    {
        [RequiredField] public BBParameter<ITargetable> TargetableVariable;
        [RequiredField] public BBParameter<string> EventName;

        protected override string OnInit()
        {
            return null;
        }

        protected override void OnExecute()
        {
            agent.SetTarget(TargetableVariable.value);
            SendEvent(EventName.value);
            EndAction(true);
        }
    }
}
