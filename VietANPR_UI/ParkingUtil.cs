using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TGMT;
using TGMTcs;

namespace VietANPR_UI
{
    class ParkingUtil
    {
        static double CalcDistance(Point p1, Point p2)
        {
            return Math.Sqrt(Math.Pow((p2.X - p1.X), 2) + Math.Pow((p2.Y - p1.Y), 2));
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public static VehiclePlate GetBiggest(VehiclePlate[] plates)
        {
            int biggestArea = 0;
            int biggestID = -1;

            for (int i = 0; i < plates.Length; i++)
            {
                int area = plates[i].rect.Width * plates[i].rect.Height;
                if (area > biggestArea)
                {
                    biggestArea = area;
                    biggestID = i;
                }
            }

            return plates[biggestID];
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public static VehiclePlate GetNearestCenter(Bitmap frame, VehiclePlate[] plates)
        {
            Point centerPoint = new Point(frame.Width / 2, frame.Height / 2);
            double nearestDistance = -1;
            int nearestID = -1;

            for (int i = 0; i < plates.Length; i++)
            {
                Rectangle rect = plates[i].rect;
                Point center = new Point(rect.X + rect.Width / 2, rect.Y + rect.Height / 2);
                double distance = CalcDistance(centerPoint, center);

                if (nearestDistance == -1 || distance < nearestDistance)
                {
                    nearestDistance = distance;
                    nearestID = i;
                }
            }

            return plates[nearestID];
        }
    }
}
