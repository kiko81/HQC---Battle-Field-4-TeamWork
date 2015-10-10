namespace Battlefield.Logic.Common
{
    public static class Validators
    {
        public static bool IsInBounds(int value, int size)
        {
            return 0 <= value && value < size;
        }
    }
}
