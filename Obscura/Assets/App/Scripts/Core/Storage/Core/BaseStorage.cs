namespace App.Scripts.Core.Storage.Core
{
    public class BaseStorage : IStorage
    {
        public void Load()
        {
            throw new System.NotImplementedException();
        }

        public bool TryGet<T>(out T value)
        { 
            throw new System.NotImplementedException();
        }

        public void Save()
        {
            throw new System.NotImplementedException();
        }
    }
}