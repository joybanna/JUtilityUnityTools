namespace J_Tools
{
    public abstract class JMonoSingleton<T> : UnityEngine.MonoBehaviour where T : JMonoSingleton<T>, new()
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

        protected virtual void Awake()
        {
            if (_instance.IsNull())
            {
                _instance = this as T;
                DontDestroyOnLoad(this.gameObject);
            }
            else
            {
                Destroy(this);
            }
        }
    }
}