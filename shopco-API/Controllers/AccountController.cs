using MediatR;
using Microsoft.AspNetCore.Mvc;
using shopco_API.Application.CQRS.Account.Commands;
using shopco_API.Application.CQRS.Account.Queries;
using shopco_API.Domain.Models.AccountModels;
namespace shopco_API.Controllers
{
    [ApiController]
    public class AccountController : Controller
    {

        public IMediator Mediator { get => _mediator ?? HttpContext.RequestServices.GetRequiredService<IMediator>(); }
        private readonly IMediator _mediator;
        public ILogger<AccountController> logger { get; set; }

        public AccountController(IMediator mediator, ILogger<AccountController> log)
        {
            logger = log;
            _mediator = mediator;
           
        }

        [Route("/register")]
        [HttpPost]
        public async Task<RegisterResponse> Register([FromForm] RegisterRequest request)
        {
           
            logger.LogWarning(Request.Form.Count.ToString());
            logger.LogWarning("-------------------------------------------------------------------------------");
            logger.LogWarning($"-------------  {request.Surname},{request.Password}, {request.Name},{request.Photo} attempt to enter  ---------------");
            return await _mediator.Send(new AccountRegisterCommand(request));
        }

        [Route("/login")]
        [HttpPost]
        public async Task<LoginResponse> Login([FromBody] LoginRequest request)
        {

            //var cookieOptions = new CookieOptions
            //{
            //    // Set your desired options for the cookie here
            //    // For example, you can set the domain, path, expiration, and other options
            //    // as per your requirements.
            //    Expires = DateTime.Now.AddDays(1),
            //    //HttpOnly = true,
            //    Secure = true, // If you're using HTTPS
            //    IsEssential = true
            //};

            Response.Cookies.Append("Set-Cookie", "thisisFromServer");

            return await _mediator.Send(new AccountLoginCommand(request));
        }

        [Route("/users")]
        [HttpGet]
        public  async Task<GetAccountResponse> GetAccount([FromQuery] GetAccountRequest request)
        {
           return await _mediator.Send(new GetAccountQuery(request));
        }

    }
}
