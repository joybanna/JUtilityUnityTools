namespace J_Tools
{
    public abstract class JSingleton<T> where T : JSingleton<T>, new()
    {
        private static T _instance;

        public static T Instance
        {
            get
            {
                if (_instance.IsNull())
                {
                    _instance = new T();
                }

                return _instance;
            }
        }
    }
}