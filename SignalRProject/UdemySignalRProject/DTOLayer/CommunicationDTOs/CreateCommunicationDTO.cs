using System.ComponentModel.DataAnnotations;
namespace DTOLayer.CommunicationDTOs
{
    public class CreateCommunicationDTO
    {
        public string NameSurname { get; set; }
        public string Mail { get; set; }
        public string Phone { get; set; }
        public string Subject { get; set; }
        public string MessageContent { get; set; }
    }
}
