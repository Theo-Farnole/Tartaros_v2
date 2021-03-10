namespace Tartaros.Entities
{
	public enum Team
	{
		Player,
		Enemy
	}

	public static class TeamExtensions
	{
		public static Team GetOpponent(this Team team)
		{
			switch (team)
			{
				case Team.Player:
					return Team.Enemy;

				case Team.Enemy:
					return Team.Enemy;

				default:
					throw new System.NotImplementedException();
			}
		}
	}
}
