namespace App.Scripts.Core.Storage.Core
{
    public class BaseStorage<T> : IStorage<T>
    {
        public void Load()
        {
            throw new System.NotImplementedException();
        }

        public bool TryGet(out T value)
        {
            throw new System.NotImplementedException();
        }

        public void Save()
        {
            throw new System.NotImplementedException();
        }
    }
}