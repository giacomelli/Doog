namespace Snake.Framework
{
    /// <summary>
    /// World context extension methods.
    /// </summary>
	public static class WorldContextExtensions
	{
		public static void RemoveComponentsWithoutTag(this IWorldContext worldContext, string tag)
		{
			foreach (var c in worldContext.Components.GetWithoutTag(tag))
			{
				worldContext.RemoveComponent(c);
			}
		}

		public static void RemoveAllComponents(this IWorldContext worldContext)
		{
			foreach (var c in worldContext.Components)
			{
				worldContext.RemoveComponent(c);
			}
		}
	}
}