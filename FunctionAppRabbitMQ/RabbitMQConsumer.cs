using System;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using FunctionAppRabbitMQ.Contagem;

namespace FunctionAppRabbitMQ
{
    public static class RabbitMQConsumer
    {
        private const string QUEUE_NAME = "queue-testes";

        [Function(nameof(RabbitMQConsumer))]
        public static void Run([RabbitMQTrigger(QUEUE_NAME, ConnectionStringSetting = "RabbitMQConnection")] ResultadoContador item,
            FunctionContext context)
        {
            var logger = context.GetLogger(nameof(RabbitMQConsumer));
            logger.LogInformation($"Valor recebido do contador: {item.ValorAtual}");
            logger.LogInformation($"Fila: {QUEUE_NAME} | Mensagem recebida: {item.Mensagem}");
        }
    }
}