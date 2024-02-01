namespace LaunchCamPlus;

public struct Vector3<T>
    where T : notnull
{
    public event Action<T>? OnXChanged;
    public event Action<T>? OnYChanged;
    public event Action<T>? OnZChanged;

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

    public static bool operator ==(Vector3<T> left, Vector3<T> right) => left.Equals(right);
    public static bool operator !=(Vector3<T> left, Vector3<T> right) => !(left == right);

    //Auto-Generated
    public override int GetHashCode() => HashCode.Combine(XValue, YValue, ZValue);
    public override bool Equals(object? obj) =>
        obj is Vector3<T> other &&
        xvalue.Equals(other.xvalue) &&
        yvalue.Equals(other.yvalue) &&
        zvalue.Equals(other.zvalue);

    public override string ToString() => $"X: {XValue}, Y: {YValue}, Z: {ZValue}";

}
