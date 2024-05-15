using JCMG.EntitasRedux;
using UnityEngine;

namespace ECS.Movement.Components
{
	[Game]
	public class PositionComponent : IComponent
	{
		public Vector3 value;
	}
}
