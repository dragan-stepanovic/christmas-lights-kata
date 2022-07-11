namespace Kata;

public class Light
{
    private int _state;

    public Light(int state)
    {
        _state = state;
    }

    public void TurnOn()
    {
        _state = 1;
    }

    public void TurnOff()
    {
        _state = 0;
    }

    public void Toggle()
    {
        if (IsTurnedOff())
            TurnOn();
        else
            TurnOff();
    }

    private bool IsTurnedOff()
    {
        return _state == 0;
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