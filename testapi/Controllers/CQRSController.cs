using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using testapi.Filters;
using testapi.Services;

namespace testapi.Controllers
{

    // Protect all actions in the controller
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class CQRSController : BaseController
    {
        private readonly IMediator _mediator;
        public CQRSController(IMediator mediator) => _mediator = mediator;
        // [AdminOnlyFilter] // Protect the action
        [HttpGet]
        public async Task<IEnumerable<Product>> Get() => await _mediator.Send(new GetProductsQuery());

        [HttpPost]
        public async Task<IActionResult> Add(Product product)
        {
            await _mediator.Send(new AddProductCommand(product));
            return Ok();
        }


    }

    // Query
    public record GetProductsQuery() : IRequest<IEnumerable<Product>>
    {
       
    };
    public class GetProductsHandler : IRequestHandler<GetProductsQuery, IEnumerable<Product>>
    {
        public async Task<IEnumerable<Product>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(new List<Product> { new Product(1, "Laptop"), new Product(2, "Mouse") });
        }
    }

    // Command
    public record AddProductCommand(Product Product) : IRequest;
    public class AddProductHandler : IRequestHandler<AddProductCommand>
    {
        public async Task Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            // In a real app, save to the database
            await Task.CompletedTask;
        }
    }
    public record Product(int Id, string Name);
}