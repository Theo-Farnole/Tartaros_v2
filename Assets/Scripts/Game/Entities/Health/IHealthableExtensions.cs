namespace Tartaros.Entities
{
	public static class IHealthableExtensions
	{
		public static bool IsFullLife(this IHealthable healthable)
		{
			return healthable.CurrentHealth == healthable.MaxHealth;
		}
	}
}
