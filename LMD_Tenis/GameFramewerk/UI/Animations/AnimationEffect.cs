using System;

namespace LMD_Tenis.GameFramewerk.UI.Animations
{
	public class AnimationEffect
	{
		private float Begin;
		private float End;
		private float Duration;
		private float currentStep;
		private BaseUI elementUi;
		private bool Enable;

		public AnimationEffect()
		{
			Begin = 0;
			End = 0;
			Duration = 0;
			Enable = false;
		}

		public void Initialize(float Begin, float End, float Duration, BaseUI elementUi)
		{
			this.Begin = Begin;
			this.currentStep = Begin;
			this.End = End;
			this.Duration = Duration;
			this.elementUi = elementUi;
		}

		public void Start()
		{
			Enable = true;
			Console.WriteLine("Start animation");
		}

		public void Stop()
		{
			Enable = false;
		}

		public void Step(float dt)
		{
			if (Enable)
			{
				if (currentStep < End)
				{
					currentStep += Duration;
					elementUi.SetX(currentStep);
				}
				else
				{
					currentStep = Begin;
					Stop();
				}
			}
		}
	}
}