using System;

namespace DoYourTriangleExists
{
    public class DoYourTriangleExists
    {
        public bool IsTriangleExist(double a, double b, double c)
        {
            if(a + b >= c & c != 0)
            {
                if(b + c >= a & a != 0)
                {
                    if(a + c >= b & b != 0)
                    {
                        return true;
                    }
                    else
                        return false;
                }
                else
                    return false;
            }
            else
                return false;
        }
    }
}
