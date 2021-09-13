using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PostgresqlExample.Data.Context;
using PostgresqlExample.Data.Entities;
using PostgresqlExample.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostgresqlExample.API.Controllers
{
    
    [ApiController]
    public class ArticleController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        

        public ArticleController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("api/article/getallarticle")]
        public async Task<IActionResult> GetAllArticle()
        {
           
           var result=await _unitOfWork.ArticleRepository.GetAll();
           return Ok(result);
           
        }


        [HttpPost("api/article/createarticle")]
        public async Task<IActionResult>  CreateArticle([FromBody] Article model)
        {

            //Here Modelstate will check the model match between information from request and our model
            if (ModelState.IsValid)
            {
                Article article = new Article
                {
                    Title = model.Title,
                    Description = model.Description
                };

                Article result =await _unitOfWork.ArticleRepository.AddToDb(article);

                

                return Ok(result);
            }

            return BadRequest();           

        }

        [HttpGet("api/article/getonearticle/{id:int}")]
        public async Task<IActionResult> GetOneArticle(int id)
        {

            var result = await _unitOfWork.ArticleRepository.GetById(id);
            
            if (result == null) return NotFound();
            return Ok(result);

        }

        [HttpGet("api/article/deletearticle/{id:int}")]
        public async Task<IActionResult> DeleteArticle(int id)
        {
            var result = await _unitOfWork.ArticleRepository.DeleteFromDb(id);
            return Ok(result);
        }

        [HttpGet("api/article/checkarticle/{id:int}")]
        public async Task<IActionResult> CheckArticle(int id)
        {
            var result = await _unitOfWork.ArticleRepository.CheckArticle(id);
            return Ok(result);
        }

    }

}
