using System;
using System.Collections.Specialized;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Client
{
    public class response
    {
            /// <summary>
            /// HTTP код ответа
            /// </summary>
            public HttpStatusCode StatusCode => this.HttpResponse.StatusCode;

            /// <summary>
            /// Результат выполнения HTTP запроса
            /// </summary>
            public HttpResponseMessage HttpResponse { get; set; }
    }
    public static class HttpHelper
    {
        public static async Task<response> RequestPostAsync(
            HttpClient client,
            string url,
            params object[] payloadObjects)
        {
            // Необходимо правильно определить нагрузку запроса - это одиночный объект {...},
            // список объектов [{...}, {...}], либо объектов вообще нет и тело POST запроса должно быть пустым
            object payload;
            switch (payloadObjects.Length)
            {
                case 0:
                    payload = string.Empty;
                    break;
                case 1:
                    payload = payloadObjects[0];
                    break;
                default:
                    payload = payloadObjects;
                    break;
            }

            // Выполнение сериализации из C# объекта в JSON
            var payloadString = JsonConvert.SerializeObject(payload);

            // Выполнение кодирования.
            var payloadBytes = Encoding.UTF8.GetBytes(payloadString);
            var content = new ByteArrayContent(payloadBytes);

            // Установка служебной информации в HTTP заголовки.
            // Это необходимо для того, чтобы сервер мог корректно интерпретировать содержимое запроса
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            content.Headers.ContentEncoding.Add("UTF-8");
            content.Headers.ContentLength = payloadBytes.Length;

            // Выполняем POST запрос
            var response = await client.PostAsync(url, content);

            // Возвращаем результат
            return new response
            {
                HttpResponse = response
            };
        }
    }

}
