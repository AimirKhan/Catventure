using System;
using System.Collections.Generic;
using JCMG.EntitasRedux;
using UnityEngine;

namespace ECS.Views.Systems
{
	public class AddViewSystem : ReactiveSystem<GameEntity>
	{
		readonly Transform _viewContainer = new GameObject("GameViews").transform;
		readonly GameContext _context;
		
		public AddViewSystem(Contexts contexts) : base(contexts.Game)
		{
			_context = contexts.Game;
		}

		protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
		{
			return context.CreateCollector(GameMatcher.View);
		}

		protected override bool Filter(GameEntity entity)
		{
			return !entity.HasView;
		}

		protected override void Execute(List<GameEntity> entities)
		{
			foreach (var entity in entities)
			{
				var go = new GameObject("GameView");
				go.transform.SetParent(_viewContainer, false);
				entity.AddView(go);
				go.Link(entity);
			}
		}
	}
}
