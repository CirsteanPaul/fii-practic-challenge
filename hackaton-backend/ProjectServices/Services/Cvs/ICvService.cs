namespace hackatonBackend.ProjectServices.Services.Cvs
{
    public interface ICvService
    {
        void CreateCv(CreateCvDto cvDto, int? userId);
        CvDto GetCvDetails(int? id);
        void ChangeDetails(int? id, CvDto cvDto);
    }
}
