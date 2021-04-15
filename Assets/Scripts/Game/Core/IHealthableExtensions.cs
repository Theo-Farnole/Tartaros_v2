namespace Tartaros.Entities
{
	public static class IHealthableExtensions
	{
		public static bool IsFullLife(this IHealthable healthable)
		{
			return healthable.CurrentHealth == healthable.MaxHealth;
		}

		public static int GetMissingHealthPoints(this IHealthable healthable)
		{
			return healthable.MaxHealth - healthable.CurrentHealth;
		}

		public static void HealMaxLife(this IHealthable healthable)
		{
			healthable.Heal(healthable.GetMissingHealthPoints());
		}
	}
}
