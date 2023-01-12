using NodeCanvas.Framework;
using ParadoxNotion.Design;

namespace NodeCanvas.Tasks.Actions
{
    public class FindCastle : ActionTask<Unit>
    {
        [RequiredField] public BBParameter<ITargetable> TargetVariable;

        protected override string OnInit()
        {
            return null;
        }

        protected override void OnExecute()
        {
            Castle castle = CastleFinder.FindClosestCastle(agent.Position);
            TargetVariable.value = castle;
            EndAction(castle != null);
        }
    }
}