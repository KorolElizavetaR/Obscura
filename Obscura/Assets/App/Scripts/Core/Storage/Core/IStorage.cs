namespace App.Scripts.Core.Storage.Core
{
    public interface IStorage
    {
        void Load();
        bool TryGet<T>(out T value); 
        bool TryAdd<T>(T value);
        void Save();
    }
}