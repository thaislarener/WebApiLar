using System.Text.Json.Serialization;

namespace WebApiLar.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum TipoEnum
    {
        Residencial,
        Celular,
        Comercial
    }
}
