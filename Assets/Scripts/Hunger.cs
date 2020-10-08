[System.Serializable]
public struct Hunger
{
    public float currentValue;
    private float _maxValue;

    public Hunger(float maximumValue)
    {
        _maxValue = maximumValue;
        currentValue = maximumValue;
    }
}