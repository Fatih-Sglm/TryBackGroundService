using TryBackGroundService.Entities;
using TryBackGroundService.QueueServices;
using TryBackGroundService.Repository;

namespace TryBackGroundService.Services
{
    public class QueueService : BackgroundService
    {
        private readonly IPersonRepository _personRepository;
        private readonly IQueueService<Person> _queueService;
        private readonly ILogger<QueueService> _logger;
        public QueueService(IPersonRepository personRepository, IQueueService<Person> queueService, ILogger<QueueService> logger)
        {
            _personRepository = personRepository;
            _queueService = queueService;
            _logger = logger;
        }



        //Bu metod aracılığı ile sisteme olan Queue yi DeQueue metodu ile bulup gerekli işlemleri yapıyoruz
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                Person value = await _queueService.DeQueue(stoppingToken);
                await _personRepository.AddAsync(value);
                _logger.LogInformation($" A {nameof(Person)} named {value.Name} has been added to the database.");
            }
        }
    }
}
