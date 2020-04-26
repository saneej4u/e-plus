namespace API.Dtos
{
    public class DoctorToReturnDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int TitleId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DisplayName { get; set; }
        public string GdcNumber { get; set; }
        public string Mobile { get; set; }
        public string Telephone { get; set; }
        public string PictureUrl { get; set; }
    }
}