using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OperationQuasarFireApp.Helpers
{
    public class TrilaterationModel
    {
		public double X;
		public double Y;
		public double Distance;

		public TrilaterationModel(double x, double y, double distance)
		{
			this.X = x;
			this.Y = y;
			this.Distance = distance;
		}
	}
}
