namespace TIP.Dtos
{
    public class GeneralResponseDto
    {
        public bool Status { get; set; }
        public string ErrorMessage { get; set; }
        public string Exception { get; set; }
        public dynamic Entity { get; set; }
        public string Guid { get; set; }
    }
}
