namespace Tartaros.Sectors
{
	public interface ISectorsCaptureManager
	{
		void Capture(ISector sectorToCapture);
		void ForceCapture(ISector sectorToCapture);
		bool CanCapture(ISector sector);
	}
}
