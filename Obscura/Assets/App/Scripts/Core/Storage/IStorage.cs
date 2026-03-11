namespace App.Scripts.Core.Storage
{
    public interface IStorage<T>
    {
        void Load();
        bool TryGet(out T value);
        void Save();
    }
}