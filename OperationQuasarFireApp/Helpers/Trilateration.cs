using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//https://github.com/hyunbum-2/Trilateration/blob/master/Trilateration/Program.cs
namespace OperationQuasarFireApp.Helpers
{
	using System;

	public class Trilateration
	{
		public static TrilaterationModel getTrilateration(TrilaterationModel p1, TrilaterationModel p2, TrilaterationModel p3)
        {
			double S = (Math.Pow(p3.X, 2) - Math.Pow(p2.X, 2) + Math.Pow(p3.Y, 2) - Math.Pow(p2.Y, 2) + Math.Pow(p2.Distance, 2) - Math.Pow(p3.Distance, 2)) / 2;
			double T = (Math.Pow(p1.X, 2) - Math.Pow(p2.X, 2) + Math.Pow(p1.Y, 2) - Math.Pow(p2.Y, 2) + Math.Pow(p2.Distance, 2) - Math.Pow(p1.Distance, 2)) / 2;

			double y = ((T * (p2.X - p3.X)) - (S * (p2.X - p1.X))) / (((p1.Y - p2.Y) * (p2.X - p3.X)) - ((p3.Y - p2.Y) * (p2.X - p1.X)));
			double x = ((y * (p1.Y - p2.Y)) - T) / (p2.X - p1.X);

			return new TrilaterationModel(x, y, 0);
		}
	
	}
}
