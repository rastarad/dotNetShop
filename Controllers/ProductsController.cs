using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Models;
using Shop.ModelsDto;
using Shop.ProductsFeatures.Commands;
using Shop.ProductsFeatures.Queries;
using Shop.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Controllers
{
    [ApiController]
    [Route("products")]
    public class ProductsController : Controller
    {

        private readonly IMediator mediator;

        public ProductsController( IMediator mediator)
        {
            this.mediator = mediator;
        }

        //List
        [HttpGet]
        public async Task<ActionResult<ProductDto>> GetAllProducts()
        {
            return View(await mediator.Send(new GetAllProducts()));
        }

        //Detail
        [HttpGet("{Id}")]
        public async Task<ActionResult> GetOneProduct([FromRoute] int id)
        {
            return View(await mediator.Send(new GetOneProduct() {Id = id}));
        }

        //Create
        [HttpGet("create")]
        public ActionResult CreateProductView()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> CreateProductAction([FromForm]CreateProduct command)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await mediator.Send(command);
            return RedirectToAction("GetAllProducts");
        }

        //Delete
        [HttpGet("{id}/delete")]
        public async Task<ActionResult> DeleteProductView([FromRoute] int id)
        {
            return View(await mediator.Send(new GetOneProduct() { Id = id }));
        }

        [HttpPost("{id}/delete")]
        public async Task<ActionResult> DeleteOneProduct([FromRoute] int id)
        {
            await mediator.Send(new DeleteProduct(){Id = id });
            return RedirectToAction("GetAllProducts");
        }
        //Edit
        [HttpGet("{id}/edit")]
        public async Task<ActionResult> EditProductView([FromRoute] int id)
        {
            return View(await mediator.Send(new GetOneProduct() {Id = id }));
        }
        [HttpPost("{id}/edit")]
        public async Task<ActionResult> EditProductAction([FromForm] EditProduct command, [FromRoute] int id)
        {
            command.Id = id;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await mediator.Send(command);
            return RedirectToAction("GetAllProducts");
        }
    }
}
