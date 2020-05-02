using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaunchCamPlus
{
    public struct Vector3<T>
    {
        private T xvalue;
        private T yvalue;
        private T zvalue;

        public T XValue
        {
            get { return xvalue; }
            set
            {
                xvalue = value;
                OnXChanged?.Invoke(xvalue);
            }
        }
        public T YValue
        {
            get { return yvalue; }
            set
            {
                yvalue = value;
                OnYChanged?.Invoke(yvalue);
            }
        }
        public T ZValue
        {
            get { return zvalue; }
            set
            {
                zvalue = value;
                OnZChanged?.Invoke(zvalue);
            }
        }

        static Vector3()
        {

        }

        public Vector3(T X, T Y, T Z)
        {
            xvalue = X;
            yvalue = Y;
            zvalue = Z;
            OnXChanged = null;
            OnYChanged = null;
            OnZChanged = null;
        }

        public static bool operator ==(Vector3<T> Left, Vector3<T> Right) => Left.XValue.Equals(Right.XValue) && Left.YValue.Equals(Right.YValue) && Left.ZValue.Equals(Right.ZValue);

        public static bool operator !=(Vector3<T> Left, Vector3<T> Right) => !(Left.XValue.Equals(Right.XValue) && Left.YValue.Equals(Right.YValue) && Left.ZValue.Equals(Right.ZValue));

        public override bool Equals(object obj) => (obj is Vector3<T>) && XValue.Equals(((Vector3<T>)obj).XValue) && YValue.Equals(((Vector3<T>)obj).YValue) && YValue.Equals(((Vector3<T>)obj).YValue);

        //Auto-Generated
        public override int GetHashCode()
        {
            var hashCode = -1203628125;
            hashCode = hashCode * -1521134295 + EqualityComparer<T>.Default.GetHashCode(XValue);
            hashCode = hashCode * -1521134295 + EqualityComparer<T>.Default.GetHashCode(YValue);
            hashCode = hashCode * -1521134295 + EqualityComparer<T>.Default.GetHashCode(ZValue);
            return hashCode;
        }

        public override string ToString() => $"X: {XValue.ToString()}, Y: {YValue.ToString()}, Z: {ZValue.ToString()}";

        public event Action<T> OnXChanged;
        public event Action<T> OnYChanged;
        public event Action<T> OnZChanged;
    }
}
