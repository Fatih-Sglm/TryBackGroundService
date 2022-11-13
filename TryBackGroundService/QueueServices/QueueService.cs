using System.Threading.Channels;


// Kuyruğa ekleme ve kuyruktan silme işlemleri için gereken metodların implemente edildiği nesne

namespace TryBackGroundService.QueueServices
{
    public class QueueService<T> : IQueueService<T>
    {
        // Background serviinde metodun sürekli değil de sadece queya istek geldiğinde tetiklenmesi için channel class ından faydalanıyoruz
        private readonly Channel<T> _channel;

        private readonly int queueCapacity;
        public QueueService(IConfiguration configuration)
        {
            //sisteme bir kapasite belirtiyoruz aynı anda belli sayıda isteği kabul etmesi için;
            _ = int.TryParse(configuration["queueCapacity"], out queueCapacity);

            //bu option ile kurulan channel in gelen istekleri beklemesini silmemes gerektiğini belirtiyoryz
            BoundedChannelOptions options = new(queueCapacity)
            {
                FullMode = BoundedChannelFullMode.Wait
            };
            // Channel eğer kapasiteli olacak ise CreateBounded Metodu ile kapasiteiz olacak ise CreateUnbounded metodu ile create ediyoruz
            _channel = Channel.CreateBounded<T>(options);

        }


        //Sistemde tektiklenen Queueyi channelımıza aktarıyoruz
        public async Task AddQueue(T item)
        {
            ArgumentNullException.ThrowIfNull(item, nameof(item));
            await _channel.Writer.WriteAsync(item);
        }

        //Channel a aktarılan queue yi okuyup gerekli işlemleri yapak için return ediyoruz
        public async Task<T> DeQueue(CancellationToken cancellationToken)
        {
            return await _channel.Reader.ReadAsync(cancellationToken);
        }
    }
}
