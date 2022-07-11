namespace Kata;

public class Light
{
    private int _state;

    public Light(int state)
    {
        _state = state;
    }

    public bool IsTurnedOff()
    {
        return _state == 0;
    }

    public void TurnOn()
    {
        _state = 1;
    }

    public void TurnOff()
    {
        _state = 0;
    }

    public bool DoesNotEqual(Light other)
    {
        return _state != other._state;
    }

    public override string ToString()
    {
        return _state.ToString();
    }
}