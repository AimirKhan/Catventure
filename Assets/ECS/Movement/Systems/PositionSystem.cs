using System.Collections.Generic;
using JCMG.EntitasRedux;

namespace ECS.Movement.Systems
{
    public class PositionSystem : ReactiveSystem<GameEntity>
    {
        public PositionSystem(Contexts contexts) : base(contexts.Game)
        {
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.Position);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.HasPosition && entity.HasView;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var entity in entities)
            {
                entity.View.gameobject.transform.position = entity.Position.value;
            }
        }
    }
}