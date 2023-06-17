using Azure.Messaging.ServiceBus;
using CustomerApi.Data;
using CustomerApi.Interfaces;
using CustomerApi.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace CustomerApi.Services
{
    public class CustomerService : ICustomer
    {
        private ApiDbContext _context;
        public CustomerService()
        {
            _context = new ApiDbContext();
        }
    

        public async Task AddCustomer(Customer customer)
        {
            var roomCheck = await _context.Customers.FirstOrDefaultAsync(c => c.RommId == customer.RommId);
            var roomInDb = await _context.Rooms.FirstOrDefaultAsync(r => r.Id == customer.RommId);

            if (roomInDb == null)
            {
                await _context.Rooms.AddAsync(customer.Room);
                await _context.SaveChangesAsync();
            }

            if (roomCheck != null)
            {
                throw new InvalidOperationException("the room is allready booked !!");
            }

            await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync();

            // add connection string for Azure service bus
            string connectionString = "<connection_string>";
            // add queue name
            string queueName = "<queue_name>";
            // since ServiceBusClient implements IAsyncDisposable we create it with "await using"
            await using var client = new ServiceBusClient(connectionString);

            // create the sender
            ServiceBusSender sender = client.CreateSender(queueName);

            var objectAsText = JsonConvert.SerializeObject(customer);

            // create a message that we can send. UTF-8 encoding is used when providing a string.
            ServiceBusMessage message = new ServiceBusMessage(objectAsText);

            // send the message
            await sender.SendMessageAsync(message);


            
        }

        public async Task<List<Customer>> GetAllCustomers()
        {
            var customers = await _context.Customers.ToListAsync();
            return customers;
        }

        public async Task<Customer> GetCustomerById(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                return null;
            }

            return customer;
        }
    }
}
