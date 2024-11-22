using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.UI.Services
{
    public class MessengerService
    {
        private static readonly Dictionary<string, Action<object>> _subscribers = new Dictionary<string, Action<object>>();

        // Método para suscribirse a un mensaje
        public static void Subscribe(string message, Action<object> callback)
        {
            if (!_subscribers.ContainsKey(message))
            {
                _subscribers[message] = callback;
            }
            else
            {
                _subscribers[message] += callback;
            }
        }

        // Método para desuscribirse de un mensaje
        public static void Unsubscribe(string message, Action<object> callback)
        {
            if (_subscribers.ContainsKey(message))
            {
                _subscribers[message] -= callback;
            }
        }

        // Método para enviar un mensaje
        public static void Send(string message, object parameter = null)
        {
            if (_subscribers.ContainsKey(message))
            {
                _subscribers[message]?.Invoke(parameter);
            }
        }
    }
}