using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Net.Sockets;

namespace CapaComunicaciones
{
    //Utilidades para enviar/recibir mensajes con framing (4 bytes de longitud + JSON UTF8).
    public class NetProtocol
    {
        private static readonly JsonSerializerOptions _jsonOptions = new()
        {

            PropertyNameCaseInsensitive = true,
            WriteIndented = false

        };

        public static async Task SendAsync<T>(NetworkStream stream, T obj, CancellationToken ct = default)
        {
            string json = JsonSerializer.Serialize(obj, _jsonOptions);
            byte[] data = Encoding.UTF8.GetBytes(json);
            byte[] len = BitConverter.GetBytes(data.Length); // 4 bytes little-endian

            await stream.WriteAsync(len, 0, len.Length, ct);
            await stream.WriteAsync(data, 0, data.Length, ct);
        }

        public static async Task<T?> ReceiveAsync<T>(NetworkStream stream, CancellationToken ct = default)
        {
            byte[] lenBytes = new byte[4];
            int read = await ReadExactAsync(stream, lenBytes, 0, 4, ct);
            if (read == 0) return default; // desconectado

            int len = BitConverter.ToInt32(lenBytes, 0);
            byte[] buffer = new byte[len];

            read = await ReadExactAsync(stream, buffer, 0, len, ct);
            if (read == 0) return default;

            string json = Encoding.UTF8.GetString(buffer);
            return JsonSerializer.Deserialize<T>(json, _jsonOptions);
        }
        private static async Task<int> ReadExactAsync(NetworkStream stream, byte[] buffer, int offset, int count, CancellationToken ct)
        {
            int total = 0;
            while (total < count)
            {
                int r = await stream.ReadAsync(buffer.AsMemory(offset + total, count - total), ct);
                if (r == 0) return 0; // desconectado
                total += r;
            }
            return total;
        }
        // Helpers para (de)serializar payloads en los NetRequest/NetResponse
        public static string ToJson<T>(T obj) => JsonSerializer.Serialize(obj, _jsonOptions);
        public static T? FromJson<T>(string? json) => json == null ? default : JsonSerializer.Deserialize<T>(json, _jsonOptions);

    }
}
