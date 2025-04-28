

namespace SignalRWebUI.DTOs.JsonErrorDTOs
{
    //Bizim fluent tarafta yazdığımız türkçe hatalar DataAnnotations ile çakışıyor
    //O sebeble json'ı UI tarafta bir modelle karşılayıp
    //koşul kontrolüyle view'e göndermek.
    //API'den dönen json hatasını karşılayacağım modeli aşağıdaki formatta yazalım.
    public class ApiValidationErrorResponse
    {
        public string Type { get; set; }
        public string Title { get; set; }
        public int Status { get; set; }
        public Dictionary<string,List<string>> Errors { get; set; }
        public string TraceId { get; set; }
    }
}
