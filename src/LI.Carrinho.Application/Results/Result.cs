using Flunt.Notifications;
using System.Collections.Generic;
using System.Linq;

namespace LI.Carrinho.Application.Results
{
    public class Result : Notifiable
    {
        public bool Success { get { return !Notifications.Any(); } }

        protected Result()
        {
        }

        protected Result(IReadOnlyCollection<Notification> notifications)
        {
            AddNotifications(notifications);
        }

        public static Result Ok()
        {
            return new Result();
        }

        public static Result Error(IReadOnlyCollection<Notification> notifications)
        {
            return new Result(notifications);
        }
    }
    public class Result<T> : Notifiable where T : class
    {
        public bool Success { get { return !Notifications.Any(); } }
        public T Object { get; }
        public int StatusCode { get; set; }

        public Result(T obj)
        {
            Object = obj;
        }

        private Result(IReadOnlyCollection<Notification> notifications)
        {
            Object = null;
            AddNotifications(notifications);
        }

        private Result(string notification)
        {
            Object = null;
            AddNotification("", notification);
        }

        private Result(string notification, int statusCode)
        {
            this.Object = null;
            this.StatusCode = statusCode;
            AddNotification("", notification);
        }

        public static Result<T> Ok(T obj)
        {
            return new Result<T>(obj);
        }

        public static Result<T> Error(IReadOnlyCollection<Notification> notifications)
        {
            return new Result<T>(notifications);
        }

        public static Result<T> Error(string notificacao)
        {
            return new Result<T>(notificacao);
        }

        public static Result<T> Error(string notificacao, int statusCode)
        {
            return new Result<T>(notificacao, statusCode);
        }
    }
}
