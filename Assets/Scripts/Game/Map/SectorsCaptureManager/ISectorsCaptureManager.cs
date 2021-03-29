namespace Tartaros.Sectors
{
	public interface ISectorsCaptureManager
	{
		void Capture(ISector sectorToCapture);
		bool CanCapture(ISector sector);
	}
}
