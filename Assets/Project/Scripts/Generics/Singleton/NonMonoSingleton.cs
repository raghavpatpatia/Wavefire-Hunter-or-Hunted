public class NonMonoSingleton<T> where T : NonMonoSingleton<T>
{
    private static T instance;
    public static T Instance { get { return instance; } }
    protected NonMonoSingleton()
    {
        if (instance == null)
        {
            instance = (T)this;
        }
    }
}