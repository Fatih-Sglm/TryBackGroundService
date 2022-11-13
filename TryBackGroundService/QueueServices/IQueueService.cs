namespace TryBackGroundService.QueueServices
{
    // Kuyruğa ekleme ve kuyruktan silme işlemleri için gereken metodların imzasının olduğu arayüz
    public interface IQueueService<T>
    {
        Task AddQueue(T item);
        Task<T> DeQueue(CancellationToken cancellationToken);
    }
}
