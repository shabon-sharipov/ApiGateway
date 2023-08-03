// using Application.Common.interfaces;
// using Application.Requests;
// using Application.Responses;
// using Microsoft.AspNetCore.Mvc;
//
// namespace ApiGateway.Controllers;
//
// [ApiController]
// [Route("[controller]")]
// public class StudentController:ControllerBase
// {
//     private readonly IStudentService _studentService;
//     
//     public StudentController(IStudentService studentService)
//     {
//         _studentService = studentService;
//     }
//
//     [HttpPost]
//     public async Task<ActionResult<StudentResponseModel>> Post(StudentRequestModel studentRequestModel)
//     {
//        var student= await _studentService.Create(studentRequestModel, CancellationToken.None);
//         return Ok(student);
//     }
// }