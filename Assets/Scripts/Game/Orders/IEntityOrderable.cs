namespace Tartaros.Orders
{
	using Tartaros.Entities;

	public interface IEntityOrderable
	{
		Order[] GenerateOrders(Entity entity);
	}
}
