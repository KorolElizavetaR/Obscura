namespace App.Scripts.Core.Storage.Core
{
    public interface IStorage
    {
        void Load();
        bool TryGet<T>(out T value); 
        void Save();
    }
}