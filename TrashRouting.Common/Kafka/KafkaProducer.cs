﻿using Confluent.Kafka;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using System.Text;
using System.Threading.Tasks;
using TrashRouting.Common.Contracts;
using TrashRouting.Common.Messaging;

namespace TrashRouting.Common.Kafka
{
    public class KafkaProducer : IEventProducer
    {
        private readonly IServiceProvider serviceProvider;
        private readonly ProducerBuilder<string, string> producerBuilder;

        public KafkaProducer(IConfiguration configuration, IServiceProvider serviceProvider)
        {
            var config = new ProducerConfig();
            configuration.Bind(config);

            producerBuilder = new ProducerBuilder<string, string>(config);
            this.serviceProvider = serviceProvider;
        }

        // TODO: Implementation handler in other service
        public async Task PublishAsync<TEvent>(TEvent @event, ICorrelationContext context) where TEvent : IEvent
        {
            using (var producer = producerBuilder.Build())
            {
                var message = new Message<string, string>()
                {
                    Key = Guid.NewGuid().ToString(),
                    Value = JsonConvert.SerializeObject(@event)
                };

                await producer.ProduceAsync(nameof(@event), message);
            }
        }
    }
}
