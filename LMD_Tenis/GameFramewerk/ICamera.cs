namespace LMD_Tenis.GameFramewerk
{
	public interface ICamera
	{
		void SetXY(float x, float y);
		void SetX(float value);
		void SetY(float value);
		float GetX();
		float GetY();
	}
}