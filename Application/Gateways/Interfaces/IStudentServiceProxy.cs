using Application.Requests;
using Application.Responses;

namespace Application.Common.interfaces;

public interface IStudentServiceProxy
{
    Task<string> SendToStudentServiceForAddToMongoDb(StudentRequestModel studentRequestModel);
}