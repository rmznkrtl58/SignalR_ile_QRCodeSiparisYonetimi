﻿

namespace DTOLayer.CommunicationDTOs
{
    public class ResultCommunicationDTO
    {
        public int CommunicationId { get; set; }
        public string NameSurname { get; set; }
        public string Mail { get; set; }
        public string Phone { get; set; }
        public string Subject { get; set; }
        public string MessageContent { get; set; }
    }
}
