using Azure.Messaging.ServiceBus;
using Microsoft.Azure.Amqp.Framing;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ReservationApi.Data;
using ReservationApi.Interfaces;
using ReservationApi.Models;

namespace ReservationApi.Services
{
    public class ReservationService : IReservations
    {
        private ApiDbContext _context;

        public ReservationService()
        {
                
            _context = new ApiDbContext();
        }
        public async Task<List<Reservation>> GetAllReservations()
        {
            string connectionString = "Endpoint=sb://roomreservations.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=DC/q0gglVGGyJWe43bpuKCw/unuvd0YWU+ASbJ+hKNs=";
            string queueName = "roombooking";
            // since ServiceBusClient implements IAsyncDisposable we create it with "await using"
            await using var client = new ServiceBusClient(connectionString);

            ServiceBusReceiver receiver = client.CreateReceiver(queueName);

            IReadOnlyList<ServiceBusReceivedMessage> receivedMessages = await receiver.ReceiveMessagesAsync(10);


            var reservationsInDb = await _context.Reservations.ToListAsync();
            if (receivedMessages == null)
            {
            
                if (reservationsInDb != null) { 
                    return reservationsInDb;
                }
                return null;
            }

            foreach(ServiceBusReceivedMessage receivedMessage in receivedMessages)
            {
                string body = receivedMessage.Body.ToString();
                var reservation = JsonConvert.DeserializeObject<Reservation>(body);
                await _context.Reservations.AddAsync(reservation);
                await _context.SaveChangesAsync();
                await receiver.CompleteMessageAsync(receivedMessage);


            }

            var reservations = await _context.Reservations.ToListAsync();
            return reservations;

        }
    }
}
